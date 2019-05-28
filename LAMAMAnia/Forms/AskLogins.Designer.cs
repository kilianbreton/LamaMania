namespace LAMAMAnia
{
    partial class AskLogins
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
            this.tb_login = new FlatUITheme.FlatTextBox();
            this.tb_pass = new FlatUITheme.FlatTextBox();
            this.b_connect = new FlatUITheme.FlatButton();
            this.b_cancel = new FlatUITheme.FlatButton();
            this.flatLabel1 = new FlatUITheme.FlatLabel();
            this.flatLabel2 = new FlatUITheme.FlatLabel();
            this.formSkin1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formSkin1
            // 
            this.formSkin1.BackColor = System.Drawing.Color.White;
            this.formSkin1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.formSkin1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.formSkin1.Controls.Add(this.flatLabel1);
            this.formSkin1.Controls.Add(this.flatLabel2);
            this.formSkin1.Controls.Add(this.b_cancel);
            this.formSkin1.Controls.Add(this.b_connect);
            this.formSkin1.Controls.Add(this.tb_pass);
            this.formSkin1.Controls.Add(this.tb_login);
            this.formSkin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formSkin1.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.formSkin1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.formSkin1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.formSkin1.HeaderMaximize = false;
            this.formSkin1.Location = new System.Drawing.Point(0, 0);
            this.formSkin1.Name = "formSkin1";
            this.formSkin1.Size = new System.Drawing.Size(589, 242);
            this.formSkin1.TabIndex = 0;
            this.formSkin1.Text = "Set login";
            // 
            // tb_login
            // 
            this.tb_login.BackColor = System.Drawing.Color.Transparent;
            this.tb_login.Location = new System.Drawing.Point(107, 69);
            this.tb_login.MaxLength = 32767;
            this.tb_login.Multiline = false;
            this.tb_login.Name = "tb_login";
            this.tb_login.ReadOnly = false;
            this.tb_login.Size = new System.Drawing.Size(465, 34);
            this.tb_login.TabIndex = 0;
            this.tb_login.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_login.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_login.UseSystemPasswordChar = false;
            // 
            // tb_pass
            // 
            this.tb_pass.BackColor = System.Drawing.Color.Transparent;
            this.tb_pass.Location = new System.Drawing.Point(107, 131);
            this.tb_pass.MaxLength = 32767;
            this.tb_pass.Multiline = false;
            this.tb_pass.Name = "tb_pass";
            this.tb_pass.ReadOnly = false;
            this.tb_pass.Size = new System.Drawing.Size(465, 34);
            this.tb_pass.TabIndex = 1;
            this.tb_pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_pass.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_pass.UseSystemPasswordChar = true;
            // 
            // b_connect
            // 
            this.b_connect.BackColor = System.Drawing.Color.Transparent;
            this.b_connect.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.b_connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_connect.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_connect.Location = new System.Drawing.Point(466, 193);
            this.b_connect.Name = "b_connect";
            this.b_connect.Rounded = false;
            this.b_connect.Size = new System.Drawing.Size(106, 32);
            this.b_connect.TabIndex = 2;
            this.b_connect.Text = "Connect";
            this.b_connect.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_connect.Click += new System.EventHandler(this.b_connect_Click);
            // 
            // b_cancel
            // 
            this.b_cancel.BackColor = System.Drawing.Color.Transparent;
            this.b_cancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.b_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_cancel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_cancel.Location = new System.Drawing.Point(16, 193);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Rounded = false;
            this.b_cancel.Size = new System.Drawing.Size(106, 32);
            this.b_cancel.TabIndex = 3;
            this.b_cancel.Text = "Cancel";
            this.b_cancel.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // flatLabel1
            // 
            this.flatLabel1.AutoSize = true;
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel1.ForeColor = System.Drawing.Color.White;
            this.flatLabel1.Location = new System.Drawing.Point(15, 76);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(61, 23);
            this.flatLabel1.TabIndex = 1;
            this.flatLabel1.Text = "Login :";
            // 
            // flatLabel2
            // 
            this.flatLabel2.AutoSize = true;
            this.flatLabel2.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel2.ForeColor = System.Drawing.Color.White;
            this.flatLabel2.Location = new System.Drawing.Point(12, 138);
            this.flatLabel2.Name = "flatLabel2";
            this.flatLabel2.Size = new System.Drawing.Size(89, 23);
            this.flatLabel2.TabIndex = 2;
            this.flatLabel2.Text = "Password :";
            // 
            // AskLogins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 242);
            this.Controls.Add(this.formSkin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AskLogins";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AskLogins";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.formSkin1.ResumeLayout(false);
            this.formSkin1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FormSkin formSkin1;
        private FlatUITheme.FlatLabel flatLabel1;
        private FlatUITheme.FlatLabel flatLabel2;
        private FlatUITheme.FlatButton b_cancel;
        private FlatUITheme.FlatButton b_connect;
        private FlatUITheme.FlatTextBox tb_pass;
        private FlatUITheme.FlatTextBox tb_login;
    }
}