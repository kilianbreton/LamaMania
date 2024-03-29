﻿namespace LamaMania
{
    partial class HomeLauncher
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.formSkin1 = new FlatUITheme.FormSkin();
            this.b_exit = new FlatUITheme.FlatButton();
            this.flatButton5 = new FlatUITheme.FlatButton();
            this.flatButton4 = new FlatUITheme.FlatButton();
            this.flatButton3 = new FlatUITheme.FlatButton();
            this.flatButton2 = new FlatUITheme.FlatButton();
            this.flatButton1 = new FlatUITheme.FlatButton();
            this.flatComboBox1 = new FlatUITheme.FlatComboBox();
            this.b_logs = new FlatUITheme.FlatButton();
            this.formSkin1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formSkin1
            // 
            this.formSkin1.BackColor = System.Drawing.Color.White;
            this.formSkin1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.formSkin1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.formSkin1.Controls.Add(this.b_logs);
            this.formSkin1.Controls.Add(this.b_exit);
            this.formSkin1.Controls.Add(this.flatButton5);
            this.formSkin1.Controls.Add(this.flatButton4);
            this.formSkin1.Controls.Add(this.flatButton3);
            this.formSkin1.Controls.Add(this.flatButton2);
            this.formSkin1.Controls.Add(this.flatButton1);
            this.formSkin1.Controls.Add(this.flatComboBox1);
            this.formSkin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formSkin1.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.formSkin1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.formSkin1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.formSkin1.HeaderMaximize = false;
            this.formSkin1.Location = new System.Drawing.Point(0, 0);
            this.formSkin1.Margin = new System.Windows.Forms.Padding(2);
            this.formSkin1.Name = "formSkin1";
            this.formSkin1.Size = new System.Drawing.Size(461, 128);
            this.formSkin1.TabIndex = 0;
            this.formSkin1.Text = "Launcher";
            // 
            // b_exit
            // 
            this.b_exit.BackColor = System.Drawing.Color.Transparent;
            this.b_exit.BaseColor = System.Drawing.Color.Crimson;
            this.b_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_exit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_exit.Location = new System.Drawing.Point(436, 0);
            this.b_exit.Name = "b_exit";
            this.b_exit.Rounded = false;
            this.b_exit.Size = new System.Drawing.Size(25, 25);
            this.b_exit.TabIndex = 6;
            this.b_exit.Text = "X";
            this.b_exit.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_exit.Click += new System.EventHandler(this.B_exit_Click);
            // 
            // flatButton5
            // 
            this.flatButton5.BackColor = System.Drawing.Color.Transparent;
            this.flatButton5.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.flatButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flatButton5.Location = new System.Drawing.Point(361, 89);
            this.flatButton5.Name = "flatButton5";
            this.flatButton5.Rounded = false;
            this.flatButton5.Size = new System.Drawing.Size(92, 25);
            this.flatButton5.TabIndex = 5;
            this.flatButton5.Text = "Settings";
            this.flatButton5.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flatButton5.Click += new System.EventHandler(this.FlatButton5_Click);
            // 
            // flatButton4
            // 
            this.flatButton4.BackColor = System.Drawing.Color.Transparent;
            this.flatButton4.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flatButton4.Location = new System.Drawing.Point(361, 60);
            this.flatButton4.Margin = new System.Windows.Forms.Padding(2);
            this.flatButton4.Name = "flatButton4";
            this.flatButton4.Rounded = false;
            this.flatButton4.Size = new System.Drawing.Size(92, 25);
            this.flatButton4.TabIndex = 4;
            this.flatButton4.Text = "Add Server";
            this.flatButton4.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flatButton4.Click += new System.EventHandler(this.flatButton4_Click);
            // 
            // flatButton3
            // 
            this.flatButton3.BackColor = System.Drawing.Color.Transparent;
            this.flatButton3.BaseColor = System.Drawing.Color.Crimson;
            this.flatButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flatButton3.Location = new System.Drawing.Point(193, 94);
            this.flatButton3.Margin = new System.Windows.Forms.Padding(2);
            this.flatButton3.Name = "flatButton3";
            this.flatButton3.Rounded = false;
            this.flatButton3.Size = new System.Drawing.Size(52, 20);
            this.flatButton3.TabIndex = 3;
            this.flatButton3.Text = "Rm";
            this.flatButton3.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flatButton3.Click += new System.EventHandler(this.flatButton3_Click);
            // 
            // flatButton2
            // 
            this.flatButton2.BackColor = System.Drawing.Color.Transparent;
            this.flatButton2.BaseColor = System.Drawing.Color.Teal;
            this.flatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flatButton2.Location = new System.Drawing.Point(245, 94);
            this.flatButton2.Margin = new System.Windows.Forms.Padding(2);
            this.flatButton2.Name = "flatButton2";
            this.flatButton2.Rounded = false;
            this.flatButton2.Size = new System.Drawing.Size(52, 20);
            this.flatButton2.TabIndex = 2;
            this.flatButton2.Text = "Edit";
            this.flatButton2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flatButton2.Click += new System.EventHandler(this.flatButton2_Click);
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.Color.Transparent;
            this.flatButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flatButton1.Location = new System.Drawing.Point(297, 94);
            this.flatButton1.Margin = new System.Windows.Forms.Padding(2);
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Rounded = false;
            this.flatButton1.Size = new System.Drawing.Size(52, 20);
            this.flatButton1.TabIndex = 1;
            this.flatButton1.Text = "Start";
            this.flatButton1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flatButton1.Click += new System.EventHandler(this.flatButton1_Click);
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
            this.flatComboBox1.Location = new System.Drawing.Point(11, 60);
            this.flatComboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.flatComboBox1.Name = "flatComboBox1";
            this.flatComboBox1.Size = new System.Drawing.Size(339, 24);
            this.flatComboBox1.TabIndex = 0;
            // 
            // b_logs
            // 
            this.b_logs.BackColor = System.Drawing.Color.Transparent;
            this.b_logs.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.b_logs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_logs.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_logs.Location = new System.Drawing.Point(140, 94);
            this.b_logs.Name = "b_logs";
            this.b_logs.Rounded = false;
            this.b_logs.Size = new System.Drawing.Size(52, 20);
            this.b_logs.TabIndex = 7;
            this.b_logs.Text = "Logs";
            this.b_logs.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_logs.Click += new System.EventHandler(this.b_logs_Click);
            // 
            // HomeLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 128);
            this.Controls.Add(this.formSkin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HomeLauncher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.formSkin1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FormSkin formSkin1;
        private FlatUITheme.FlatButton flatButton4;
        private FlatUITheme.FlatButton flatButton3;
        private FlatUITheme.FlatButton flatButton2;
        private FlatUITheme.FlatButton flatButton1;
        private FlatUITheme.FlatComboBox flatComboBox1;
        private FlatUITheme.FlatButton flatButton5;
        private FlatUITheme.FlatButton b_exit;
        private FlatUITheme.FlatButton b_logs;
    }
}

