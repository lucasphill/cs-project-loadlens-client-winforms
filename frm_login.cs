using LoadLens.Client.Services;

namespace LoadLens.Client
{
    public partial class frm_login : Form
    {
        // TODO: corrigir caso feche a tela de login pelo X antes de logar
        public frm_login()
        {
            InitializeComponent();
        }

        private async void btn_login_Click(object sender, EventArgs e)
        {
            btn_login.Enabled = false;

            //var loginData = new Dictionary<string, object>
            //{
            //    ["username"] = txb_username.Text= "string",
            //    ["password"] = txb_password.Text = "Senha@123"
            //};
            var loginData = new Dictionary<string, object>
            {
                ["username"] = txb_username.Text.Trim(),
                ["password"] = txb_password.Text.Trim()
            };

            var response = await LoginService.Login(loginData);

            if (response == false) { lbl_message.Text = "Wrong username or password"; Thread.Sleep(1000); }

            btn_login.Enabled = true;

            Close();
        }
    }
}
