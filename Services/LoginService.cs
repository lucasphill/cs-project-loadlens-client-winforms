using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace LoadLens.Client.Services;

internal class LoginService
{
    public async static Task<bool> Login(Dictionary<string, object> loginData)
    {
        string apiUrl = "/Account/Login";

        HttpService _httpService = new HttpService();
        FilesService _filesService = new FilesService();

        string jsonData = System.Text.Json.JsonSerializer.Serialize(loginData);

        var response = await _httpService.HttpPost(apiUrl, jsonData);

        if (response == null) { return false; }

        _filesService.SaveLocalFile(response, ConfigurationManager.AppSettings.Get("jwtFileName")!);
        return true;
    }

    public static bool Logout()
    {
        FilesService _filesSerivce = new FilesService();

        _filesSerivce.DeleteLocalFile("jwt_token.txt");
        _filesSerivce.DeleteLocalFile("computer_id.txt");
        if (!File.Exists("jwt_token.txt") || !File.Exists("computer_id.txt"))
        {
            return true;
        }
        return false;
    }

    public static bool IsLogged()
    {
        bool result = false;

        FilesService _filesHelper = new FilesService();
        string token = _filesHelper.GetLocalFileData("jwt_token.txt");

        ClaimsPrincipal? claimsPrincipal;
        claimsPrincipal = null;
        //var secretKey = @"V.l8J6t78Dt!gTDZn61S68i7tTs!^?eC\\)S/TE/1'-?$'J4987@#";
        var secretKey = ConfigurationManager.AppSettings.Get("ApiKey")!;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(secretKey);

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
            ValidateIssuer = false,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ClockSkew = TimeSpan.Zero
        };

        try
        {
            claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            result = true;
        }
        catch
        {
            result = false;
        }

        return result;
    }

    public static string UserToken()
    {
        FilesService _filesService = new FilesService();
        string token = _filesService.GetLocalFileData("jwt_token.txt");

        if (token != "")
        {
            return token;
        }

        return "";
    }

    public async static Task<string> GetUsername()
    {
        string apiUrl = "/Account/Info";

        HttpService _httpService = new HttpService();

        var response = await _httpService.HttpGet(apiUrl, LoginService.UserToken());
        var userData = JsonSerializer.Deserialize<Dictionary<string, object>>(response!)!;

        if (userData == null) { return "Username get failed"; }

        return userData["userName"].ToString()!;
    }

}
