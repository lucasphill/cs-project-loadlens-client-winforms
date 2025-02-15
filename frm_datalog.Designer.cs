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
            btn_close = new Button();
            btn_clear = new Button();
            btn_refresh = new Button();
            btn_open_local_folder = new Button();
            dataGridView2 = new DataGridView();
            cht_data = new FastReport.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cht_data).BeginInit();
            SuspendLayout();
            // 
            // rtb_local_datalog
            // 
            rtb_local_datalog.Dock = DockStyle.Bottom;
            rtb_local_datalog.Location = new Point(0, 336);
            rtb_local_datalog.Name = "rtb_local_datalog";
            rtb_local_datalog.Size = new Size(492, 213);
            rtb_local_datalog.TabIndex = 0;
            rtb_local_datalog.Text = "";
            rtb_local_datalog.WordWrap = false;
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
            // btn_close
            // 
            btn_close.Location = new Point(353, 31);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(75, 23);
            btn_close.TabIndex = 4;
            btn_close.Text = "Close";
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // btn_clear
            // 
            btn_clear.Location = new Point(118, 31);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(100, 23);
            btn_clear.TabIndex = 5;
            btn_clear.Text = "Clear Local Log";
            btn_clear.UseVisualStyleBackColor = true;
            btn_clear.Click += btn_clear_Click;
            // 
            // btn_refresh
            // 
            btn_refresh.Location = new Point(12, 31);
            btn_refresh.Name = "btn_refresh";
            btn_refresh.Size = new Size(96, 23);
            btn_refresh.TabIndex = 6;
            btn_refresh.Text = "Update Page";
            btn_refresh.UseVisualStyleBackColor = true;
            btn_refresh.Click += btn_refresh_Click;
            // 
            // btn_open_local_folder
            // 
            btn_open_local_folder.Location = new Point(224, 31);
            btn_open_local_folder.Name = "btn_open_local_folder";
            btn_open_local_folder.Size = new Size(123, 23);
            btn_open_local_folder.TabIndex = 7;
            btn_open_local_folder.Text = "Open Local Folder";
            btn_open_local_folder.UseVisualStyleBackColor = true;
            btn_open_local_folder.Click += btn_open_local_folder_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(335, 146);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(8, 8);
            dataGridView2.TabIndex = 9;
            // 
            // cht_data
            // 
            cht_data.Dock = DockStyle.Bottom;
            cht_data.Location = new Point(0, 155);
            cht_data.Name = "cht_data";
            cht_data.Size = new Size(492, 181);
            cht_data.TabIndex = 10;
            // 
            // frm_datalog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            ClientSize = new Size(492, 549);
            Controls.Add(cht_data);
            Controls.Add(dataGridView2);
            Controls.Add(btn_open_local_folder);
            Controls.Add(btn_refresh);
            Controls.Add(btn_clear);
            Controls.Add(btn_close);
            Controls.Add(label1);
            Controls.Add(rtb_local_datalog);
            Name = "frm_datalog";
            Text = "Datalogs";
            Load += frm_datalog_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)cht_data).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtb_local_datalog;
        private Label label1;
        private Button btn_close;
        private Button btn_clear;
        private Button btn_refresh;
        private Button btn_open_local_folder;
        private DataGridView dataGridView2;
        private FastReport.DataVisualization.Charting.Chart cht_data;
    }
}