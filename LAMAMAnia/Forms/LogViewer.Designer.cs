namespace LamaMania
{
    partial class LogViewer
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
            this.Logs = new FlatUITheme.FormSkin();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.b_quit = new FlatUITheme.FlatButton();
            this.Logs.SuspendLayout();
            this.SuspendLayout();
            // 
            // Logs
            // 
            this.Logs.BackColor = System.Drawing.Color.White;
            this.Logs.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.Logs.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.Logs.Controls.Add(this.b_quit);
            this.Logs.Controls.Add(this.richTextBox1);
            this.Logs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Logs.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.Logs.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Logs.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.Logs.HeaderMaximize = false;
            this.Logs.Location = new System.Drawing.Point(0, 0);
            this.Logs.Name = "Logs";
            this.Logs.Size = new System.Drawing.Size(1005, 609);
            this.Logs.TabIndex = 0;
            this.Logs.Text = "Logs";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.Location = new System.Drawing.Point(3, 53);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(999, 553);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // b_quit
            // 
            this.b_quit.BackColor = System.Drawing.Color.Transparent;
            this.b_quit.BaseColor = System.Drawing.Color.Red;
            this.b_quit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_quit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_quit.Location = new System.Drawing.Point(971, 0);
            this.b_quit.Name = "b_quit";
            this.b_quit.Rounded = false;
            this.b_quit.Size = new System.Drawing.Size(34, 24);
            this.b_quit.TabIndex = 1;
            this.b_quit.Text = "X";
            this.b_quit.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_quit.Click += new System.EventHandler(this.b_quit_Click);
            // 
            // LogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 609);
            this.Controls.Add(this.Logs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LogViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogViewer";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Logs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FormSkin Logs;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private FlatUITheme.FlatButton b_quit;
    }
}