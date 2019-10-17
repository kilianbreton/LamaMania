namespace UAsecoPlugin
{
    partial class MapRecords
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
            this.flatGroupBox1 = new FlatUITheme.FlatGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flatGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flatGroupBox1
            // 
            this.flatGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.flatGroupBox1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.flatGroupBox1.Controls.Add(this.label1);
            this.flatGroupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.flatGroupBox1.Name = "flatGroupBox1";
            this.flatGroupBox1.ShowText = true;
            this.flatGroupBox1.Size = new System.Drawing.Size(320, 360);
            this.flatGroupBox1.TabIndex = 0;
            this.flatGroupBox1.Text = "flatGroupBox1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // MapRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flatGroupBox1);
            this.Name = "MapRecords";
            this.Size = new System.Drawing.Size(326, 363);
            this.flatGroupBox1.ResumeLayout(false);
            this.flatGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FlatGroupBox flatGroupBox1;
        private System.Windows.Forms.Label label1;
    }
}
