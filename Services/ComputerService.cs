using System.Configuration;
using System.Text.Json;

namespace LoadLens.Client.Services;

internal class ComputerService
{
    public static bool IsPcSelected()
    {
        bool result = false;

        FilesService _filesService = new FilesService();
        string computerId = _filesService.GetLocalFileData(ConfigurationManager.AppSettings.Get("computerIdFileName")!);

        if (computerId != "")
        {
            result = true;
        }

        return result;
    }

    public static string SelectedPcId()
    {
        FilesService _filesService = new FilesService();
        string computerId = _filesService.GetLocalFileData(ConfigurationManager.AppSettings.Get("computerIdFileName")!);

        if (computerId != "")
        {
            return computerId;
        }

        return "";
    }

    public async static Task<string> SelectedPcName()
    {
        HttpService _httpService = new HttpService();
        FilesService _filesService = new FilesService();

        var token = _filesService.GetLocalFileData(ConfigurationManager.AppSettings.Get("jwtFileName")!);
        string computerId = _filesService.GetLocalFileData(ConfigurationManager.AppSettings.Get("computerIdFileName")!);
        var response = await _httpService.HttpGet($"/Computer/id?computerId={computerId}", token);
        var computer = JsonSerializer.Deserialize<Dictionary<string, object>>(response!)!;

        if (computer.ToString() != "")
        {
            return computer["name"].ToString();
        }

        return "";
    }
}
