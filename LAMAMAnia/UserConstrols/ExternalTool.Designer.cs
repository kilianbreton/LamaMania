namespace LamaMania.UserConstrols
{
    partial class ExternalTool
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
            this.tb_exePath = new FlatUITheme.FlatTextBox();
            this.flatLabel1 = new FlatUITheme.FlatLabel();
            this.b_browse = new FlatUITheme.FlatButton();
            this.tb_alias = new FlatUITheme.FlatTextBox();
            this.flatLabel2 = new FlatUITheme.FlatLabel();
            this.b_rm = new FlatUITheme.FlatButton();
            this.SuspendLayout();
            // 
            // tb_exePath
            // 
            this.tb_exePath.BackColor = System.Drawing.Color.Transparent;
            this.tb_exePath.Location = new System.Drawing.Point(131, 5);
            this.tb_exePath.MaxLength = 32767;
            this.tb_exePath.Multiline = false;
            this.tb_exePath.Name = "tb_exePath";
            this.tb_exePath.ReadOnly = false;
            this.tb_exePath.Size = new System.Drawing.Size(338, 29);
            this.tb_exePath.TabIndex = 0;
            this.tb_exePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_exePath.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_exePath.UseSystemPasswordChar = false;
            // 
            // flatLabel1
            // 
            this.flatLabel1.AutoSize = true;
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel1.ForeColor = System.Drawing.Color.White;
            this.flatLabel1.Location = new System.Drawing.Point(1, 6);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(125, 21);
            this.flatLabel1.TabIndex = 1;
            this.flatLabel1.Text = "Executable path :";
            // 
            // b_browse
            // 
            this.b_browse.BackColor = System.Drawing.Color.Transparent;
            this.b_browse.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.b_browse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_browse.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_browse.Location = new System.Drawing.Point(475, 6);
            this.b_browse.Name = "b_browse";
            this.b_browse.Rounded = false;
            this.b_browse.Size = new System.Drawing.Size(34, 19);
            this.b_browse.TabIndex = 2;
            this.b_browse.Text = "...";
            this.b_browse.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_browse.Click += new System.EventHandler(this.B_browse_Click);
            // 
            // tb_alias
            // 
            this.tb_alias.BackColor = System.Drawing.Color.Transparent;
            this.tb_alias.Location = new System.Drawing.Point(614, 4);
            this.tb_alias.MaxLength = 32767;
            this.tb_alias.Multiline = false;
            this.tb_alias.Name = "tb_alias";
            this.tb_alias.ReadOnly = false;
            this.tb_alias.Size = new System.Drawing.Size(81, 29);
            this.tb_alias.TabIndex = 3;
            this.tb_alias.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_alias.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_alias.UseSystemPasswordChar = false;
            // 
            // flatLabel2
            // 
            this.flatLabel2.AutoSize = true;
            this.flatLabel2.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel2.ForeColor = System.Drawing.Color.White;
            this.flatLabel2.Location = new System.Drawing.Point(554, 6);
            this.flatLabel2.Name = "flatLabel2";
            this.flatLabel2.Size = new System.Drawing.Size(54, 21);
            this.flatLabel2.TabIndex = 4;
            this.flatLabel2.Text = "Alias : ";
            // 
            // b_rm
            // 
            this.b_rm.BackColor = System.Drawing.Color.Transparent;
            this.b_rm.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.b_rm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_rm.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_rm.Location = new System.Drawing.Point(701, 5);
            this.b_rm.Name = "b_rm";
            this.b_rm.Rounded = false;
            this.b_rm.Size = new System.Drawing.Size(34, 19);
            this.b_rm.TabIndex = 5;
            this.b_rm.Text = "X";
            this.b_rm.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_rm.Click += new System.EventHandler(this.B_rm_Click);
            // 
            // ExternalTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(71)))), ((int)(((byte)(75)))));
            this.Controls.Add(this.b_rm);
            this.Controls.Add(this.flatLabel2);
            this.Controls.Add(this.tb_alias);
            this.Controls.Add(this.b_browse);
            this.Controls.Add(this.flatLabel1);
            this.Controls.Add(this.tb_exePath);
            this.Name = "ExternalTool";
            this.Size = new System.Drawing.Size(746, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlatUITheme.FlatTextBox tb_exePath;
        private FlatUITheme.FlatLabel flatLabel1;
        private FlatUITheme.FlatButton b_browse;
        private FlatUITheme.FlatTextBox tb_alias;
        private FlatUITheme.FlatLabel flatLabel2;
        private FlatUITheme.FlatButton b_rm;
    }
}
