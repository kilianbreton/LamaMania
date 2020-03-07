namespace BasicsCommandsPlugin
{
    partial class PluginList
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.flatGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flatGroupBox1
            // 
            this.flatGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.flatGroupBox1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.flatGroupBox1.Controls.Add(this.treeView1);
            this.flatGroupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.flatGroupBox1.Name = "flatGroupBox1";
            this.flatGroupBox1.ShowText = true;
            this.flatGroupBox1.Size = new System.Drawing.Size(312, 254);
            this.flatGroupBox1.TabIndex = 0;
            this.flatGroupBox1.Text = "flatGroupBox1";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(35, 53);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(254, 172);
            this.treeView1.TabIndex = 0;
            // 
            // PluginList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flatGroupBox1);
            this.Name = "PluginList";
            this.Size = new System.Drawing.Size(315, 257);
            this.flatGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FlatGroupBox flatGroupBox1;
        private System.Windows.Forms.TreeView treeView1;
    }
}
