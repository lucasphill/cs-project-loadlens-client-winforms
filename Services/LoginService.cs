using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LoadLens.Client.Services;

internal class LoginService
{
    public async static Task<bool> Login(Dictionary<string, object> loginData)
    {
        string apiUrl = "/Account/Login";

        var _httpService = new HttpService();
        var _filesService = new FilesService();

        string jsonData = System.Text.Json.JsonSerializer.Serialize(loginData);

        var response = await _httpService.HttpPost(apiUrl, jsonData);

        if (response.Data == null) { return false; }

        _filesService.SaveLocalFile(response.Data, ConfigurationManager.AppSettings.Get("jwtFileName")!);
        return true;
    }

    public static bool Logout()
    {
        var _filesSerivce = new FilesService();

        _filesSerivce.DeleteLocalFile(ConfigurationManager.AppSettings.Get("jwtFileName")!);
        _filesSerivce.DeleteLocalFile(ConfigurationManager.AppSettings.Get("computerIdFileName")!);
        if (!File.Exists(ConfigurationManager.AppSettings.Get("jwtFileName")!) || !File.Exists(ConfigurationManager.AppSettings.Get("computerIdFileName")!))
        {
            return true;
        }
        return false;
    }

    public static bool IsLogged()
    {
        bool result;

        var _filesHelper = new FilesService();
        string token = _filesHelper.GetLocalFileData(ConfigurationManager.AppSettings.Get("jwtFileName")!);

        ClaimsPrincipal? claimsPrincipal;
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
        var _filesService = new FilesService();
        string token = _filesService.GetLocalFileData(ConfigurationManager.AppSettings.Get("jwtFileName")!);

        if (token != "")
        {
            return token;
        }

        return "";
    }

    public async static Task<string> GetUsername()
    {
        var apiUrl = "/Account/Info";

        try
        {
            var _httpService = new HttpService();

            var response = await _httpService.HttpGet(apiUrl, LoginService.UserToken());
            if(response.Data == null) { return response.Message; }

            var userData = JsonSerializer.Deserialize<Dictionary<string, object>>(response.Data);

            var username = userData["userName"].ToString();

            return username;
        }
        catch
        {
            return "Request failed";
        }
    }
}
