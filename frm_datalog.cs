using LoadLens.Client.DTOs;
using System.Text.Json;
using LoadLens.Client.Services;
using LoadLens.API.DTOs.DatalogDTO;
using Microsoft.VisualBasic.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Configuration;

namespace LoadLens.Client;

public partial class frm_datalog : Form
{
    public frm_datalog()
    {
        InitializeComponent();
    }

    private void frm_datalog_Load(object sender, EventArgs e)
    {
        FilesService _filesService = new FilesService();

        var text = _filesService.GetLocalFileData(ConfigurationManager.AppSettings.Get("datalog.txt")!);

        var datalog = JsonSerializer.Deserialize<Dictionary<string, object>>(text, new JsonSerializerOptions { WriteIndented = true });

        var options = new JsonSerializerOptions
        {
            WriteIndented = true // Ativa a indentação
        };
        string json = JsonSerializer.Serialize(datalog, options);

        rtb_local_datalog.Text = json;
    }
}
