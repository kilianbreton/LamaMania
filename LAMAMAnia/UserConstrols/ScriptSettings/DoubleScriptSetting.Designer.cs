﻿namespace LamaMania.UserConstrols
{
    partial class DoubleScriptSetting
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.flatLabel1 = new FlatUITheme.FlatLabel();
            this.flatTextBox1 = new FlatUITheme.FlatTextBox();
            this.SuspendLayout();
            // 
            // flatLabel1
            // 
            this.flatLabel1.AutoSize = true;
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel1.ForeColor = System.Drawing.Color.White;
            this.flatLabel1.Location = new System.Drawing.Point(10, 11);
            this.flatLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(68, 19);
            this.flatLabel1.TabIndex = 0;
            this.flatLabel1.Text = "flatLabel1";
            // 
            // flatTextBox1
            // 
            this.flatTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.flatTextBox1.Location = new System.Drawing.Point(410, 6);
            this.flatTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flatTextBox1.MaxLength = 32767;
            this.flatTextBox1.Multiline = false;
            this.flatTextBox1.Name = "flatTextBox1";
            this.flatTextBox1.ReadOnly = false;
            this.flatTextBox1.Size = new System.Drawing.Size(106, 29);
            this.flatTextBox1.TabIndex = 1;
            this.flatTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.flatTextBox1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.flatTextBox1.UseSystemPasswordChar = false;
            // 
            // DoubleScriptSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.Controls.Add(this.flatTextBox1);
            this.Controls.Add(this.flatLabel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DoubleScriptSetting";
            this.Size = new System.Drawing.Size(524, 41);
            this.Load += new System.EventHandler(this.StringScriptSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlatUITheme.FlatLabel flatLabel1;
        private FlatUITheme.FlatTextBox flatTextBox1;
    }
}
