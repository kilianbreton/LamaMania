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
            this.l_devmode = new FlatUITheme.FlatLabel();
            this.tog_devmode = new FlatUITheme.FlatToggle();
            this.l_language = new FlatUITheme.FlatLabel();
            this.cb_lang = new FlatUITheme.FlatComboBox();
            this.tb_logPath = new FlatUITheme.FlatTextBox();
            this.l_startmode = new FlatUITheme.FlatLabel();
            this.cb_lamaMode = new FlatUITheme.FlatComboBox();
            this.l_logpath = new FlatUITheme.FlatLabel();
            this.l_mode = new FlatUITheme.FlatLabel();
            this.cb_start = new FlatUITheme.FlatComboBox();
            this.tb_ressourcePath = new FlatUITheme.FlatTextBox();
            this.tb_serverMode = new FlatUITheme.FlatTextBox();
            this.tb_cachePath = new FlatUITheme.FlatTextBox();
            this.l_servermode = new FlatUITheme.FlatLabel();
            this.l_cachepath = new FlatUITheme.FlatLabel();
            this.l_ressourcepath = new FlatUITheme.FlatLabel();
            this.tp_locales = new System.Windows.Forms.TabPage();
            this.tb_pluginsDrive = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tp_externTools = new System.Windows.Forms.TabPage();
            this.b_exTool_add = new FlatUITheme.FlatButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.b_cancel = new FlatUITheme.FlatButton();
            this.b_save = new FlatUITheme.FlatButton();
            this.formSkin1.SuspendLayout();
            this.flatTabControl1.SuspendLayout();
            this.tp_general.SuspendLayout();
            this.tb_pluginsDrive.SuspendLayout();
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
            this.formSkin1.Size = new System.Drawing.Size(911, 469);
            this.formSkin1.TabIndex = 0;
            this.formSkin1.Text = "Configuration";
            // 
            // flatTabControl1
            // 
            this.flatTabControl1.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatTabControl1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.flatTabControl1.Controls.Add(this.tp_general);
            this.flatTabControl1.Controls.Add(this.tp_locales);
            this.flatTabControl1.Controls.Add(this.tb_pluginsDrive);
            this.flatTabControl1.Controls.Add(this.tp_externTools);
            this.flatTabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatTabControl1.ItemSize = new System.Drawing.Size(120, 40);
            this.flatTabControl1.Location = new System.Drawing.Point(1, 49);
            this.flatTabControl1.Name = "flatTabControl1";
            this.flatTabControl1.SelectedIndex = 0;
            this.flatTabControl1.Size = new System.Drawing.Size(910, 381);
            this.flatTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.flatTabControl1.TabIndex = 19;
            // 
            // tp_general
            // 
            this.tp_general.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tp_general.Controls.Add(this.l_devmode);
            this.tp_general.Controls.Add(this.tog_devmode);
            this.tp_general.Controls.Add(this.l_language);
            this.tp_general.Controls.Add(this.cb_lang);
            this.tp_general.Controls.Add(this.tb_logPath);
            this.tp_general.Controls.Add(this.l_startmode);
            this.tp_general.Controls.Add(this.cb_lamaMode);
            this.tp_general.Controls.Add(this.l_logpath);
            this.tp_general.Controls.Add(this.l_mode);
            this.tp_general.Controls.Add(this.cb_start);
            this.tp_general.Controls.Add(this.tb_ressourcePath);
            this.tp_general.Controls.Add(this.tb_serverMode);
            this.tp_general.Controls.Add(this.tb_cachePath);
            this.tp_general.Controls.Add(this.l_servermode);
            this.tp_general.Controls.Add(this.l_cachepath);
            this.tp_general.Controls.Add(this.l_ressourcepath);
            this.tp_general.Location = new System.Drawing.Point(4, 44);
            this.tp_general.Name = "tp_general";
            this.tp_general.Padding = new System.Windows.Forms.Padding(3);
            this.tp_general.Size = new System.Drawing.Size(902, 333);
            this.tp_general.TabIndex = 0;
            this.tp_general.Text = "General";
            // 
            // l_devmode
            // 
            this.l_devmode.AutoSize = true;
            this.l_devmode.BackColor = System.Drawing.Color.Transparent;
            this.l_devmode.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_devmode.ForeColor = System.Drawing.Color.White;
            this.l_devmode.Location = new System.Drawing.Point(734, 292);
            this.l_devmode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_devmode.Name = "l_devmode";
            this.l_devmode.Size = new System.Drawing.Size(76, 19);
            this.l_devmode.TabIndex = 20;
            this.l_devmode.Text = "DevMode :";
            // 
            // tog_devmode
            // 
            this.tog_devmode.BackColor = System.Drawing.Color.Transparent;
            this.tog_devmode.Checked = false;
            this.tog_devmode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tog_devmode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tog_devmode.Location = new System.Drawing.Point(818, 287);
            this.tog_devmode.Name = "tog_devmode";
            this.tog_devmode.Options = FlatUITheme.FlatToggle._Options.Style1;
            this.tog_devmode.Size = new System.Drawing.Size(76, 33);
            this.tog_devmode.TabIndex = 19;
            this.tog_devmode.Text = "flatToggle1";
            this.tog_devmode.CheckedChanged += new FlatUITheme.FlatToggle.CheckedChangedEventHandler(this.tog_devmode_CheckedChanged);
            // 
            // l_language
            // 
            this.l_language.AutoSize = true;
            this.l_language.BackColor = System.Drawing.Color.Transparent;
            this.l_language.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_language.ForeColor = System.Drawing.Color.White;
            this.l_language.Location = new System.Drawing.Point(604, 39);
            this.l_language.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_language.Name = "l_language";
            this.l_language.Size = new System.Drawing.Size(76, 19);
            this.l_language.TabIndex = 5;
            this.l_language.Text = "Language :";
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
            this.tb_logPath.Location = new System.Drawing.Point(128, 139);
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
            // l_startmode
            // 
            this.l_startmode.AutoSize = true;
            this.l_startmode.BackColor = System.Drawing.Color.Transparent;
            this.l_startmode.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_startmode.ForeColor = System.Drawing.Color.White;
            this.l_startmode.Location = new System.Drawing.Point(604, 8);
            this.l_startmode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_startmode.Name = "l_startmode";
            this.l_startmode.Size = new System.Drawing.Size(89, 19);
            this.l_startmode.TabIndex = 3;
            this.l_startmode.Text = "Start Mode : ";
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
            // l_logpath
            // 
            this.l_logpath.AutoSize = true;
            this.l_logpath.BackColor = System.Drawing.Color.Transparent;
            this.l_logpath.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_logpath.ForeColor = System.Drawing.Color.White;
            this.l_logpath.Location = new System.Drawing.Point(8, 142);
            this.l_logpath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_logpath.Name = "l_logpath";
            this.l_logpath.Size = new System.Drawing.Size(71, 19);
            this.l_logpath.TabIndex = 17;
            this.l_logpath.Text = "Log path :";
            // 
            // l_mode
            // 
            this.l_mode.AutoSize = true;
            this.l_mode.BackColor = System.Drawing.Color.Transparent;
            this.l_mode.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_mode.ForeColor = System.Drawing.Color.White;
            this.l_mode.Location = new System.Drawing.Point(8, 10);
            this.l_mode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_mode.Name = "l_mode";
            this.l_mode.Size = new System.Drawing.Size(52, 19);
            this.l_mode.TabIndex = 7;
            this.l_mode.Text = "Mode :";
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
            this.tb_ressourcePath.Location = new System.Drawing.Point(128, 106);
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
            this.tb_cachePath.Location = new System.Drawing.Point(128, 74);
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
            // l_servermode
            // 
            this.l_servermode.AutoSize = true;
            this.l_servermode.BackColor = System.Drawing.Color.Transparent;
            this.l_servermode.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_servermode.ForeColor = System.Drawing.Color.White;
            this.l_servermode.Location = new System.Drawing.Point(8, 43);
            this.l_servermode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_servermode.Name = "l_servermode";
            this.l_servermode.Size = new System.Drawing.Size(93, 19);
            this.l_servermode.TabIndex = 9;
            this.l_servermode.Text = "Server mode :";
            // 
            // l_cachepath
            // 
            this.l_cachepath.AutoSize = true;
            this.l_cachepath.BackColor = System.Drawing.Color.Transparent;
            this.l_cachepath.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_cachepath.ForeColor = System.Drawing.Color.White;
            this.l_cachepath.Location = new System.Drawing.Point(8, 77);
            this.l_cachepath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_cachepath.Name = "l_cachepath";
            this.l_cachepath.Size = new System.Drawing.Size(85, 19);
            this.l_cachepath.TabIndex = 11;
            this.l_cachepath.Text = "Cache Path :";
            // 
            // l_ressourcepath
            // 
            this.l_ressourcepath.AutoSize = true;
            this.l_ressourcepath.BackColor = System.Drawing.Color.Transparent;
            this.l_ressourcepath.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_ressourcepath.ForeColor = System.Drawing.Color.White;
            this.l_ressourcepath.Location = new System.Drawing.Point(8, 109);
            this.l_ressourcepath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_ressourcepath.Name = "l_ressourcepath";
            this.l_ressourcepath.Size = new System.Drawing.Size(115, 19);
            this.l_ressourcepath.TabIndex = 12;
            this.l_ressourcepath.Text = "Ressources path :";
            // 
            // tp_locales
            // 
            this.tp_locales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tp_locales.Location = new System.Drawing.Point(4, 44);
            this.tp_locales.Name = "tp_locales";
            this.tp_locales.Size = new System.Drawing.Size(902, 333);
            this.tp_locales.TabIndex = 2;
            this.tp_locales.Text = "Locales";
            // 
            // tb_pluginsDrive
            // 
            this.tb_pluginsDrive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tb_pluginsDrive.Controls.Add(this.flowLayoutPanel2);
            this.tb_pluginsDrive.Location = new System.Drawing.Point(4, 44);
            this.tb_pluginsDrive.Name = "tb_pluginsDrive";
            this.tb_pluginsDrive.Padding = new System.Windows.Forms.Padding(3);
            this.tb_pluginsDrive.Size = new System.Drawing.Size(902, 333);
            this.tb_pluginsDrive.TabIndex = 3;
            this.tb_pluginsDrive.Text = "Plugins";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(7, 6);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(889, 324);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // tp_externTools
            // 
            this.tp_externTools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tp_externTools.Controls.Add(this.b_exTool_add);
            this.tp_externTools.Controls.Add(this.flowLayoutPanel1);
            this.tp_externTools.Location = new System.Drawing.Point(4, 44);
            this.tp_externTools.Name = "tp_externTools";
            this.tp_externTools.Padding = new System.Windows.Forms.Padding(3);
            this.tp_externTools.Size = new System.Drawing.Size(902, 333);
            this.tp_externTools.TabIndex = 1;
            this.tp_externTools.Text = "External tools";
            // 
            // b_exTool_add
            // 
            this.b_exTool_add.BackColor = System.Drawing.Color.Transparent;
            this.b_exTool_add.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.b_exTool_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_exTool_add.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_exTool_add.Location = new System.Drawing.Point(3, 307);
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(895, 298);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // b_cancel
            // 
            this.b_cancel.BackColor = System.Drawing.Color.Transparent;
            this.b_cancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.b_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_cancel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_cancel.Location = new System.Drawing.Point(8, 436);
            this.b_cancel.Margin = new System.Windows.Forms.Padding(2);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Rounded = false;
            this.b_cancel.Size = new System.Drawing.Size(74, 28);
            this.b_cancel.TabIndex = 2;
            this.b_cancel.Text = "Cancel";
            this.b_cancel.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // b_save
            // 
            this.b_save.BackColor = System.Drawing.Color.Transparent;
            this.b_save.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.b_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_save.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_save.Location = new System.Drawing.Point(829, 436);
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
            this.ClientSize = new System.Drawing.Size(911, 469);
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
            this.tb_pluginsDrive.ResumeLayout(false);
            this.tp_externTools.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FormSkin formSkin1;
        private FlatUITheme.FlatLabel l_language;
        private FlatUITheme.FlatComboBox cb_lang;
        private FlatUITheme.FlatLabel l_startmode;
        private FlatUITheme.FlatButton b_cancel;
        private FlatUITheme.FlatButton b_save;
        private FlatUITheme.FlatComboBox cb_start;
        private FlatUITheme.FlatTextBox tb_ressourcePath;
        private FlatUITheme.FlatTextBox tb_cachePath;
        private FlatUITheme.FlatLabel l_ressourcepath;
        private FlatUITheme.FlatLabel l_cachepath;
        private FlatUITheme.FlatLabel l_servermode;
        private FlatUITheme.FlatTextBox tb_serverMode;
        private FlatUITheme.FlatLabel l_mode;
        private FlatUITheme.FlatComboBox cb_lamaMode;
        private FlatUITheme.FlatTabControl flatTabControl1;
        private System.Windows.Forms.TabPage tp_general;
        private FlatUITheme.FlatTextBox tb_logPath;
        private FlatUITheme.FlatLabel l_logpath;
        private System.Windows.Forms.TabPage tp_externTools;
        private FlatUITheme.FlatButton b_exTool_add;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private FlatUITheme.FlatLabel l_devmode;
        private FlatUITheme.FlatToggle tog_devmode;
        private System.Windows.Forms.TabPage tp_locales;
        private System.Windows.Forms.TabPage tb_pluginsDrive;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}