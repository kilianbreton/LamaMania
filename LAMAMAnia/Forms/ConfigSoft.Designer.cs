namespace LamaMania
{
    partial class ConfigSoft
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
            this.formSkin1 = new FlatUITheme.FormSkin();
            this.flatTabControl1 = new FlatUITheme.FlatTabControl();
            this.tp_general = new System.Windows.Forms.TabPage();
            this.flatLabel5 = new FlatUITheme.FlatLabel();
            this.flatLabel2 = new FlatUITheme.FlatLabel();
            this.cb_lang = new FlatUITheme.FlatComboBox();
            this.tb_logPath = new FlatUITheme.FlatTextBox();
            this.flatLabel1 = new FlatUITheme.FlatLabel();
            this.cb_lamaMode = new FlatUITheme.FlatComboBox();
            this.flatLabel8 = new FlatUITheme.FlatLabel();
            this.flatLabel3 = new FlatUITheme.FlatLabel();
            this.cb_start = new FlatUITheme.FlatComboBox();
            this.tb_ressourcePath = new FlatUITheme.FlatTextBox();
            this.tb_serverMode = new FlatUITheme.FlatTextBox();
            this.tb_cachePath = new FlatUITheme.FlatTextBox();
            this.flatLabel4 = new FlatUITheme.FlatLabel();
            this.tb_configPath = new FlatUITheme.FlatTextBox();
            this.flatLabel6 = new FlatUITheme.FlatLabel();
            this.flatLabel7 = new FlatUITheme.FlatLabel();
            this.tp_externTools = new System.Windows.Forms.TabPage();
            this.b_exTool_add = new FlatUITheme.FlatButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.b_cancel = new FlatUITheme.FlatButton();
            this.b_save = new FlatUITheme.FlatButton();
            this.formSkin1.SuspendLayout();
            this.flatTabControl1.SuspendLayout();
            this.tp_general.SuspendLayout();
            this.tp_externTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // formSkin1
            // 
            this.formSkin1.BackColor = System.Drawing.Color.White;
            this.formSkin1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.formSkin1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.formSkin1.Controls.Add(this.flatTabControl1);
            this.formSkin1.Controls.Add(this.b_cancel);
            this.formSkin1.Controls.Add(this.b_save);
            this.formSkin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formSkin1.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.formSkin1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.formSkin1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.formSkin1.HeaderMaximize = false;
            this.formSkin1.Location = new System.Drawing.Point(0, 0);
            this.formSkin1.Margin = new System.Windows.Forms.Padding(2);
            this.formSkin1.Name = "formSkin1";
            this.formSkin1.Size = new System.Drawing.Size(911, 408);
            this.formSkin1.TabIndex = 0;
            this.formSkin1.Text = "Configuration";
            // 
            // flatTabControl1
            // 
            this.flatTabControl1.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatTabControl1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.flatTabControl1.Controls.Add(this.tp_general);
            this.flatTabControl1.Controls.Add(this.tp_externTools);
            this.flatTabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatTabControl1.ItemSize = new System.Drawing.Size(120, 40);
            this.flatTabControl1.Location = new System.Drawing.Point(1, 49);
            this.flatTabControl1.Name = "flatTabControl1";
            this.flatTabControl1.SelectedIndex = 0;
            this.flatTabControl1.Size = new System.Drawing.Size(910, 319);
            this.flatTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.flatTabControl1.TabIndex = 19;
            // 
            // tp_general
            // 
            this.tp_general.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tp_general.Controls.Add(this.flatLabel5);
            this.tp_general.Controls.Add(this.flatLabel2);
            this.tp_general.Controls.Add(this.cb_lang);
            this.tp_general.Controls.Add(this.tb_logPath);
            this.tp_general.Controls.Add(this.flatLabel1);
            this.tp_general.Controls.Add(this.cb_lamaMode);
            this.tp_general.Controls.Add(this.flatLabel8);
            this.tp_general.Controls.Add(this.flatLabel3);
            this.tp_general.Controls.Add(this.cb_start);
            this.tp_general.Controls.Add(this.tb_ressourcePath);
            this.tp_general.Controls.Add(this.tb_serverMode);
            this.tp_general.Controls.Add(this.tb_cachePath);
            this.tp_general.Controls.Add(this.flatLabel4);
            this.tp_general.Controls.Add(this.tb_configPath);
            this.tp_general.Controls.Add(this.flatLabel6);
            this.tp_general.Controls.Add(this.flatLabel7);
            this.tp_general.Location = new System.Drawing.Point(4, 44);
            this.tp_general.Name = "tp_general";
            this.tp_general.Padding = new System.Windows.Forms.Padding(3);
            this.tp_general.Size = new System.Drawing.Size(902, 271);
            this.tp_general.TabIndex = 0;
            this.tp_general.Text = "General";
            // 
            // flatLabel5
            // 
            this.flatLabel5.AutoSize = true;
            this.flatLabel5.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel5.ForeColor = System.Drawing.Color.White;
            this.flatLabel5.Location = new System.Drawing.Point(8, 76);
            this.flatLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.flatLabel5.Name = "flatLabel5";
            this.flatLabel5.Size = new System.Drawing.Size(88, 19);
            this.flatLabel5.TabIndex = 10;
            this.flatLabel5.Text = "Config path :";
            // 
            // flatLabel2
            // 
            this.flatLabel2.AutoSize = true;
            this.flatLabel2.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel2.ForeColor = System.Drawing.Color.White;
            this.flatLabel2.Location = new System.Drawing.Point(604, 39);
            this.flatLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.flatLabel2.Name = "flatLabel2";
            this.flatLabel2.Size = new System.Drawing.Size(76, 19);
            this.flatLabel2.TabIndex = 5;
            this.flatLabel2.Text = "Language :";
            // 
            // cb_lang
            // 
            this.cb_lang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cb_lang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_lang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_lang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_lang.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cb_lang.ForeColor = System.Drawing.Color.White;
            this.cb_lang.FormattingEnabled = true;
            this.cb_lang.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cb_lang.ItemHeight = 18;
            this.cb_lang.Items.AddRange(new object[] {
            "Default"});
            this.cb_lang.Location = new System.Drawing.Point(702, 40);
            this.cb_lang.Margin = new System.Windows.Forms.Padding(2);
            this.cb_lang.Name = "cb_lang";
            this.cb_lang.Size = new System.Drawing.Size(194, 24);
            this.cb_lang.TabIndex = 4;
            // 
            // tb_logPath
            // 
            this.tb_logPath.BackColor = System.Drawing.Color.Transparent;
            this.tb_logPath.Location = new System.Drawing.Point(128, 171);
            this.tb_logPath.MaxLength = 32767;
            this.tb_logPath.Multiline = false;
            this.tb_logPath.Name = "tb_logPath";
            this.tb_logPath.ReadOnly = false;
            this.tb_logPath.Size = new System.Drawing.Size(327, 29);
            this.tb_logPath.TabIndex = 18;
            this.tb_logPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_logPath.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_logPath.UseSystemPasswordChar = false;
            // 
            // flatLabel1
            // 
            this.flatLabel1.AutoSize = true;
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel1.ForeColor = System.Drawing.Color.White;
            this.flatLabel1.Location = new System.Drawing.Point(604, 8);
            this.flatLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(89, 19);
            this.flatLabel1.TabIndex = 3;
            this.flatLabel1.Text = "Start Mode : ";
            // 
            // cb_lamaMode
            // 
            this.cb_lamaMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cb_lamaMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_lamaMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_lamaMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_lamaMode.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cb_lamaMode.ForeColor = System.Drawing.Color.White;
            this.cb_lamaMode.FormattingEnabled = true;
            this.cb_lamaMode.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cb_lamaMode.ItemHeight = 18;
            this.cb_lamaMode.Items.AddRange(new object[] {
            "Default",
            "FULL",
            "PORTABLE",
            "LITE"});
            this.cb_lamaMode.Location = new System.Drawing.Point(128, 9);
            this.cb_lamaMode.Margin = new System.Windows.Forms.Padding(2);
            this.cb_lamaMode.Name = "cb_lamaMode";
            this.cb_lamaMode.Size = new System.Drawing.Size(327, 24);
            this.cb_lamaMode.TabIndex = 6;
            // 
            // flatLabel8
            // 
            this.flatLabel8.AutoSize = true;
            this.flatLabel8.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel8.ForeColor = System.Drawing.Color.White;
            this.flatLabel8.Location = new System.Drawing.Point(8, 174);
            this.flatLabel8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.flatLabel8.Name = "flatLabel8";
            this.flatLabel8.Size = new System.Drawing.Size(71, 19);
            this.flatLabel8.TabIndex = 17;
            this.flatLabel8.Text = "Log path :";
            // 
            // flatLabel3
            // 
            this.flatLabel3.AutoSize = true;
            this.flatLabel3.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel3.ForeColor = System.Drawing.Color.White;
            this.flatLabel3.Location = new System.Drawing.Point(8, 10);
            this.flatLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.flatLabel3.Name = "flatLabel3";
            this.flatLabel3.Size = new System.Drawing.Size(52, 19);
            this.flatLabel3.TabIndex = 7;
            this.flatLabel3.Text = "Mode :";
            // 
            // cb_start
            // 
            this.cb_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cb_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_start.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_start.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_start.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cb_start.ForeColor = System.Drawing.Color.White;
            this.cb_start.FormattingEnabled = true;
            this.cb_start.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cb_start.ItemHeight = 18;
            this.cb_start.Items.AddRange(new object[] {
            "Default"});
            this.cb_start.Location = new System.Drawing.Point(702, 8);
            this.cb_start.Margin = new System.Windows.Forms.Padding(2);
            this.cb_start.Name = "cb_start";
            this.cb_start.Size = new System.Drawing.Size(194, 24);
            this.cb_start.TabIndex = 0;
            // 
            // tb_ressourcePath
            // 
            this.tb_ressourcePath.BackColor = System.Drawing.Color.Transparent;
            this.tb_ressourcePath.Location = new System.Drawing.Point(128, 138);
            this.tb_ressourcePath.MaxLength = 32767;
            this.tb_ressourcePath.Multiline = false;
            this.tb_ressourcePath.Name = "tb_ressourcePath";
            this.tb_ressourcePath.ReadOnly = false;
            this.tb_ressourcePath.Size = new System.Drawing.Size(327, 29);
            this.tb_ressourcePath.TabIndex = 16;
            this.tb_ressourcePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_ressourcePath.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_ressourcePath.UseSystemPasswordChar = false;
            // 
            // tb_serverMode
            // 
            this.tb_serverMode.BackColor = System.Drawing.Color.Transparent;
            this.tb_serverMode.Location = new System.Drawing.Point(128, 40);
            this.tb_serverMode.MaxLength = 32767;
            this.tb_serverMode.Multiline = false;
            this.tb_serverMode.Name = "tb_serverMode";
            this.tb_serverMode.ReadOnly = false;
            this.tb_serverMode.Size = new System.Drawing.Size(327, 29);
            this.tb_serverMode.TabIndex = 8;
            this.tb_serverMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_serverMode.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_serverMode.UseSystemPasswordChar = false;
            // 
            // tb_cachePath
            // 
            this.tb_cachePath.BackColor = System.Drawing.Color.Transparent;
            this.tb_cachePath.Location = new System.Drawing.Point(128, 106);
            this.tb_cachePath.MaxLength = 32767;
            this.tb_cachePath.Multiline = false;
            this.tb_cachePath.Name = "tb_cachePath";
            this.tb_cachePath.ReadOnly = false;
            this.tb_cachePath.Size = new System.Drawing.Size(327, 29);
            this.tb_cachePath.TabIndex = 15;
            this.tb_cachePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_cachePath.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_cachePath.UseSystemPasswordChar = false;
            // 
            // flatLabel4
            // 
            this.flatLabel4.AutoSize = true;
            this.flatLabel4.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel4.ForeColor = System.Drawing.Color.White;
            this.flatLabel4.Location = new System.Drawing.Point(8, 43);
            this.flatLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.flatLabel4.Name = "flatLabel4";
            this.flatLabel4.Size = new System.Drawing.Size(93, 19);
            this.flatLabel4.TabIndex = 9;
            this.flatLabel4.Text = "Server mode :";
            // 
            // tb_configPath
            // 
            this.tb_configPath.BackColor = System.Drawing.Color.Transparent;
            this.tb_configPath.Location = new System.Drawing.Point(128, 73);
            this.tb_configPath.MaxLength = 32767;
            this.tb_configPath.Multiline = false;
            this.tb_configPath.Name = "tb_configPath";
            this.tb_configPath.ReadOnly = false;
            this.tb_configPath.Size = new System.Drawing.Size(327, 29);
            this.tb_configPath.TabIndex = 14;
            this.tb_configPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_configPath.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_configPath.UseSystemPasswordChar = false;
            // 
            // flatLabel6
            // 
            this.flatLabel6.AutoSize = true;
            this.flatLabel6.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel6.ForeColor = System.Drawing.Color.White;
            this.flatLabel6.Location = new System.Drawing.Point(8, 109);
            this.flatLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.flatLabel6.Name = "flatLabel6";
            this.flatLabel6.Size = new System.Drawing.Size(85, 19);
            this.flatLabel6.TabIndex = 11;
            this.flatLabel6.Text = "Cache Path :";
            // 
            // flatLabel7
            // 
            this.flatLabel7.AutoSize = true;
            this.flatLabel7.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel7.ForeColor = System.Drawing.Color.White;
            this.flatLabel7.Location = new System.Drawing.Point(8, 141);
            this.flatLabel7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.flatLabel7.Name = "flatLabel7";
            this.flatLabel7.Size = new System.Drawing.Size(115, 19);
            this.flatLabel7.TabIndex = 12;
            this.flatLabel7.Text = "Ressources path :";
            // 
            // tp_externTools
            // 
            this.tp_externTools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tp_externTools.Controls.Add(this.b_exTool_add);
            this.tp_externTools.Controls.Add(this.flowLayoutPanel1);
            this.tp_externTools.Location = new System.Drawing.Point(4, 44);
            this.tp_externTools.Name = "tp_externTools";
            this.tp_externTools.Padding = new System.Windows.Forms.Padding(3);
            this.tp_externTools.Size = new System.Drawing.Size(902, 271);
            this.tp_externTools.TabIndex = 1;
            this.tp_externTools.Text = "External tools";
            // 
            // b_exTool_add
            // 
            this.b_exTool_add.BackColor = System.Drawing.Color.Transparent;
            this.b_exTool_add.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.b_exTool_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_exTool_add.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_exTool_add.Location = new System.Drawing.Point(3, 247);
            this.b_exTool_add.Name = "b_exTool_add";
            this.b_exTool_add.Rounded = false;
            this.b_exTool_add.Size = new System.Drawing.Size(895, 21);
            this.b_exTool_add.TabIndex = 1;
            this.b_exTool_add.Text = "+";
            this.b_exTool_add.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_exTool_add.Click += new System.EventHandler(this.B_exTool_add_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(895, 238);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // b_cancel
            // 
            this.b_cancel.BackColor = System.Drawing.Color.Transparent;
            this.b_cancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.b_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_cancel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_cancel.Location = new System.Drawing.Point(8, 374);
            this.b_cancel.Margin = new System.Windows.Forms.Padding(2);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Rounded = false;
            this.b_cancel.Size = new System.Drawing.Size(74, 28);
            this.b_cancel.TabIndex = 2;
            this.b_cancel.Text = "Cancel";
            this.b_cancel.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // b_save
            // 
            this.b_save.BackColor = System.Drawing.Color.Transparent;
            this.b_save.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.b_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_save.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_save.Location = new System.Drawing.Point(829, 374);
            this.b_save.Margin = new System.Windows.Forms.Padding(2);
            this.b_save.Name = "b_save";
            this.b_save.Rounded = false;
            this.b_save.Size = new System.Drawing.Size(74, 28);
            this.b_save.TabIndex = 1;
            this.b_save.Text = "Save";
            this.b_save.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_save.Click += new System.EventHandler(this.B_save_Click);
            // 
            // ConfigSoft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 408);
            this.Controls.Add(this.formSkin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConfigSoft";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfigSoft";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.formSkin1.ResumeLayout(false);
            this.flatTabControl1.ResumeLayout(false);
            this.tp_general.ResumeLayout(false);
            this.tp_general.PerformLayout();
            this.tp_externTools.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FormSkin formSkin1;
        private FlatUITheme.FlatLabel flatLabel2;
        private FlatUITheme.FlatComboBox cb_lang;
        private FlatUITheme.FlatLabel flatLabel1;
        private FlatUITheme.FlatButton b_cancel;
        private FlatUITheme.FlatButton b_save;
        private FlatUITheme.FlatComboBox cb_start;
        private FlatUITheme.FlatTextBox tb_ressourcePath;
        private FlatUITheme.FlatTextBox tb_cachePath;
        private FlatUITheme.FlatTextBox tb_configPath;
        private FlatUITheme.FlatLabel flatLabel7;
        private FlatUITheme.FlatLabel flatLabel6;
        private FlatUITheme.FlatLabel flatLabel5;
        private FlatUITheme.FlatLabel flatLabel4;
        private FlatUITheme.FlatTextBox tb_serverMode;
        private FlatUITheme.FlatLabel flatLabel3;
        private FlatUITheme.FlatComboBox cb_lamaMode;
        private FlatUITheme.FlatTabControl flatTabControl1;
        private System.Windows.Forms.TabPage tp_general;
        private FlatUITheme.FlatTextBox tb_logPath;
        private FlatUITheme.FlatLabel flatLabel8;
        private System.Windows.Forms.TabPage tp_externTools;
        private FlatUITheme.FlatButton b_exTool_add;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}