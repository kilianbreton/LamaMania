namespace LamaMania.HomeComponents
{
    partial class HCServerInfos
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
            this.gb_serverInfos = new FlatUITheme.FlatGroupBox();
            this.l_serverTitle = new FlatUITheme.FlatLabel();
            this.l_version = new FlatUITheme.FlatLabel();
            this.l_serverDescritpion = new FlatUITheme.FlatLabel();
            this.l_serverName = new FlatUITheme.FlatLabel();
            this.gb_serverInfos.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_serverInfos
            // 
            this.gb_serverInfos.BackColor = System.Drawing.Color.Transparent;
            this.gb_serverInfos.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.gb_serverInfos.Controls.Add(this.l_serverTitle);
            this.gb_serverInfos.Controls.Add(this.l_version);
            this.gb_serverInfos.Controls.Add(this.l_serverDescritpion);
            this.gb_serverInfos.Controls.Add(this.l_serverName);
            this.gb_serverInfos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gb_serverInfos.Location = new System.Drawing.Point(-7, -5);
            this.gb_serverInfos.Margin = new System.Windows.Forms.Padding(2);
            this.gb_serverInfos.Name = "gb_serverInfos";
            this.gb_serverInfos.ShowText = true;
            this.gb_serverInfos.Size = new System.Drawing.Size(332, 252);
            this.gb_serverInfos.TabIndex = 4;
            this.gb_serverInfos.Text = "Server Infos";
            // 
            // l_serverTitle
            // 
            this.l_serverTitle.BackColor = System.Drawing.Color.Transparent;
            this.l_serverTitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_serverTitle.ForeColor = System.Drawing.Color.White;
            this.l_serverTitle.Location = new System.Drawing.Point(14, 87);
            this.l_serverTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_serverTitle.Name = "l_serverTitle";
            this.l_serverTitle.Size = new System.Drawing.Size(299, 19);
            this.l_serverTitle.TabIndex = 5;
            this.l_serverTitle.Text = "Title :";
            // 
            // l_version
            // 
            this.l_version.AutoSize = true;
            this.l_version.BackColor = System.Drawing.Color.Transparent;
            this.l_version.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_version.ForeColor = System.Drawing.Color.White;
            this.l_version.Location = new System.Drawing.Point(14, 37);
            this.l_version.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_version.Name = "l_version";
            this.l_version.Size = new System.Drawing.Size(61, 19);
            this.l_version.TabIndex = 4;
            this.l_version.Text = "Version :";
            // 
            // l_serverDescritpion
            // 
            this.l_serverDescritpion.BackColor = System.Drawing.Color.Transparent;
            this.l_serverDescritpion.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_serverDescritpion.ForeColor = System.Drawing.Color.White;
            this.l_serverDescritpion.Location = new System.Drawing.Point(14, 110);
            this.l_serverDescritpion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_serverDescritpion.Name = "l_serverDescritpion";
            this.l_serverDescritpion.Size = new System.Drawing.Size(275, 75);
            this.l_serverDescritpion.TabIndex = 2;
            this.l_serverDescritpion.Text = "Description :";
            // 
            // l_serverName
            // 
            this.l_serverName.AutoSize = true;
            this.l_serverName.BackColor = System.Drawing.Color.Transparent;
            this.l_serverName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_serverName.ForeColor = System.Drawing.Color.White;
            this.l_serverName.Location = new System.Drawing.Point(14, 62);
            this.l_serverName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_serverName.Name = "l_serverName";
            this.l_serverName.Size = new System.Drawing.Size(52, 19);
            this.l_serverName.TabIndex = 1;
            this.l_serverName.Text = "Name :";
            // 
            // HCServerInfos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_serverInfos);
            this.Name = "HCServerInfos";
            this.Size = new System.Drawing.Size(323, 239);
            this.gb_serverInfos.ResumeLayout(false);
            this.gb_serverInfos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FlatGroupBox gb_serverInfos;
        private FlatUITheme.FlatLabel l_serverTitle;
        private FlatUITheme.FlatLabel l_version;
        private FlatUITheme.FlatLabel l_serverDescritpion;
        private FlatUITheme.FlatLabel l_serverName;
    }
}
