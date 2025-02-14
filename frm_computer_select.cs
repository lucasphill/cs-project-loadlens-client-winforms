using System.Configuration;
using System.Text.Json;
using LoadLens.Client.DTOs;
using LoadLens.Client.Services;

namespace LoadLens.Client
{
    // TODO: corrigir caso não tenha nenhum computador cadastrado
    public partial class frm_computer_select : Form
    {
        public frm_computer_select()
        {
            InitializeComponent();
        }

        private async void frm_computer_select_Load(object sender, EventArgs e)
        {
            HttpService _httpService = new HttpService();
            FilesService _filesService = new FilesService();

            //_filesService.DeleteLocalFile("computer_id.txt");

            var token = _filesService.GetLocalFileData(ConfigurationManager.AppSettings.Get("jwtFileName")!);
            var response = await _httpService.HttpGet("/Computer/Active", token);
            var computerList = JsonSerializer.Deserialize<List<GetComputerDTO>>(response!)!;

            cmb_computer_list.DataSource = computerList;
            cmb_computer_list.DisplayMember = "name"; //TODO: verificar
            cmb_computer_list.SelectedIndex = 0;
        }

        private void btn_computer_select_Click(object sender, EventArgs e)
        {
            FilesService _filesService = new FilesService();

            if (cmb_computer_list.SelectedItem != null)
            {
                GetComputerDTO selectedComputer = (GetComputerDTO)cmb_computer_list.SelectedItem;
                string idSelecionado = selectedComputer.id;
                _filesService.SaveLocalFile(idSelecionado, ConfigurationManager.AppSettings.Get("computerIdFileName")!);
                Close();
            }
            else
            {
                // TODO: set error message
            }
        }
    }
}
