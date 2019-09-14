namespace LamaMania.UserConstrols
{
    partial class NumericScriptSetting
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
            this.flatNumeric1 = new FlatUITheme.FlatNumeric();
            this.SuspendLayout();
            // 
            // flatLabel1
            // 
            this.flatLabel1.AutoSize = true;
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel1.ForeColor = System.Drawing.Color.White;
            this.flatLabel1.Location = new System.Drawing.Point(16, 11);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(83, 23);
            this.flatLabel1.TabIndex = 0;
            this.flatLabel1.Text = "flatLabel1";
            // 
            // flatNumeric1
            // 
            this.flatNumeric1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.flatNumeric1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.flatNumeric1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatNumeric1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatNumeric1.ForeColor = System.Drawing.Color.White;
            this.flatNumeric1.Location = new System.Drawing.Point(833, 8);
            this.flatNumeric1.Maximum = ((long)(9999999));
            this.flatNumeric1.Minimum = ((long)(0));
            this.flatNumeric1.Name = "flatNumeric1";
            this.flatNumeric1.Size = new System.Drawing.Size(217, 30);
            this.flatNumeric1.TabIndex = 1;
            this.flatNumeric1.Text = "flatNumeric1";
            this.flatNumeric1.Value = ((long)(0));
            // 
            // NumericScriptSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.Controls.Add(this.flatNumeric1);
            this.Controls.Add(this.flatLabel1);
            this.Name = "NumericScriptSetting";
            this.Size = new System.Drawing.Size(1069, 45);
            this.Load += new System.EventHandler(this.StringScriptSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlatUITheme.FlatLabel flatLabel1;
        private FlatUITheme.FlatNumeric flatNumeric1;
    }
}
