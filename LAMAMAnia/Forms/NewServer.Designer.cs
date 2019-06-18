namespace LamaMania
{
    partial class NewServer
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
            this.b_cancel = new FlatUITheme.FlatButton();
            this.b_create = new FlatUITheme.FlatButton();
            this.flatLabel4 = new FlatUITheme.FlatLabel();
            this.flatLabel3 = new FlatUITheme.FlatLabel();
            this.flatLabel2 = new FlatUITheme.FlatLabel();
            this.flatLabel1 = new FlatUITheme.FlatLabel();
            this.tb_login = new FlatUITheme.FlatTextBox();
            this.tb_port = new FlatUITheme.FlatTextBox();
            this.tb_ip = new FlatUITheme.FlatTextBox();
            this.tog_remote = new FlatUITheme.FlatToggle();
            this.tb_name = new FlatUITheme.FlatTextBox();
            this.formSkin1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formSkin1
            // 
            this.formSkin1.BackColor = System.Drawing.Color.White;
            this.formSkin1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.formSkin1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.formSkin1.Controls.Add(this.b_cancel);
            this.formSkin1.Controls.Add(this.b_create);
            this.formSkin1.Controls.Add(this.flatLabel4);
            this.formSkin1.Controls.Add(this.flatLabel3);
            this.formSkin1.Controls.Add(this.flatLabel2);
            this.formSkin1.Controls.Add(this.flatLabel1);
            this.formSkin1.Controls.Add(this.tb_login);
            this.formSkin1.Controls.Add(this.tb_port);
            this.formSkin1.Controls.Add(this.tb_ip);
            this.formSkin1.Controls.Add(this.tog_remote);
            this.formSkin1.Controls.Add(this.tb_name);
            this.formSkin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formSkin1.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.formSkin1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.formSkin1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.formSkin1.HeaderMaximize = false;
            this.formSkin1.Location = new System.Drawing.Point(0, 0);
            this.formSkin1.Name = "formSkin1";
            this.formSkin1.Size = new System.Drawing.Size(629, 308);
            this.formSkin1.TabIndex = 0;
            this.formSkin1.Text = "formSkin1";
            // 
            // b_cancel
            // 
            this.b_cancel.BackColor = System.Drawing.Color.Transparent;
            this.b_cancel.BaseColor = System.Drawing.Color.Red;
            this.b_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_cancel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_cancel.Location = new System.Drawing.Point(12, 260);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Rounded = false;
            this.b_cancel.Size = new System.Drawing.Size(106, 32);
            this.b_cancel.TabIndex = 10;
            this.b_cancel.Text = "Cancel";
            this.b_cancel.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // b_create
            // 
            this.b_create.BackColor = System.Drawing.Color.Transparent;
            this.b_create.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.b_create.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_create.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_create.Location = new System.Drawing.Point(509, 260);
            this.b_create.Name = "b_create";
            this.b_create.Rounded = false;
            this.b_create.Size = new System.Drawing.Size(106, 32);
            this.b_create.TabIndex = 9;
            this.b_create.Text = "Create";
            this.b_create.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_create.Click += new System.EventHandler(this.b_create_Click);
            // 
            // flatLabel4
            // 
            this.flatLabel4.AutoSize = true;
            this.flatLabel4.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel4.ForeColor = System.Drawing.Color.White;
            this.flatLabel4.Location = new System.Drawing.Point(12, 168);
            this.flatLabel4.Name = "flatLabel4";
            this.flatLabel4.Size = new System.Drawing.Size(69, 23);
            this.flatLabel4.TabIndex = 8;
            this.flatLabel4.Text = "IP:Port :";
            // 
            // flatLabel3
            // 
            this.flatLabel3.AutoSize = true;
            this.flatLabel3.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel3.ForeColor = System.Drawing.Color.White;
            this.flatLabel3.Location = new System.Drawing.Point(13, 212);
            this.flatLabel3.Name = "flatLabel3";
            this.flatLabel3.Size = new System.Drawing.Size(61, 23);
            this.flatLabel3.TabIndex = 7;
            this.flatLabel3.Text = "Login :";
            // 
            // flatLabel2
            // 
            this.flatLabel2.AutoSize = true;
            this.flatLabel2.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel2.ForeColor = System.Drawing.Color.White;
            this.flatLabel2.Location = new System.Drawing.Point(12, 117);
            this.flatLabel2.Name = "flatLabel2";
            this.flatLabel2.Size = new System.Drawing.Size(78, 23);
            this.flatLabel2.TabIndex = 6;
            this.flatLabel2.Text = "Remote :";
            // 
            // flatLabel1
            // 
            this.flatLabel1.AutoSize = true;
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel1.ForeColor = System.Drawing.Color.White;
            this.flatLabel1.Location = new System.Drawing.Point(12, 71);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(70, 23);
            this.flatLabel1.TabIndex = 5;
            this.flatLabel1.Text = "Name : ";
            // 
            // tb_login
            // 
            this.tb_login.BackColor = System.Drawing.Color.Transparent;
            this.tb_login.Enabled = false;
            this.tb_login.Location = new System.Drawing.Point(119, 208);
            this.tb_login.MaxLength = 32767;
            this.tb_login.Multiline = false;
            this.tb_login.Name = "tb_login";
            this.tb_login.ReadOnly = false;
            this.tb_login.Size = new System.Drawing.Size(496, 34);
            this.tb_login.TabIndex = 4;
            this.tb_login.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_login.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_login.UseSystemPasswordChar = false;
            // 
            // tb_port
            // 
            this.tb_port.BackColor = System.Drawing.Color.Transparent;
            this.tb_port.Enabled = false;
            this.tb_port.Location = new System.Drawing.Point(515, 161);
            this.tb_port.MaxLength = 32767;
            this.tb_port.Multiline = false;
            this.tb_port.Name = "tb_port";
            this.tb_port.ReadOnly = false;
            this.tb_port.Size = new System.Drawing.Size(100, 34);
            this.tb_port.TabIndex = 3;
            this.tb_port.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_port.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_port.UseSystemPasswordChar = false;
            // 
            // tb_ip
            // 
            this.tb_ip.BackColor = System.Drawing.Color.Transparent;
            this.tb_ip.Enabled = false;
            this.tb_ip.Location = new System.Drawing.Point(119, 161);
            this.tb_ip.MaxLength = 32767;
            this.tb_ip.Multiline = false;
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.ReadOnly = false;
            this.tb_ip.Size = new System.Drawing.Size(390, 34);
            this.tb_ip.TabIndex = 2;
            this.tb_ip.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_ip.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_ip.UseSystemPasswordChar = false;
            // 
            // tog_remote
            // 
            this.tog_remote.BackColor = System.Drawing.Color.Transparent;
            this.tog_remote.Checked = false;
            this.tog_remote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tog_remote.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tog_remote.Location = new System.Drawing.Point(119, 111);
            this.tog_remote.Name = "tog_remote";
            this.tog_remote.Options = FlatUITheme.FlatToggle._Options.Style1;
            this.tog_remote.Size = new System.Drawing.Size(76, 33);
            this.tog_remote.TabIndex = 1;
            this.tog_remote.Text = "flatToggle1";
            this.tog_remote.CheckedChanged += new FlatUITheme.FlatToggle.CheckedChangedEventHandler(this.tog_remote_CheckedChanged);
            // 
            // tb_name
            // 
            this.tb_name.BackColor = System.Drawing.Color.Transparent;
            this.tb_name.Location = new System.Drawing.Point(119, 64);
            this.tb_name.MaxLength = 32767;
            this.tb_name.Multiline = false;
            this.tb_name.Name = "tb_name";
            this.tb_name.ReadOnly = false;
            this.tb_name.Size = new System.Drawing.Size(496, 34);
            this.tb_name.TabIndex = 0;
            this.tb_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_name.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_name.UseSystemPasswordChar = false;
            // 
            // NewServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 308);
            this.Controls.Add(this.formSkin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewServer";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.formSkin1.ResumeLayout(false);
            this.formSkin1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FormSkin formSkin1;
        private FlatUITheme.FlatLabel flatLabel4;
        private FlatUITheme.FlatLabel flatLabel3;
        private FlatUITheme.FlatLabel flatLabel2;
        private FlatUITheme.FlatLabel flatLabel1;
        private FlatUITheme.FlatTextBox tb_login;
        private FlatUITheme.FlatTextBox tb_port;
        private FlatUITheme.FlatTextBox tb_ip;
        private FlatUITheme.FlatToggle tog_remote;
        private FlatUITheme.FlatTextBox tb_name;
        private FlatUITheme.FlatButton b_cancel;
        private FlatUITheme.FlatButton b_create;
    }
}