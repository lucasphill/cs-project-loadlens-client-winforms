namespace LoadLens.Client
{
    partial class frm_index
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_index));
            lbl_selected_computer = new Label();
            lbl_username = new Label();
            label3 = new Label();
            mst_top = new MenuStrip();
            selectActiveComputerToolStripMenuItem = new ToolStripMenuItem();
            logsToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            lbl_selected_computer_id_value = new Label();
            lbl_selected_computer_name_value = new Label();
            lbl_last_datalog_timestamp = new Label();
            label1 = new Label();
            mst_top.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_selected_computer
            // 
            lbl_selected_computer.AutoSize = true;
            lbl_selected_computer.Location = new Point(25, 73);
            lbl_selected_computer.Name = "lbl_selected_computer";
            lbl_selected_computer.Size = new Size(140, 15);
            lbl_selected_computer.TabIndex = 0;
            lbl_selected_computer.Text = "Selected active computer";
            // 
            // lbl_username
            // 
            lbl_username.AutoSize = true;
            lbl_username.Location = new Point(25, 39);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(60, 15);
            lbl_username.TabIndex = 1;
            lbl_username.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Enabled = false;
            label3.Location = new Point(25, 125);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 2;
            label3.Text = "Last datalog";
            // 
            // mst_top
            // 
            mst_top.Items.AddRange(new ToolStripItem[] { selectActiveComputerToolStripMenuItem, logsToolStripMenuItem, logoutToolStripMenuItem, exitToolStripMenuItem });
            mst_top.Location = new Point(0, 0);
            mst_top.Name = "mst_top";
            mst_top.Size = new Size(295, 24);
            mst_top.TabIndex = 3;
            mst_top.Text = "mst_top";
            // 
            // selectActiveComputerToolStripMenuItem
            // 
            selectActiveComputerToolStripMenuItem.Name = "selectActiveComputerToolStripMenuItem";
            selectActiveComputerToolStripMenuItem.Size = new Size(143, 20);
            selectActiveComputerToolStripMenuItem.Text = "Select Active Computer";
            selectActiveComputerToolStripMenuItem.Click += selectActiveComputerToolStripMenuItem_Click;
            // 
            // logsToolStripMenuItem
            // 
            logsToolStripMenuItem.Enabled = false;
            logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            logsToolStripMenuItem.Size = new Size(44, 20);
            logsToolStripMenuItem.Text = "Logs";
            logsToolStripMenuItem.Click += logsToolStripMenuItem_Click;
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(57, 20);
            logoutToolStripMenuItem.Text = "Logout";
            logoutToolStripMenuItem.Click += logoutToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(37, 20);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // lbl_selected_computer_id_value
            // 
            lbl_selected_computer_id_value.AutoSize = true;
            lbl_selected_computer_id_value.BorderStyle = BorderStyle.Fixed3D;
            lbl_selected_computer_id_value.Location = new Point(171, 73);
            lbl_selected_computer_id_value.Name = "lbl_selected_computer_id_value";
            lbl_selected_computer_id_value.Size = new Size(35, 17);
            lbl_selected_computer_id_value.TabIndex = 4;
            lbl_selected_computer_id_value.Text = "Pc Id";
            lbl_selected_computer_id_value.Visible = false;
            // 
            // lbl_selected_computer_name_value
            // 
            lbl_selected_computer_name_value.AutoSize = true;
            lbl_selected_computer_name_value.BorderStyle = BorderStyle.Fixed3D;
            lbl_selected_computer_name_value.Location = new Point(25, 88);
            lbl_selected_computer_name_value.Name = "lbl_selected_computer_name_value";
            lbl_selected_computer_name_value.Size = new Size(57, 17);
            lbl_selected_computer_name_value.TabIndex = 5;
            lbl_selected_computer_name_value.Text = "Pc Name";
            // 
            // lbl_last_datalog_timestamp
            // 
            lbl_last_datalog_timestamp.AutoSize = true;
            lbl_last_datalog_timestamp.BorderStyle = BorderStyle.Fixed3D;
            lbl_last_datalog_timestamp.Enabled = false;
            lbl_last_datalog_timestamp.Location = new Point(25, 140);
            lbl_last_datalog_timestamp.Name = "lbl_last_datalog_timestamp";
            lbl_last_datalog_timestamp.Size = new Size(66, 17);
            lbl_last_datalog_timestamp.TabIndex = 6;
            lbl_last_datalog_timestamp.Text = "timestamp";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 24);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 7;
            label1.Text = "Username: ";
            // 
            // frm_index
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(295, 189);
            Controls.Add(label1);
            Controls.Add(lbl_last_datalog_timestamp);
            Controls.Add(lbl_selected_computer_name_value);
            Controls.Add(lbl_selected_computer_id_value);
            Controls.Add(label3);
            Controls.Add(lbl_username);
            Controls.Add(lbl_selected_computer);
            Controls.Add(mst_top);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mst_top;
            Name = "frm_index";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoadLens Project";
            FormClosing += frm_index_FormClosing;
            Load += frm_index_Load;
            Resize += frm_index_Resize;
            mst_top.ResumeLayout(false);
            mst_top.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_selected_computer;
        private Label lbl_username;
        private Label label3;
        private MenuStrip mst_top;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripMenuItem logsToolStripMenuItem;
        private ToolStripMenuItem selectActiveComputerToolStripMenuItem;
        private Label lbl_selected_computer_id_value;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Label lbl_selected_computer_name_value;
        private Label lbl_last_datalog_timestamp;
        private Label label1;
    }
}