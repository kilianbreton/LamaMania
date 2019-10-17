namespace UAsecoPlugin
{
    partial class PlayersInfos
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.flatGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flatGroupBox1
            // 
            this.flatGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.flatGroupBox1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.flatGroupBox1.Controls.Add(this.listBox1);
            this.flatGroupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatGroupBox1.Location = new System.Drawing.Point(-1, -3);
            this.flatGroupBox1.Name = "flatGroupBox1";
            this.flatGroupBox1.ShowText = true;
            this.flatGroupBox1.Size = new System.Drawing.Size(457, 488);
            this.flatGroupBox1.TabIndex = 0;
            this.flatGroupBox1.Text = "flatGroupBox1";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(24, 52);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(413, 412);
            this.listBox1.TabIndex = 0;
            // 
            // PlayersInfos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flatGroupBox1);
            this.Name = "PlayersInfos";
            this.Size = new System.Drawing.Size(453, 482);
            this.flatGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FlatGroupBox flatGroupBox1;
        private System.Windows.Forms.ListBox listBox1;
    }
}
