using System.Configuration;
using LibreHardwareMonitor.Hardware;
using LoadLens.Client.DTOs;

namespace LoadLens.Client.Services;

internal class DatalogService
{
    private static volatile bool _isRunning = false; // Flag to control the background task
    private static Thread _backgroundThread;

    public void Start()
    {
        if (_isRunning)
        {
            Console.WriteLine("Background task is already running.");
            return;
        }

        _isRunning = true;
        _backgroundThread = new Thread(() => BackgroundTask());
        _backgroundThread.IsBackground = true; // Make the thread a background thread
        _backgroundThread.Start();
        Console.WriteLine("Background task started.");
    }

    public void Stop()
    {
        if (!_isRunning)
        {
            Console.WriteLine("Background task is not running.");
            return;
        }

        _isRunning = false;
        _backgroundThread.Join(); // Wait for the thread to finish
        Console.WriteLine("Background task stopped.");
    }

    private async void BackgroundTask()
    {
        while (_isRunning)
        {
            HttpService _httpService = new HttpService();
            FilesService _filesService = new FilesService();

            var createDatalogDTO = new CreateCPUDatalogDTO();

            var computerId = _filesService.GetLocalFileData(ConfigurationManager.AppSettings.Get("computerIdFileName")!);
            var token = _filesService.GetLocalFileData(ConfigurationManager.AppSettings.Get("jwtFileName")!);
            var apiUrl = $"/Datalog?computerId={computerId}";


            var computer = new Computer { IsCpuEnabled = true, IsGpuEnabled = false };
            string jsonData = "";

            computer.Open();
            foreach (var hardwareItem in computer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.Cpu)
                {
                    var loadDict = hardwareItem.Sensors.Where(x => x.SensorType == SensorType.Load).ToDictionary(p => p.Name, p => p.Value);
                    var tempDict = hardwareItem.Sensors.Where(x => x.SensorType == SensorType.Temperature).ToDictionary(p => p.Name, p => p.Value);
                    //var clockDict = hardwareItem.Sensors.Where(x => x.SensorType == SensorType.Clock).ToDictionary(p => p.Name, p => p.Value);
                    //var powerDict = hardwareItem.Sensors.Where(x => x.SensorType == SensorType.Power).ToDictionary(p => p.Name, p => p.Value);
                    //var voltageDict = hardwareItem.Sensors.Where(x => x.SensorType == SensorType.Voltage).ToDictionary(p => p.Name, p => p.Value);

                    createDatalogDTO.HardwareName = hardwareItem.Name;
                    createDatalogDTO.LoadCPUTotal = loadDict["CPU Total"]!.Value;
                    createDatalogDTO.TempCoreMax = tempDict["Core Max"]!.Value;
                    createDatalogDTO.TempCoreAvg = tempDict["Core Average"]!.Value;

                    var cpuDatalog = new
                    {
                        HardwareName = hardwareItem.Name,
                        LoadCPUTotal = loadDict["CPU Total"]!.Value,
                        TempCoreMax = tempDict["Core Max"]!.Value,
                        TempCoreAvg = tempDict["Core Average"]!.Value,
                    };

                    jsonData = System.Text.Json.JsonSerializer.Serialize(cpuDatalog);
                }
            }

            var response = await _httpService.HttpPost(apiUrl, jsonData, token);

            var json = $"{{ \"pcid\":\"{computerId}\", \"data\":{jsonData} }}, \n";

            // TODO: corrigir o formato do log para aparecer em json e não carregar o arquivo inteiro para o app antes de salvar

            //_filesService.AppendLocalFile(json, "datalog.json");
            _filesService.AppendToJsonFile(jsonData, "datalog.json");

;
            computer.Close();

            Thread.Sleep(30000);
        }
    }
}
