namespace LamaMania.HomeComponents
{
    partial class HCPlayerList
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
            this.gb_players = new FlatUITheme.FlatGroupBox();
            this.l_users = new System.Windows.Forms.ListBox();
            this.gb_players.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_players
            // 
            this.gb_players.BackColor = System.Drawing.Color.Transparent;
            this.gb_players.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.gb_players.Controls.Add(this.l_users);
            this.gb_players.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gb_players.Location = new System.Drawing.Point(-3, -2);
            this.gb_players.Margin = new System.Windows.Forms.Padding(2);
            this.gb_players.Name = "gb_players";
            this.gb_players.ShowText = true;
            this.gb_players.Size = new System.Drawing.Size(307, 231);
            this.gb_players.TabIndex = 3;
            this.gb_players.Text = "Players";
            // 
            // l_users
            // 
            this.l_users.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.l_users.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.l_users.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.l_users.FormattingEnabled = true;
            this.l_users.ItemHeight = 17;
            this.l_users.Location = new System.Drawing.Point(15, 42);
            this.l_users.Margin = new System.Windows.Forms.Padding(2);
            this.l_users.Name = "l_users";
            this.l_users.Size = new System.Drawing.Size(275, 136);
            this.l_users.TabIndex = 0;
            // 
            // HCPlayerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_players);
            this.Name = "HCPlayerList";
            this.Size = new System.Drawing.Size(301, 225);
            this.gb_players.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FlatGroupBox gb_players;
        private System.Windows.Forms.ListBox l_users;
    }
}
