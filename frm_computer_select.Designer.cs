namespace LoadLens.Client
{
    partial class frm_computer_select
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
            cmb_computer_list = new ComboBox();
            btn_computer_select = new Button();
            lbl_computer_name = new Label();
            SuspendLayout();
            // 
            // cmb_computer_list
            // 
            cmb_computer_list.FormattingEnabled = true;
            cmb_computer_list.Location = new Point(31, 51);
            cmb_computer_list.Name = "cmb_computer_list";
            cmb_computer_list.Size = new Size(288, 23);
            cmb_computer_list.TabIndex = 0;
            // 
            // btn_computer_select
            // 
            btn_computer_select.Location = new Point(219, 96);
            btn_computer_select.Name = "btn_computer_select";
            btn_computer_select.Size = new Size(100, 23);
            btn_computer_select.TabIndex = 1;
            btn_computer_select.Text = "Set as active";
            btn_computer_select.UseVisualStyleBackColor = true;
            btn_computer_select.Click += btn_computer_select_Click;
            // 
            // lbl_computer_name
            // 
            lbl_computer_name.AutoSize = true;
            lbl_computer_name.Location = new Point(31, 33);
            lbl_computer_name.Name = "lbl_computer_name";
            lbl_computer_name.Size = new Size(94, 15);
            lbl_computer_name.TabIndex = 2;
            lbl_computer_name.Text = "Computer name";
            // 
            // frm_computer_select
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 143);
            Controls.Add(lbl_computer_name);
            Controls.Add(btn_computer_select);
            Controls.Add(cmb_computer_list);
            Name = "frm_computer_select";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select active computer";
            Load += frm_computer_select_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmb_computer_list;
        private Button btn_computer_select;
        private Label lbl_computer_name;
    }
}