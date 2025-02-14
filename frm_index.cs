using LoadLens.Client.Services;


namespace LoadLens.Client;

public partial class frm_index : Form
{
    // TODO: mostrar data do ultimo log
    // TODO: adicionar link para o site
    // TODO: adicionar configurações de ambiente appsettings

    DatalogService _datalogService = new DatalogService();

    public frm_index()
    {
        InitializeComponent();
        ConfigurarSystemTray();
    }

    private void frm_index_Load(object sender, EventArgs e)
    {
        if (LoginService.IsLogged() == false)
        {
            frm_login frm = new frm_login();
            frm.ShowDialog();
        }
        if (ComputerService.IsPcSelected() == false)
        {
            frm_computer_select frmComputer = new frm_computer_select();
            frmComputer.ShowDialog();
        }
        if (LoginService.UserToken() != "" && ComputerService.SelectedPcId() != "")
        {
            _datalogService.Start();
        }

        DataRefresh();
    }

    private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Hide();

        _datalogService.Stop();
        LoginService.Logout();

        frm_login frm = new frm_login();
        frm.ShowDialog();

        frm_computer_select frmComputer = new frm_computer_select();
        frmComputer.ShowDialog();

        _datalogService.Start();

        Show();
    }

    private void selectActiveComputerToolStripMenuItem_Click(object sender, EventArgs e)
    {
        _datalogService.Stop();

        frm_computer_select frm = new frm_computer_select();
        frm.ShowDialog();
        DataRefresh();

        _datalogService.Start();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Environment.Exit(0);
    }

    public async void DataRefresh()
    {
        if (LoginService.UserToken() != "" && ComputerService.SelectedPcId() != "")
        {
            lbl_username.Text = await LoginService.GetUsername();
            lbl_selected_computer_id_value.Text = ComputerService.SelectedPcId();
            lbl_selected_computer_name_value.Text = await ComputerService.SelectedPcName();
        }
    }

    private void logsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // TODO: implementar log screen
        frm_datalog frm = new frm_datalog();
        frm.ShowDialog();
    }


    /****************************************************************************************/

    private NotifyIcon notifyIcon;
    private ContextMenuStrip contextMenu;
    private void ConfigurarSystemTray()
    {
        // Criar menu de contexto
        contextMenu = new ContextMenuStrip();
        ToolStripMenuItem abrirItem = new ToolStripMenuItem("Abrir");
        ToolStripMenuItem sairItem = new ToolStripMenuItem("Sair");

        abrirItem.Click += (sender, e) => MostrarJanela();
        sairItem.Click += (sender, e) => FecharAplicacao();

        contextMenu.Items.Add(abrirItem);
        contextMenu.Items.Add(sairItem);

        // Criar NotifyIcon
        notifyIcon = new NotifyIcon
        {
            Icon = Icon,
            Text = "LoadLens V0",
            Visible = true,
            ContextMenuStrip = contextMenu
        };

        notifyIcon.DoubleClick += (sender, e) => MostrarJanela();
    }

    private void MostrarJanela()
    {
        this.Show();
        this.WindowState = FormWindowState.Normal;
    }

    private void FecharAplicacao()
    {
        notifyIcon.Visible = false; // Ocultar ícone antes de fechar
        Environment.Exit(0);
    }
    private void frm_index_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true; // Impedir fechamento direto
        this.Hide();
    }

    private void frm_index_Resize(object sender, EventArgs e)
    {
        if (WindowState == FormWindowState.Minimized)
        {
            this.Hide();
        }
    }
}
