using FastReport.DataVisualization.Charting;
using LoadLens.Client.Services;
using System.Configuration;
using System.Text.Json;

namespace LoadLens.Client;

public partial class frm_datalog : Form
{
    public frm_datalog()
    {
        InitializeComponent();
    }

    private void frm_datalog_Load(object sender, EventArgs e)
    {
        TextUpdate();
        ChartUpdate();
    }

    private void btn_close_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void btn_clear_Click(object sender, EventArgs e)
    {
        FilesService _filesService = new FilesService();

        _filesService.DeleteLocalFile(ConfigurationManager.AppSettings.Get("datalogFileName")!);

        TextUpdate();
        //ChartUpdate();
    }

    private void TextUpdate()
    {
        FilesService _filesService = new FilesService();

        var text = _filesService.GetLocalFileData(ConfigurationManager.AppSettings.Get("datalogFileName")!);

        rtb_local_datalog.Text = text.Replace("}\",\"{", "}\",\n\"{");
    }

    private void ChartUpdate()
    {
        FilesService _filesService = new FilesService();
        var text = _filesService.GetLocalFileData(ConfigurationManager.AppSettings.Get("datalogFileName")!);
        List<string> jsonStringList = JsonSerializer.Deserialize<List<string>>(text);

        List<Dictionary<string, object>> listaDeDicionarios = new List<Dictionary<string, object>>();
        foreach (var jsonString in jsonStringList)
        {
            var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);
            listaDeDicionarios.Add(dict);
        }

        ChartArea area = new ChartArea("MinhaArea");
        cht_data.ChartAreas.Add(area);

        Series cpuLoad = new Series("CPULoad");
        cpuLoad.ChartType = SeriesChartType.FastLine;

        foreach(var log in listaDeDicionarios)
        {
            if (log.ContainsKey("LoadCPUTotal") && log["LoadCPUTotal"] is JsonElement myDecimalElement)
            {
                if (log.ContainsKey("timestamp") && log["timestamp"] is JsonElement timestamp)
                {
                    DateTime ts = timestamp.GetDateTime();
                    decimal myDecimal = myDecimalElement.GetDecimal();
                    cpuLoad.Points.AddXY(ts, myDecimal);
                }
                
            }
        }

        Series cpuTempMax = new Series("CPUTempMax");
        cpuTempMax.ChartType = SeriesChartType.FastLine;

        foreach (var log in listaDeDicionarios)
        {
            if (log.ContainsKey("TempCoreMax") && log["TempCoreMax"] is JsonElement myDecimalElement)
            {
                if (log.ContainsKey("timestamp") && log["timestamp"] is JsonElement timestamp)
                {
                    DateTime ts = timestamp.GetDateTime();
                    decimal myDecimal = myDecimalElement.GetDecimal();
                    cpuTempMax.Points.AddXY(ts, myDecimal);
                }

            }
        }

        Series cpuTempAvg = new Series("CPUTempAvg");
        cpuTempAvg.ChartType = SeriesChartType.FastLine;

        foreach (var log in listaDeDicionarios)
        {
            if (log.ContainsKey("TempCoreAvg") && log["TempCoreAvg"] is JsonElement myDecimalElement)
            {
                if (log.ContainsKey("timestamp") && log["timestamp"] is JsonElement timestamp)
                {
                    DateTime ts = timestamp.GetDateTime();
                    decimal myDecimal = myDecimalElement.GetDecimal();
                    cpuTempAvg.Points.AddXY(ts, myDecimal);
                }
            }
        }

        cht_data.Series.Add(cpuLoad);
        cht_data.Series.Add(cpuTempMax);
        cht_data.Series.Add(cpuTempAvg);
    }

    private void btn_refresh_Click(object sender, EventArgs e)
    {
        TextUpdate();
    }

    private void btn_open_local_folder_Click(object sender, EventArgs e)
    {
        FilesService _filesService = new FilesService();
        _filesService.OpenFolder();
    }
}
