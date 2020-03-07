namespace LamaMania.HomeComponents
{
    partial class HCNetworkStats
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
            this.gb_netStats = new FlatUITheme.FlatGroupBox();
            this.l_sendRate = new FlatUITheme.FlatLabel();
            this.l_recvRate = new FlatUITheme.FlatLabel();
            this.l_conTimeAvg = new FlatUITheme.FlatLabel();
            this.l_nbConn = new FlatUITheme.FlatLabel();
            this.l_upTime = new FlatUITheme.FlatLabel();
            this.gb_netStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_netStats
            // 
            this.gb_netStats.BackColor = System.Drawing.Color.Transparent;
            this.gb_netStats.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.gb_netStats.Controls.Add(this.l_sendRate);
            this.gb_netStats.Controls.Add(this.l_recvRate);
            this.gb_netStats.Controls.Add(this.l_conTimeAvg);
            this.gb_netStats.Controls.Add(this.l_nbConn);
            this.gb_netStats.Controls.Add(this.l_upTime);
            this.gb_netStats.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gb_netStats.Location = new System.Drawing.Point(-7, -5);
            this.gb_netStats.Margin = new System.Windows.Forms.Padding(2);
            this.gb_netStats.Name = "gb_netStats";
            this.gb_netStats.ShowText = true;
            this.gb_netStats.Size = new System.Drawing.Size(332, 252);
            this.gb_netStats.TabIndex = 5;
            this.gb_netStats.Text = "NetworkStats";
            this.gb_netStats.Click += new System.EventHandler(this.Gb_netStats_Click);
            // 
            // l_sendRate
            // 
            this.l_sendRate.AutoSize = true;
            this.l_sendRate.BackColor = System.Drawing.Color.Transparent;
            this.l_sendRate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_sendRate.ForeColor = System.Drawing.Color.White;
            this.l_sendRate.Location = new System.Drawing.Point(16, 145);
            this.l_sendRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_sendRate.Name = "l_sendRate";
            this.l_sendRate.Size = new System.Drawing.Size(99, 17);
            this.l_sendRate.TabIndex = 9;
            this.l_sendRate.Text = "Send Net Rate :";
            // 
            // l_recvRate
            // 
            this.l_recvRate.AutoSize = true;
            this.l_recvRate.BackColor = System.Drawing.Color.Transparent;
            this.l_recvRate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_recvRate.ForeColor = System.Drawing.Color.White;
            this.l_recvRate.Location = new System.Drawing.Point(16, 119);
            this.l_recvRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_recvRate.Name = "l_recvRate";
            this.l_recvRate.Size = new System.Drawing.Size(103, 17);
            this.l_recvRate.TabIndex = 8;
            this.l_recvRate.Text = "Recive NetRate :";
            // 
            // l_conTimeAvg
            // 
            this.l_conTimeAvg.AutoSize = true;
            this.l_conTimeAvg.BackColor = System.Drawing.Color.Transparent;
            this.l_conTimeAvg.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_conTimeAvg.ForeColor = System.Drawing.Color.White;
            this.l_conTimeAvg.Location = new System.Drawing.Point(15, 93);
            this.l_conTimeAvg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_conTimeAvg.Name = "l_conTimeAvg";
            this.l_conTimeAvg.Size = new System.Drawing.Size(160, 17);
            this.l_conTimeAvg.TabIndex = 7;
            this.l_conTimeAvg.Text = "Connexion Time Average :";
            // 
            // l_nbConn
            // 
            this.l_nbConn.AutoSize = true;
            this.l_nbConn.BackColor = System.Drawing.Color.Transparent;
            this.l_nbConn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_nbConn.ForeColor = System.Drawing.Color.White;
            this.l_nbConn.Location = new System.Drawing.Point(16, 67);
            this.l_nbConn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_nbConn.Name = "l_nbConn";
            this.l_nbConn.Size = new System.Drawing.Size(108, 17);
            this.l_nbConn.TabIndex = 6;
            this.l_nbConn.Text = "Nb Connections :";
            // 
            // l_upTime
            // 
            this.l_upTime.AutoSize = true;
            this.l_upTime.BackColor = System.Drawing.Color.Transparent;
            this.l_upTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_upTime.ForeColor = System.Drawing.Color.White;
            this.l_upTime.Location = new System.Drawing.Point(16, 44);
            this.l_upTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_upTime.Name = "l_upTime";
            this.l_upTime.Size = new System.Drawing.Size(60, 17);
            this.l_upTime.TabIndex = 5;
            this.l_upTime.Text = "UpTime :";
            // 
            // HCNetworkStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_netStats);
            this.Name = "HCNetworkStats";
            this.Size = new System.Drawing.Size(318, 241);
            this.gb_netStats.ResumeLayout(false);
            this.gb_netStats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FlatGroupBox gb_netStats;
        private FlatUITheme.FlatLabel l_sendRate;
        private FlatUITheme.FlatLabel l_recvRate;
        private FlatUITheme.FlatLabel l_conTimeAvg;
        private FlatUITheme.FlatLabel l_nbConn;
        private FlatUITheme.FlatLabel l_upTime;
    }
}
