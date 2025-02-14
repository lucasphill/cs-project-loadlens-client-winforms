namespace LoadLens.Client
{
    partial class frm_datalog
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
            rtb_local_datalog = new RichTextBox();
            label1 = new Label();
            rtb_server_datalog = new RichTextBox();
            label2 = new Label();
            btn_close = new Button();
            SuspendLayout();
            // 
            // rtb_local_datalog
            // 
            rtb_local_datalog.Location = new Point(12, 27);
            rtb_local_datalog.Name = "rtb_local_datalog";
            rtb_local_datalog.Size = new Size(383, 382);
            rtb_local_datalog.TabIndex = 0;
            rtb_local_datalog.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 1;
            label1.Text = "Local Datalog File";
            // 
            // rtb_server_datalog
            // 
            rtb_server_datalog.Location = new Point(405, 27);
            rtb_server_datalog.Name = "rtb_server_datalog";
            rtb_server_datalog.Size = new Size(383, 382);
            rtb_server_datalog.TabIndex = 2;
            rtb_server_datalog.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(405, 9);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 3;
            label2.Text = "Server Datalog";
            // 
            // btn_close
            // 
            btn_close.Location = new Point(713, 419);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(75, 23);
            btn_close.TabIndex = 4;
            btn_close.Text = "Close";
            btn_close.UseVisualStyleBackColor = true;
            // 
            // frm_datalog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(btn_close);
            Controls.Add(label2);
            Controls.Add(rtb_server_datalog);
            Controls.Add(label1);
            Controls.Add(rtb_local_datalog);
            Name = "frm_datalog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Datalogs";
            Load += frm_datalog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtb_local_datalog;
        private Label label1;
        private RichTextBox rtb_server_datalog;
        private Label label2;
        private Button btn_close;
    }
}