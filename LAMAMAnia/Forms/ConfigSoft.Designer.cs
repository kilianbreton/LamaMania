namespace LAMAMAnia
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
            this.flatLabel2 = new FlatUITheme.FlatLabel();
            this.cb_lang = new FlatUITheme.FlatComboBox();
            this.flatLabel1 = new FlatUITheme.FlatLabel();
            this.b_cancel = new FlatUITheme.FlatButton();
            this.b_save = new FlatUITheme.FlatButton();
            this.cb_start = new FlatUITheme.FlatComboBox();
            this.formSkin1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formSkin1
            // 
            this.formSkin1.BackColor = System.Drawing.Color.White;
            this.formSkin1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.formSkin1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.formSkin1.Controls.Add(this.flatLabel2);
            this.formSkin1.Controls.Add(this.cb_lang);
            this.formSkin1.Controls.Add(this.flatLabel1);
            this.formSkin1.Controls.Add(this.b_cancel);
            this.formSkin1.Controls.Add(this.b_save);
            this.formSkin1.Controls.Add(this.cb_start);
            this.formSkin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formSkin1.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.formSkin1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.formSkin1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.formSkin1.HeaderMaximize = false;
            this.formSkin1.Location = new System.Drawing.Point(0, 0);
            this.formSkin1.Name = "formSkin1";
            this.formSkin1.Size = new System.Drawing.Size(800, 450);
            this.formSkin1.TabIndex = 0;
            this.formSkin1.Text = "Configuration";
            // 
            // flatLabel2
            // 
            this.flatLabel2.AutoSize = true;
            this.flatLabel2.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel2.ForeColor = System.Drawing.Color.White;
            this.flatLabel2.Location = new System.Drawing.Point(12, 125);
            this.flatLabel2.Name = "flatLabel2";
            this.flatLabel2.Size = new System.Drawing.Size(94, 23);
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
            this.cb_lang.Location = new System.Drawing.Point(120, 124);
            this.cb_lang.Name = "cb_lang";
            this.cb_lang.Size = new System.Drawing.Size(323, 24);
            this.cb_lang.TabIndex = 4;
            // 
            // flatLabel1
            // 
            this.flatLabel1.AutoSize = true;
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel1.ForeColor = System.Drawing.Color.White;
            this.flatLabel1.Location = new System.Drawing.Point(8, 71);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(108, 23);
            this.flatLabel1.TabIndex = 3;
            this.flatLabel1.Text = "Start Mode : ";
            // 
            // b_cancel
            // 
            this.b_cancel.BackColor = System.Drawing.Color.Transparent;
            this.b_cancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.b_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_cancel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_cancel.Location = new System.Drawing.Point(12, 400);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Rounded = false;
            this.b_cancel.Size = new System.Drawing.Size(99, 38);
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
            this.b_save.Location = new System.Drawing.Point(689, 400);
            this.b_save.Name = "b_save";
            this.b_save.Rounded = false;
            this.b_save.Size = new System.Drawing.Size(99, 38);
            this.b_save.TabIndex = 1;
            this.b_save.Text = "Save";
            this.b_save.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
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
            this.cb_start.Location = new System.Drawing.Point(120, 72);
            this.cb_start.Name = "cb_start";
            this.cb_start.Size = new System.Drawing.Size(323, 24);
            this.cb_start.TabIndex = 0;
            // 
            // ConfigSoft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.formSkin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfigSoft";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfigSoft";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.formSkin1.ResumeLayout(false);
            this.formSkin1.PerformLayout();
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
    }
}