namespace LamaMania.UserConstrols
{
    partial class BoolMatchSetting
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
            this.flatCheckBox1 = new FlatUITheme.FlatCheckBox();
            this.SuspendLayout();
            // 
            // flatLabel1
            // 
            this.flatLabel1.AutoSize = true;
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel1.ForeColor = System.Drawing.Color.White;
            this.flatLabel1.Location = new System.Drawing.Point(9, 10);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(64, 17);
            this.flatLabel1.TabIndex = 1;
            this.flatLabel1.Text = "flatLabel1";
            // 
            // flatCheckBox1
            // 
            this.flatCheckBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.flatCheckBox1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.flatCheckBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatCheckBox1.Checked = false;
            this.flatCheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatCheckBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatCheckBox1.Location = new System.Drawing.Point(513, 7);
            this.flatCheckBox1.Name = "flatCheckBox1";
            this.flatCheckBox1.Options = FlatUITheme.FlatCheckBox._Options.Style1;
            this.flatCheckBox1.Size = new System.Drawing.Size(20, 22);
            this.flatCheckBox1.TabIndex = 2;
            // 
            // BoolMatchSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.flatCheckBox1);
            this.Controls.Add(this.flatLabel1);
            this.Name = "BoolMatchSetting";
            this.Size = new System.Drawing.Size(539, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FlatUITheme.FlatLabel flatLabel1;
        private FlatUITheme.FlatCheckBox flatCheckBox1;
    }
}
