namespace LamaMania
{
    partial class LamaDialog
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
            this.b_blue = new FlatUITheme.FlatButton();
            this.b_red = new FlatUITheme.FlatButton();
            this.b_green = new FlatUITheme.FlatButton();
            this.label = new FlatUITheme.FlatLabel();
            this.alertBox = new FlatUITheme.FlatAlertBox();
            this.formSkin1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formSkin1
            // 
            this.formSkin1.BackColor = System.Drawing.Color.White;
            this.formSkin1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.formSkin1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.formSkin1.Controls.Add(this.b_blue);
            this.formSkin1.Controls.Add(this.b_red);
            this.formSkin1.Controls.Add(this.b_green);
            this.formSkin1.Controls.Add(this.label);
            this.formSkin1.Controls.Add(this.alertBox);
            this.formSkin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formSkin1.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.formSkin1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.formSkin1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.formSkin1.HeaderMaximize = false;
            this.formSkin1.Location = new System.Drawing.Point(0, 0);
            this.formSkin1.Name = "formSkin1";
            this.formSkin1.Size = new System.Drawing.Size(680, 251);
            this.formSkin1.TabIndex = 0;
            // 
            // b_blue
            // 
            this.b_blue.BackColor = System.Drawing.Color.Transparent;
            this.b_blue.BaseColor = System.Drawing.Color.DodgerBlue;
            this.b_blue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_blue.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_blue.Location = new System.Drawing.Point(284, 207);
            this.b_blue.Name = "b_blue";
            this.b_blue.Rounded = false;
            this.b_blue.Size = new System.Drawing.Size(106, 32);
            this.b_blue.TabIndex = 4;
            this.b_blue.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_blue.Visible = false;
            this.b_blue.Click += new System.EventHandler(this.b_blue_Click);
            // 
            // b_red
            // 
            this.b_red.BackColor = System.Drawing.Color.Transparent;
            this.b_red.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.b_red.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_red.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_red.Location = new System.Drawing.Point(12, 207);
            this.b_red.Name = "b_red";
            this.b_red.Rounded = false;
            this.b_red.Size = new System.Drawing.Size(106, 32);
            this.b_red.TabIndex = 3;
            this.b_red.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_red.Visible = false;
            this.b_red.Click += new System.EventHandler(this.b_red_Click);
            // 
            // b_green
            // 
            this.b_green.BackColor = System.Drawing.Color.Transparent;
            this.b_green.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.b_green.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_green.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_green.Location = new System.Drawing.Point(562, 207);
            this.b_green.Name = "b_green";
            this.b_green.Rounded = false;
            this.b_green.Size = new System.Drawing.Size(106, 32);
            this.b_green.TabIndex = 2;
            this.b_green.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_green.Visible = false;
            this.b_green.Click += new System.EventHandler(this.b_green_Click);
            // 
            // label
            // 
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(12, 104);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(656, 86);
            this.label.TabIndex = 1;
            this.label.Text = "flatLabel1";
            // 
            // alertBox
            // 
            this.alertBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.alertBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.alertBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.alertBox.kind = FlatUITheme.FlatAlertBox._Kind.Info;
            this.alertBox.Location = new System.Drawing.Point(2, 50);
            this.alertBox.Name = "alertBox";
            this.alertBox.Size = new System.Drawing.Size(714, 42);
            this.alertBox.TabIndex = 0;
            this.alertBox.Text = "Title";
            // 
            // LamaDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 251);
            this.Controls.Add(this.formSkin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LamaDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advert";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.formSkin1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FormSkin formSkin1;
        private FlatUITheme.FlatLabel label;
        private FlatUITheme.FlatAlertBox alertBox;
        private FlatUITheme.FlatButton b_blue;
        private FlatUITheme.FlatButton b_red;
        private FlatUITheme.FlatButton b_green;
    }
}