namespace UAsecoPlugin
{
    partial class UAsecoControlBoard
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
            this.gb_stats = new FlatUITheme.FlatGroupBox();
            this.gb_userList = new FlatUITheme.FlatGroupBox();
            this.flatGroupBox3 = new FlatUITheme.FlatGroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.gb_userList.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_stats
            // 
            this.gb_stats.BackColor = System.Drawing.Color.Transparent;
            this.gb_stats.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.gb_stats.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gb_stats.Location = new System.Drawing.Point(13, 15);
            this.gb_stats.Name = "gb_stats";
            this.gb_stats.ShowText = true;
            this.gb_stats.Size = new System.Drawing.Size(240, 180);
            this.gb_stats.TabIndex = 0;
            this.gb_stats.Text = "Stats";
            // 
            // gb_userList
            // 
            this.gb_userList.BackColor = System.Drawing.Color.Transparent;
            this.gb_userList.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.gb_userList.Controls.Add(this.listBox1);
            this.gb_userList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gb_userList.Location = new System.Drawing.Point(13, 216);
            this.gb_userList.Name = "gb_userList";
            this.gb_userList.ShowText = true;
            this.gb_userList.Size = new System.Drawing.Size(277, 354);
            this.gb_userList.TabIndex = 1;
            this.gb_userList.Text = "Players";
            // 
            // flatGroupBox3
            // 
            this.flatGroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.flatGroupBox3.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.flatGroupBox3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatGroupBox3.Location = new System.Drawing.Point(626, 123);
            this.flatGroupBox3.Name = "flatGroupBox3";
            this.flatGroupBox3.ShowText = true;
            this.flatGroupBox3.Size = new System.Drawing.Size(240, 180);
            this.flatGroupBox3.TabIndex = 1;
            this.flatGroupBox3.Text = "flatGroupBox3";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(15, 47);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(242, 274);
            this.listBox1.TabIndex = 0;
            // 
            // UAsecoControlBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.flatGroupBox3);
            this.Controls.Add(this.gb_userList);
            this.Controls.Add(this.gb_stats);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "UAsecoControlBoard";
            this.Size = new System.Drawing.Size(1009, 591);
            this.gb_userList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FlatGroupBox gb_stats;
        private FlatUITheme.FlatGroupBox gb_userList;
        private System.Windows.Forms.ListBox listBox1;
        private FlatUITheme.FlatGroupBox flatGroupBox3;
    }
}
