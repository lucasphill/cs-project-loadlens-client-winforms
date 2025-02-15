using System.Configuration;
using System.Text.Json;

namespace LoadLens.Client.Services;

internal class ComputerService
{
    public static bool IsPcSelected()
    {
        bool result = false;

        var _filesService = new FilesService();
        string computerId = _filesService.GetLocalFileData(ConfigurationManager.AppSettings.Get("computerIdFileName")!);

        if (computerId != "")
        {
            result = true;
        }

        return result;
    }

    public static string SelectedPcId()
    {
        var _filesService = new FilesService();
        string computerId = _filesService.GetLocalFileData(ConfigurationManager.AppSettings.Get("computerIdFileName")!);

        if (computerId != "")
        {
            return computerId;
        }

        return "";
    }

    public async static Task<string> SelectedPcName()
    {
        var _httpService = new HttpService();
        var _filesService = new FilesService();

        var token = _filesService.GetLocalFileData(ConfigurationManager.AppSettings.Get("jwtFileName")!);
        string computerId = _filesService.GetLocalFileData(ConfigurationManager.AppSettings.Get("computerIdFileName")!);
        if(computerId == null) { return "Computer Id not found"; }

        try
        {
            var response = await _httpService.HttpGet($"/Computer/id?computerId={computerId}", token);
            var computer = JsonSerializer.Deserialize<Dictionary<string, object>>(response.Data!)!;

            if (computer["name"].ToString() != null && computer["name"].ToString() != "")
            {
                var computerName = computer["name"].ToString()!;
                return computerName;
            }

            return "";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
