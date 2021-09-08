namespace LamaMania
{
    partial class FirstStart
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
            this.l_title = new FlatUITheme.FlatLabel();
            this.flatComboBox1 = new FlatUITheme.FlatComboBox();
            this.tb_configPath = new FlatUITheme.FlatTextBox();
            this.l_configuration = new FlatUITheme.FlatLabel();
            this.l_configPath = new FlatUITheme.FlatLabel();
            this.l_serversPath = new FlatUITheme.FlatLabel();
            this.l_pluginsPath = new FlatUITheme.FlatLabel();
            this.l_ressourcesPath = new FlatUITheme.FlatLabel();
            this.tb_serversPath = new FlatUITheme.FlatTextBox();
            this.tb_pluginsPath = new FlatUITheme.FlatTextBox();
            this.tb_ressourcesPath = new FlatUITheme.FlatTextBox();
            this.flatTextBox4 = new FlatUITheme.FlatTextBox();
            this.l_logsPath = new FlatUITheme.FlatLabel();
            this.b_logsPath = new FlatUITheme.FlatButton();
            this.n_configPath = new FlatUITheme.FlatButton();
            this.b_serversPath = new FlatUITheme.FlatButton();
            this.b_pluginsPath = new FlatUITheme.FlatButton();
            this.b_ressourcesPath = new FlatUITheme.FlatButton();
            this.formSkin1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formSkin1
            // 
            this.formSkin1.BackColor = System.Drawing.Color.White;
            this.formSkin1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.formSkin1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.formSkin1.Controls.Add(this.b_ressourcesPath);
            this.formSkin1.Controls.Add(this.b_pluginsPath);
            this.formSkin1.Controls.Add(this.b_serversPath);
            this.formSkin1.Controls.Add(this.n_configPath);
            this.formSkin1.Controls.Add(this.b_logsPath);
            this.formSkin1.Controls.Add(this.l_logsPath);
            this.formSkin1.Controls.Add(this.flatTextBox4);
            this.formSkin1.Controls.Add(this.tb_ressourcesPath);
            this.formSkin1.Controls.Add(this.tb_pluginsPath);
            this.formSkin1.Controls.Add(this.tb_serversPath);
            this.formSkin1.Controls.Add(this.l_ressourcesPath);
            this.formSkin1.Controls.Add(this.l_pluginsPath);
            this.formSkin1.Controls.Add(this.l_serversPath);
            this.formSkin1.Controls.Add(this.l_configPath);
            this.formSkin1.Controls.Add(this.l_configuration);
            this.formSkin1.Controls.Add(this.tb_configPath);
            this.formSkin1.Controls.Add(this.flatComboBox1);
            this.formSkin1.Controls.Add(this.l_title);
            this.formSkin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formSkin1.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.formSkin1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.formSkin1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.formSkin1.HeaderMaximize = false;
            this.formSkin1.Location = new System.Drawing.Point(0, 0);
            this.formSkin1.Name = "formSkin1";
            this.formSkin1.Size = new System.Drawing.Size(607, 378);
            this.formSkin1.TabIndex = 0;
            this.formSkin1.Text = "LamaMania | First Start";
            // 
            // l_title
            // 
            this.l_title.AutoSize = true;
            this.l_title.BackColor = System.Drawing.Color.Transparent;
            this.l_title.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_title.ForeColor = System.Drawing.Color.White;
            this.l_title.Location = new System.Drawing.Point(178, 63);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(233, 25);
            this.l_title.TabIndex = 0;
            this.l_title.Text = "Welcome in LamaMania !";
            // 
            // flatComboBox1
            // 
            this.flatComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.flatComboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.flatComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flatComboBox1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.flatComboBox1.ForeColor = System.Drawing.Color.White;
            this.flatComboBox1.FormattingEnabled = true;
            this.flatComboBox1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatComboBox1.ItemHeight = 18;
            this.flatComboBox1.Items.AddRange(new object[] {
            "Portable",
            "Split",
            "Custom"});
            this.flatComboBox1.Location = new System.Drawing.Point(127, 108);
            this.flatComboBox1.Name = "flatComboBox1";
            this.flatComboBox1.Size = new System.Drawing.Size(468, 24);
            this.flatComboBox1.TabIndex = 1;
            // 
            // tb_configPath
            // 
            this.tb_configPath.BackColor = System.Drawing.Color.Transparent;
            this.tb_configPath.Location = new System.Drawing.Point(127, 138);
            this.tb_configPath.MaxLength = 32767;
            this.tb_configPath.Multiline = false;
            this.tb_configPath.Name = "tb_configPath";
            this.tb_configPath.ReadOnly = false;
            this.tb_configPath.Size = new System.Drawing.Size(429, 29);
            this.tb_configPath.TabIndex = 2;
            this.tb_configPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_configPath.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_configPath.UseSystemPasswordChar = false;
            // 
            // l_configuration
            // 
            this.l_configuration.AutoSize = true;
            this.l_configuration.BackColor = System.Drawing.Color.Transparent;
            this.l_configuration.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_configuration.ForeColor = System.Drawing.Color.White;
            this.l_configuration.Location = new System.Drawing.Point(12, 108);
            this.l_configuration.Name = "l_configuration";
            this.l_configuration.Size = new System.Drawing.Size(98, 17);
            this.l_configuration.TabIndex = 3;
            this.l_configuration.Text = "Configuration : ";
            // 
            // l_configPath
            // 
            this.l_configPath.AutoSize = true;
            this.l_configPath.BackColor = System.Drawing.Color.Transparent;
            this.l_configPath.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_configPath.ForeColor = System.Drawing.Color.White;
            this.l_configPath.Location = new System.Drawing.Point(12, 143);
            this.l_configPath.Name = "l_configPath";
            this.l_configPath.Size = new System.Drawing.Size(82, 17);
            this.l_configPath.TabIndex = 4;
            this.l_configPath.Text = "Config Path :";
            // 
            // l_serversPath
            // 
            this.l_serversPath.AutoSize = true;
            this.l_serversPath.BackColor = System.Drawing.Color.Transparent;
            this.l_serversPath.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_serversPath.ForeColor = System.Drawing.Color.White;
            this.l_serversPath.Location = new System.Drawing.Point(12, 176);
            this.l_serversPath.Name = "l_serversPath";
            this.l_serversPath.Size = new System.Drawing.Size(87, 17);
            this.l_serversPath.TabIndex = 5;
            this.l_serversPath.Text = "Servers Path :";
            // 
            // l_pluginsPath
            // 
            this.l_pluginsPath.AutoSize = true;
            this.l_pluginsPath.BackColor = System.Drawing.Color.Transparent;
            this.l_pluginsPath.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_pluginsPath.ForeColor = System.Drawing.Color.White;
            this.l_pluginsPath.Location = new System.Drawing.Point(12, 211);
            this.l_pluginsPath.Name = "l_pluginsPath";
            this.l_pluginsPath.Size = new System.Drawing.Size(89, 17);
            this.l_pluginsPath.TabIndex = 6;
            this.l_pluginsPath.Text = "Plugins Path : ";
            // 
            // l_ressourcesPath
            // 
            this.l_ressourcesPath.AutoSize = true;
            this.l_ressourcesPath.BackColor = System.Drawing.Color.Transparent;
            this.l_ressourcesPath.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_ressourcesPath.ForeColor = System.Drawing.Color.White;
            this.l_ressourcesPath.Location = new System.Drawing.Point(12, 245);
            this.l_ressourcesPath.Name = "l_ressourcesPath";
            this.l_ressourcesPath.Size = new System.Drawing.Size(114, 17);
            this.l_ressourcesPath.TabIndex = 7;
            this.l_ressourcesPath.Text = "Ressources Path : ";
            // 
            // tb_serversPath
            // 
            this.tb_serversPath.BackColor = System.Drawing.Color.Transparent;
            this.tb_serversPath.Location = new System.Drawing.Point(127, 171);
            this.tb_serversPath.MaxLength = 32767;
            this.tb_serversPath.Multiline = false;
            this.tb_serversPath.Name = "tb_serversPath";
            this.tb_serversPath.ReadOnly = false;
            this.tb_serversPath.Size = new System.Drawing.Size(429, 29);
            this.tb_serversPath.TabIndex = 8;
            this.tb_serversPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_serversPath.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_serversPath.UseSystemPasswordChar = false;
            // 
            // tb_pluginsPath
            // 
            this.tb_pluginsPath.BackColor = System.Drawing.Color.Transparent;
            this.tb_pluginsPath.Location = new System.Drawing.Point(127, 206);
            this.tb_pluginsPath.MaxLength = 32767;
            this.tb_pluginsPath.Multiline = false;
            this.tb_pluginsPath.Name = "tb_pluginsPath";
            this.tb_pluginsPath.ReadOnly = false;
            this.tb_pluginsPath.Size = new System.Drawing.Size(429, 29);
            this.tb_pluginsPath.TabIndex = 9;
            this.tb_pluginsPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_pluginsPath.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_pluginsPath.UseSystemPasswordChar = false;
            // 
            // tb_ressourcesPath
            // 
            this.tb_ressourcesPath.BackColor = System.Drawing.Color.Transparent;
            this.tb_ressourcesPath.Location = new System.Drawing.Point(127, 241);
            this.tb_ressourcesPath.MaxLength = 32767;
            this.tb_ressourcesPath.Multiline = false;
            this.tb_ressourcesPath.Name = "tb_ressourcesPath";
            this.tb_ressourcesPath.ReadOnly = false;
            this.tb_ressourcesPath.Size = new System.Drawing.Size(429, 29);
            this.tb_ressourcesPath.TabIndex = 10;
            this.tb_ressourcesPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_ressourcesPath.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_ressourcesPath.UseSystemPasswordChar = false;
            // 
            // flatTextBox4
            // 
            this.flatTextBox4.BackColor = System.Drawing.Color.Transparent;
            this.flatTextBox4.Location = new System.Drawing.Point(127, 276);
            this.flatTextBox4.MaxLength = 32767;
            this.flatTextBox4.Multiline = false;
            this.flatTextBox4.Name = "flatTextBox4";
            this.flatTextBox4.ReadOnly = false;
            this.flatTextBox4.Size = new System.Drawing.Size(429, 29);
            this.flatTextBox4.TabIndex = 11;
            this.flatTextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.flatTextBox4.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.flatTextBox4.UseSystemPasswordChar = false;
            // 
            // l_logsPath
            // 
            this.l_logsPath.AutoSize = true;
            this.l_logsPath.BackColor = System.Drawing.Color.Transparent;
            this.l_logsPath.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_logsPath.ForeColor = System.Drawing.Color.White;
            this.l_logsPath.Location = new System.Drawing.Point(12, 281);
            this.l_logsPath.Name = "l_logsPath";
            this.l_logsPath.Size = new System.Drawing.Size(72, 17);
            this.l_logsPath.TabIndex = 12;
            this.l_logsPath.Text = "Logs Path :";
            // 
            // b_logsPath
            // 
            this.b_logsPath.BackColor = System.Drawing.Color.Transparent;
            this.b_logsPath.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.b_logsPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_logsPath.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_logsPath.Location = new System.Drawing.Point(562, 276);
            this.b_logsPath.Name = "b_logsPath";
            this.b_logsPath.Rounded = false;
            this.b_logsPath.Size = new System.Drawing.Size(33, 29);
            this.b_logsPath.TabIndex = 13;
            this.b_logsPath.Text = "...";
            this.b_logsPath.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // n_configPath
            // 
            this.n_configPath.BackColor = System.Drawing.Color.Transparent;
            this.n_configPath.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.n_configPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.n_configPath.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.n_configPath.Location = new System.Drawing.Point(562, 138);
            this.n_configPath.Name = "n_configPath";
            this.n_configPath.Rounded = false;
            this.n_configPath.Size = new System.Drawing.Size(33, 29);
            this.n_configPath.TabIndex = 15;
            this.n_configPath.Text = "...";
            this.n_configPath.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // b_serversPath
            // 
            this.b_serversPath.BackColor = System.Drawing.Color.Transparent;
            this.b_serversPath.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.b_serversPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_serversPath.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_serversPath.Location = new System.Drawing.Point(562, 171);
            this.b_serversPath.Name = "b_serversPath";
            this.b_serversPath.Rounded = false;
            this.b_serversPath.Size = new System.Drawing.Size(33, 29);
            this.b_serversPath.TabIndex = 16;
            this.b_serversPath.Text = "...";
            this.b_serversPath.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // b_pluginsPath
            // 
            this.b_pluginsPath.BackColor = System.Drawing.Color.Transparent;
            this.b_pluginsPath.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.b_pluginsPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_pluginsPath.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_pluginsPath.Location = new System.Drawing.Point(562, 206);
            this.b_pluginsPath.Name = "b_pluginsPath";
            this.b_pluginsPath.Rounded = false;
            this.b_pluginsPath.Size = new System.Drawing.Size(33, 29);
            this.b_pluginsPath.TabIndex = 17;
            this.b_pluginsPath.Text = "...";
            this.b_pluginsPath.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // b_ressourcesPath
            // 
            this.b_ressourcesPath.BackColor = System.Drawing.Color.Transparent;
            this.b_ressourcesPath.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.b_ressourcesPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_ressourcesPath.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_ressourcesPath.Location = new System.Drawing.Point(562, 241);
            this.b_ressourcesPath.Name = "b_ressourcesPath";
            this.b_ressourcesPath.Rounded = false;
            this.b_ressourcesPath.Size = new System.Drawing.Size(33, 29);
            this.b_ressourcesPath.TabIndex = 18;
            this.b_ressourcesPath.Text = "...";
            this.b_ressourcesPath.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // FirstStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 378);
            this.Controls.Add(this.formSkin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FirstStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FirstStart";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.formSkin1.ResumeLayout(false);
            this.formSkin1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FormSkin formSkin1;
        private FlatUITheme.FlatButton b_ressourcesPath;
        private FlatUITheme.FlatButton b_pluginsPath;
        private FlatUITheme.FlatButton b_serversPath;
        private FlatUITheme.FlatButton n_configPath;
        private FlatUITheme.FlatButton b_logsPath;
        private FlatUITheme.FlatLabel l_logsPath;
        private FlatUITheme.FlatTextBox flatTextBox4;
        private FlatUITheme.FlatTextBox tb_ressourcesPath;
        private FlatUITheme.FlatTextBox tb_pluginsPath;
        private FlatUITheme.FlatTextBox tb_serversPath;
        private FlatUITheme.FlatLabel l_ressourcesPath;
        private FlatUITheme.FlatLabel l_pluginsPath;
        private FlatUITheme.FlatLabel l_serversPath;
        private FlatUITheme.FlatLabel l_configPath;
        private FlatUITheme.FlatLabel l_configuration;
        private FlatUITheme.FlatTextBox tb_configPath;
        private FlatUITheme.FlatComboBox flatComboBox1;
        private FlatUITheme.FlatLabel l_title;
    }
}