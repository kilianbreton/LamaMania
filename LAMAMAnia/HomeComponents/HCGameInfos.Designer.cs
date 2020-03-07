namespace LamaMania.HomeComponents
{
    partial class HCGameInfos
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
            this.gb_gameInfos = new FlatUITheme.FlatGroupBox();
            this.flatButton1 = new FlatUITheme.FlatButton();
            this.b_makeNextGameMode = new FlatUITheme.FlatButton();
            this.cb_serverGMScript = new FlatUITheme.FlatComboBox();
            this.b_join = new FlatUITheme.FlatButton();
            this.b_restart = new FlatUITheme.FlatButton();
            this.l_players = new FlatUITheme.FlatLabel();
            this.b_stopRound = new FlatUITheme.FlatButton();
            this.b_prevMap = new FlatUITheme.FlatButton();
            this.b_nextMap = new FlatUITheme.FlatButton();
            this.l_map = new FlatUITheme.FlatLabel();
            this.l_gameMode = new FlatUITheme.FlatLabel();
            this.gb_gameInfos.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_gameInfos
            // 
            this.gb_gameInfos.BackColor = System.Drawing.Color.Transparent;
            this.gb_gameInfos.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.gb_gameInfos.Controls.Add(this.flatButton1);
            this.gb_gameInfos.Controls.Add(this.b_makeNextGameMode);
            this.gb_gameInfos.Controls.Add(this.cb_serverGMScript);
            this.gb_gameInfos.Controls.Add(this.b_join);
            this.gb_gameInfos.Controls.Add(this.b_restart);
            this.gb_gameInfos.Controls.Add(this.l_players);
            this.gb_gameInfos.Controls.Add(this.b_stopRound);
            this.gb_gameInfos.Controls.Add(this.b_prevMap);
            this.gb_gameInfos.Controls.Add(this.b_nextMap);
            this.gb_gameInfos.Controls.Add(this.l_map);
            this.gb_gameInfos.Controls.Add(this.l_gameMode);
            this.gb_gameInfos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gb_gameInfos.Location = new System.Drawing.Point(2, 2);
            this.gb_gameInfos.Margin = new System.Windows.Forms.Padding(2);
            this.gb_gameInfos.Name = "gb_gameInfos";
            this.gb_gameInfos.ShowText = true;
            this.gb_gameInfos.Size = new System.Drawing.Size(664, 126);
            this.gb_gameInfos.TabIndex = 2;
            this.gb_gameInfos.Text = "Game infos";
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.Color.Transparent;
            this.flatButton1.BaseColor = System.Drawing.Color.RoyalBlue;
            this.flatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatButton1.Location = new System.Drawing.Point(364, 92);
            this.flatButton1.Margin = new System.Windows.Forms.Padding(2);
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Rounded = false;
            this.flatButton1.Size = new System.Drawing.Size(187, 19);
            this.flatButton1.TabIndex = 11;
            this.flatButton1.Text = "Spectate";
            this.flatButton1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // b_makeNextGameMode
            // 
            this.b_makeNextGameMode.BackColor = System.Drawing.Color.Transparent;
            this.b_makeNextGameMode.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.b_makeNextGameMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_makeNextGameMode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_makeNextGameMode.Location = new System.Drawing.Point(555, 34);
            this.b_makeNextGameMode.Margin = new System.Windows.Forms.Padding(2);
            this.b_makeNextGameMode.Name = "b_makeNextGameMode";
            this.b_makeNextGameMode.Rounded = false;
            this.b_makeNextGameMode.Size = new System.Drawing.Size(91, 24);
            this.b_makeNextGameMode.TabIndex = 10;
            this.b_makeNextGameMode.Text = "Make next";
            this.b_makeNextGameMode.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_makeNextGameMode.Click += new System.EventHandler(this.B_makeNextGameMode_Click);
            // 
            // cb_serverGMScript
            // 
            this.cb_serverGMScript.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cb_serverGMScript.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_serverGMScript.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_serverGMScript.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_serverGMScript.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cb_serverGMScript.ForeColor = System.Drawing.Color.White;
            this.cb_serverGMScript.FormattingEnabled = true;
            this.cb_serverGMScript.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cb_serverGMScript.ItemHeight = 18;
            this.cb_serverGMScript.Location = new System.Drawing.Point(191, 34);
            this.cb_serverGMScript.Margin = new System.Windows.Forms.Padding(2);
            this.cb_serverGMScript.Name = "cb_serverGMScript";
            this.cb_serverGMScript.Size = new System.Drawing.Size(360, 24);
            this.cb_serverGMScript.TabIndex = 9;
            // 
            // b_join
            // 
            this.b_join.BackColor = System.Drawing.Color.Transparent;
            this.b_join.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.b_join.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_join.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_join.Location = new System.Drawing.Point(191, 92);
            this.b_join.Margin = new System.Windows.Forms.Padding(2);
            this.b_join.Name = "b_join";
            this.b_join.Rounded = false;
            this.b_join.Size = new System.Drawing.Size(166, 19);
            this.b_join.TabIndex = 8;
            this.b_join.Text = "Join";
            this.b_join.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // b_restart
            // 
            this.b_restart.BackColor = System.Drawing.Color.Transparent;
            this.b_restart.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.b_restart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_restart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_restart.Location = new System.Drawing.Point(276, 67);
            this.b_restart.Margin = new System.Windows.Forms.Padding(2);
            this.b_restart.Name = "b_restart";
            this.b_restart.Rounded = false;
            this.b_restart.Size = new System.Drawing.Size(81, 19);
            this.b_restart.TabIndex = 7;
            this.b_restart.Text = "Restart";
            this.b_restart.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_restart.Click += new System.EventHandler(this.B_restart_Click);
            // 
            // l_players
            // 
            this.l_players.AutoSize = true;
            this.l_players.BackColor = System.Drawing.Color.Transparent;
            this.l_players.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_players.ForeColor = System.Drawing.Color.White;
            this.l_players.Location = new System.Drawing.Point(14, 92);
            this.l_players.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_players.Name = "l_players";
            this.l_players.Size = new System.Drawing.Size(76, 15);
            this.l_players.TabIndex = 6;
            this.l_players.Text = "Players : 0/31";
            // 
            // b_stopRound
            // 
            this.b_stopRound.BackColor = System.Drawing.Color.Transparent;
            this.b_stopRound.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.b_stopRound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_stopRound.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_stopRound.Location = new System.Drawing.Point(449, 67);
            this.b_stopRound.Margin = new System.Windows.Forms.Padding(2);
            this.b_stopRound.Name = "b_stopRound";
            this.b_stopRound.Rounded = false;
            this.b_stopRound.Size = new System.Drawing.Size(102, 19);
            this.b_stopRound.TabIndex = 4;
            this.b_stopRound.Text = "Stop Round";
            this.b_stopRound.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // b_prevMap
            // 
            this.b_prevMap.BackColor = System.Drawing.Color.Transparent;
            this.b_prevMap.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.b_prevMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_prevMap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_prevMap.Location = new System.Drawing.Point(191, 67);
            this.b_prevMap.Margin = new System.Windows.Forms.Padding(2);
            this.b_prevMap.Name = "b_prevMap";
            this.b_prevMap.Rounded = false;
            this.b_prevMap.Size = new System.Drawing.Size(81, 19);
            this.b_prevMap.TabIndex = 3;
            this.b_prevMap.Text = "Previous";
            this.b_prevMap.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_prevMap.Click += new System.EventHandler(this.B_prevMap_Click);
            // 
            // b_nextMap
            // 
            this.b_nextMap.BackColor = System.Drawing.Color.Transparent;
            this.b_nextMap.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.b_nextMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_nextMap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_nextMap.Location = new System.Drawing.Point(364, 67);
            this.b_nextMap.Margin = new System.Windows.Forms.Padding(2);
            this.b_nextMap.Name = "b_nextMap";
            this.b_nextMap.Rounded = false;
            this.b_nextMap.Size = new System.Drawing.Size(81, 19);
            this.b_nextMap.TabIndex = 2;
            this.b_nextMap.Text = "Next";
            this.b_nextMap.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_nextMap.Click += new System.EventHandler(this.B_nextMap_Click);
            // 
            // l_map
            // 
            this.l_map.AutoSize = true;
            this.l_map.BackColor = System.Drawing.Color.Transparent;
            this.l_map.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_map.ForeColor = System.Drawing.Color.White;
            this.l_map.Location = new System.Drawing.Point(14, 66);
            this.l_map.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_map.Name = "l_map";
            this.l_map.Size = new System.Drawing.Size(123, 15);
            this.l_map.TabIndex = 1;
            this.l_map.Text = "Map : FUNCTECH-001";
            // 
            // l_gameMode
            // 
            this.l_gameMode.AutoSize = true;
            this.l_gameMode.BackColor = System.Drawing.Color.Transparent;
            this.l_gameMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_gameMode.ForeColor = System.Drawing.Color.White;
            this.l_gameMode.Location = new System.Drawing.Point(14, 41);
            this.l_gameMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_gameMode.Name = "l_gameMode";
            this.l_gameMode.Size = new System.Drawing.Size(138, 15);
            this.l_gameMode.TabIndex = 0;
            this.l_gameMode.Text = "GameMode : TimeAttack";
            // 
            // HCGameInfos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.gb_gameInfos);
            this.Name = "HCGameInfos";
            this.Size = new System.Drawing.Size(668, 125);
            this.gb_gameInfos.ResumeLayout(false);
            this.gb_gameInfos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FlatGroupBox gb_gameInfos;
        private FlatUITheme.FlatButton b_makeNextGameMode;
        private FlatUITheme.FlatComboBox cb_serverGMScript;
        private FlatUITheme.FlatButton b_join;
        private FlatUITheme.FlatButton b_restart;
        private FlatUITheme.FlatLabel l_players;
        private FlatUITheme.FlatButton b_stopRound;
        private FlatUITheme.FlatButton b_prevMap;
        private FlatUITheme.FlatButton b_nextMap;
        private FlatUITheme.FlatLabel l_map;
        private FlatUITheme.FlatLabel l_gameMode;
        private FlatUITheme.FlatButton flatButton1;
    }
}
