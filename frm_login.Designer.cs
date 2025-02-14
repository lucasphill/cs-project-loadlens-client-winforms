namespace LoadLens.Client
{
    partial class frm_login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_username = new Label();
            lbl_password = new Label();
            txb_username = new TextBox();
            txb_password = new TextBox();
            btn_login = new Button();
            lbl_message = new Label();
            SuspendLayout();
            // 
            // lbl_username
            // 
            lbl_username.AutoSize = true;
            lbl_username.Location = new Point(62, 54);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(60, 15);
            lbl_username.TabIndex = 0;
            lbl_username.Text = "Username";
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.Location = new Point(62, 115);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(57, 15);
            lbl_password.TabIndex = 1;
            lbl_password.Text = "Password";
            // 
            // txb_username
            // 
            txb_username.Location = new Point(62, 72);
            txb_username.Name = "txb_username";
            txb_username.PlaceholderText = "Username";
            txb_username.Size = new Size(167, 23);
            txb_username.TabIndex = 2;
            // 
            // txb_password
            // 
            txb_password.Location = new Point(62, 133);
            txb_password.Name = "txb_password";
            txb_password.PasswordChar = '*';
            txb_password.PlaceholderText = "Password";
            txb_password.Size = new Size(167, 23);
            txb_password.TabIndex = 3;
            // 
            // btn_login
            // 
            btn_login.Location = new Point(95, 179);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(100, 23);
            btn_login.TabIndex = 4;
            btn_login.Text = "Login";
            btn_login.UseVisualStyleBackColor = true;
            btn_login.Click += btn_login_Click;
            // 
            // lbl_message
            // 
            lbl_message.AutoSize = true;
            lbl_message.Location = new Point(62, 217);
            lbl_message.Name = "lbl_message";
            lbl_message.Size = new Size(0, 15);
            lbl_message.TabIndex = 5;
            lbl_message.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frm_login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 261);
            Controls.Add(lbl_message);
            Controls.Add(btn_login);
            Controls.Add(txb_password);
            Controls.Add(txb_username);
            Controls.Add(lbl_password);
            Controls.Add(lbl_username);
            Name = "frm_login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_username;
        private Label lbl_password;
        private TextBox txb_username;
        private TextBox txb_password;
        private Button btn_login;
        private Label lbl_message;
    }
}
