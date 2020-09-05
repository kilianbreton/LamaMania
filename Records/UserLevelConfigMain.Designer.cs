namespace BasicsCommandsPlugin
{
    partial class UserLevelConfigMain
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
            this.fgb_superAdmin = new FlatUITheme.FlatGroupBox();
            this.l_superAdmin = new System.Windows.Forms.ListBox();
            this.b_delSuperAdmin = new FlatUITheme.FlatButton();
            this.b_addSuperAdmin = new FlatUITheme.FlatButton();
            this.tb_superAdmin = new FlatUITheme.FlatTextBox();
            this.tb_admins = new FlatUITheme.FlatTextBox();
            this.b_addAdmin = new FlatUITheme.FlatButton();
            this.flatGroupBox1 = new FlatUITheme.FlatGroupBox();
            this.l_admins = new System.Windows.Forms.ListBox();
            this.b_delAdmins = new FlatUITheme.FlatButton();
            this.tb_moderators = new FlatUITheme.FlatTextBox();
            this.b_addModerator = new FlatUITheme.FlatButton();
            this.flatGroupBox2 = new FlatUITheme.FlatGroupBox();
            this.l_moderators = new System.Windows.Forms.ListBox();
            this.b_delModerator = new FlatUITheme.FlatButton();
            this.b_save = new FlatUITheme.FlatButton();
            this.fgb_superAdmin.SuspendLayout();
            this.flatGroupBox1.SuspendLayout();
            this.flatGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fgb_superAdmin
            // 
            this.fgb_superAdmin.BackColor = System.Drawing.Color.Transparent;
            this.fgb_superAdmin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.fgb_superAdmin.Controls.Add(this.l_superAdmin);
            this.fgb_superAdmin.Controls.Add(this.b_delSuperAdmin);
            this.fgb_superAdmin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.fgb_superAdmin.Location = new System.Drawing.Point(-1, 11);
            this.fgb_superAdmin.Name = "fgb_superAdmin";
            this.fgb_superAdmin.ShowText = true;
            this.fgb_superAdmin.Size = new System.Drawing.Size(299, 410);
            this.fgb_superAdmin.TabIndex = 2;
            this.fgb_superAdmin.Text = "MasterAdmin";
            // 
            // l_superAdmin
            // 
            this.l_superAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.l_superAdmin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.l_superAdmin.FormattingEnabled = true;
            this.l_superAdmin.ItemHeight = 17;
            this.l_superAdmin.Location = new System.Drawing.Point(25, 41);
            this.l_superAdmin.Name = "l_superAdmin";
            this.l_superAdmin.Size = new System.Drawing.Size(230, 340);
            this.l_superAdmin.TabIndex = 4;
            // 
            // b_delSuperAdmin
            // 
            this.b_delSuperAdmin.BackColor = System.Drawing.Color.Transparent;
            this.b_delSuperAdmin.BaseColor = System.Drawing.Color.Red;
            this.b_delSuperAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_delSuperAdmin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_delSuperAdmin.Location = new System.Drawing.Point(264, 42);
            this.b_delSuperAdmin.Name = "b_delSuperAdmin";
            this.b_delSuperAdmin.Rounded = false;
            this.b_delSuperAdmin.Size = new System.Drawing.Size(20, 22);
            this.b_delSuperAdmin.TabIndex = 3;
            this.b_delSuperAdmin.Text = "X";
            this.b_delSuperAdmin.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // b_addSuperAdmin
            // 
            this.b_addSuperAdmin.BackColor = System.Drawing.Color.Transparent;
            this.b_addSuperAdmin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.b_addSuperAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_addSuperAdmin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_addSuperAdmin.Location = new System.Drawing.Point(225, 416);
            this.b_addSuperAdmin.Name = "b_addSuperAdmin";
            this.b_addSuperAdmin.Rounded = false;
            this.b_addSuperAdmin.Size = new System.Drawing.Size(65, 29);
            this.b_addSuperAdmin.TabIndex = 3;
            this.b_addSuperAdmin.Text = "Add";
            this.b_addSuperAdmin.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_addSuperAdmin.Click += new System.EventHandler(this.b_addSuperAdmin_Click);
            // 
            // tb_superAdmin
            // 
            this.tb_superAdmin.BackColor = System.Drawing.Color.Transparent;
            this.tb_superAdmin.Location = new System.Drawing.Point(8, 416);
            this.tb_superAdmin.MaxLength = 32767;
            this.tb_superAdmin.Multiline = false;
            this.tb_superAdmin.Name = "tb_superAdmin";
            this.tb_superAdmin.ReadOnly = false;
            this.tb_superAdmin.Size = new System.Drawing.Size(215, 29);
            this.tb_superAdmin.TabIndex = 4;
            this.tb_superAdmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_superAdmin.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_superAdmin.UseSystemPasswordChar = false;
            // 
            // tb_admins
            // 
            this.tb_admins.BackColor = System.Drawing.Color.Transparent;
            this.tb_admins.Location = new System.Drawing.Point(305, 416);
            this.tb_admins.MaxLength = 32767;
            this.tb_admins.Multiline = false;
            this.tb_admins.Name = "tb_admins";
            this.tb_admins.ReadOnly = false;
            this.tb_admins.Size = new System.Drawing.Size(215, 29);
            this.tb_admins.TabIndex = 7;
            this.tb_admins.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_admins.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_admins.UseSystemPasswordChar = false;
            // 
            // b_addAdmin
            // 
            this.b_addAdmin.BackColor = System.Drawing.Color.Transparent;
            this.b_addAdmin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.b_addAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_addAdmin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_addAdmin.Location = new System.Drawing.Point(522, 416);
            this.b_addAdmin.Name = "b_addAdmin";
            this.b_addAdmin.Rounded = false;
            this.b_addAdmin.Size = new System.Drawing.Size(65, 29);
            this.b_addAdmin.TabIndex = 6;
            this.b_addAdmin.Text = "Add";
            this.b_addAdmin.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_addAdmin.Click += new System.EventHandler(this.b_addAdmin_Click);
            // 
            // flatGroupBox1
            // 
            this.flatGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.flatGroupBox1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.flatGroupBox1.Controls.Add(this.l_admins);
            this.flatGroupBox1.Controls.Add(this.b_delAdmins);
            this.flatGroupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatGroupBox1.Location = new System.Drawing.Point(296, 11);
            this.flatGroupBox1.Name = "flatGroupBox1";
            this.flatGroupBox1.ShowText = true;
            this.flatGroupBox1.Size = new System.Drawing.Size(299, 410);
            this.flatGroupBox1.TabIndex = 5;
            this.flatGroupBox1.Text = "Admin";
            // 
            // l_admins
            // 
            this.l_admins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.l_admins.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.l_admins.FormattingEnabled = true;
            this.l_admins.ItemHeight = 17;
            this.l_admins.Location = new System.Drawing.Point(28, 41);
            this.l_admins.Name = "l_admins";
            this.l_admins.Size = new System.Drawing.Size(230, 340);
            this.l_admins.TabIndex = 5;
            // 
            // b_delAdmins
            // 
            this.b_delAdmins.BackColor = System.Drawing.Color.Transparent;
            this.b_delAdmins.BaseColor = System.Drawing.Color.Red;
            this.b_delAdmins.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_delAdmins.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_delAdmins.Location = new System.Drawing.Point(264, 42);
            this.b_delAdmins.Name = "b_delAdmins";
            this.b_delAdmins.Rounded = false;
            this.b_delAdmins.Size = new System.Drawing.Size(20, 22);
            this.b_delAdmins.TabIndex = 3;
            this.b_delAdmins.Text = "X";
            this.b_delAdmins.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // tb_moderators
            // 
            this.tb_moderators.BackColor = System.Drawing.Color.Transparent;
            this.tb_moderators.Location = new System.Drawing.Point(603, 416);
            this.tb_moderators.MaxLength = 32767;
            this.tb_moderators.Multiline = false;
            this.tb_moderators.Name = "tb_moderators";
            this.tb_moderators.ReadOnly = false;
            this.tb_moderators.Size = new System.Drawing.Size(215, 29);
            this.tb_moderators.TabIndex = 10;
            this.tb_moderators.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_moderators.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_moderators.UseSystemPasswordChar = false;
            // 
            // b_addModerator
            // 
            this.b_addModerator.BackColor = System.Drawing.Color.Transparent;
            this.b_addModerator.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.b_addModerator.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_addModerator.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_addModerator.Location = new System.Drawing.Point(820, 416);
            this.b_addModerator.Name = "b_addModerator";
            this.b_addModerator.Rounded = false;
            this.b_addModerator.Size = new System.Drawing.Size(65, 29);
            this.b_addModerator.TabIndex = 9;
            this.b_addModerator.Text = "Add";
            this.b_addModerator.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_addModerator.Click += new System.EventHandler(this.b_addModerator_Click);
            // 
            // flatGroupBox2
            // 
            this.flatGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.flatGroupBox2.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.flatGroupBox2.Controls.Add(this.l_moderators);
            this.flatGroupBox2.Controls.Add(this.b_delModerator);
            this.flatGroupBox2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatGroupBox2.Location = new System.Drawing.Point(594, 11);
            this.flatGroupBox2.Name = "flatGroupBox2";
            this.flatGroupBox2.ShowText = true;
            this.flatGroupBox2.Size = new System.Drawing.Size(299, 410);
            this.flatGroupBox2.TabIndex = 8;
            this.flatGroupBox2.Text = "Moderators";
            // 
            // l_moderators
            // 
            this.l_moderators.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.l_moderators.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.l_moderators.FormattingEnabled = true;
            this.l_moderators.ItemHeight = 17;
            this.l_moderators.Location = new System.Drawing.Point(28, 41);
            this.l_moderators.Name = "l_moderators";
            this.l_moderators.Size = new System.Drawing.Size(230, 340);
            this.l_moderators.TabIndex = 5;
            // 
            // b_delModerator
            // 
            this.b_delModerator.BackColor = System.Drawing.Color.Transparent;
            this.b_delModerator.BaseColor = System.Drawing.Color.Red;
            this.b_delModerator.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_delModerator.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_delModerator.Location = new System.Drawing.Point(264, 42);
            this.b_delModerator.Name = "b_delModerator";
            this.b_delModerator.Rounded = false;
            this.b_delModerator.Size = new System.Drawing.Size(20, 22);
            this.b_delModerator.TabIndex = 3;
            this.b_delModerator.Text = "X";
            this.b_delModerator.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // b_save
            // 
            this.b_save.BackColor = System.Drawing.Color.Transparent;
            this.b_save.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.b_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_save.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_save.Location = new System.Drawing.Point(8, 462);
            this.b_save.Name = "b_save";
            this.b_save.Rounded = false;
            this.b_save.Size = new System.Drawing.Size(877, 21);
            this.b_save.TabIndex = 11;
            this.b_save.Text = "Save";
            this.b_save.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // UserLevelConfigMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.tb_moderators);
            this.Controls.Add(this.b_addModerator);
            this.Controls.Add(this.flatGroupBox2);
            this.Controls.Add(this.tb_admins);
            this.Controls.Add(this.b_addAdmin);
            this.Controls.Add(this.flatGroupBox1);
            this.Controls.Add(this.tb_superAdmin);
            this.Controls.Add(this.b_addSuperAdmin);
            this.Controls.Add(this.fgb_superAdmin);
            this.Name = "UserLevelConfigMain";
            this.Size = new System.Drawing.Size(903, 497);
            this.Load += new System.EventHandler(this.UserLevelConfigMain_Load);
            this.fgb_superAdmin.ResumeLayout(false);
            this.flatGroupBox1.ResumeLayout(false);
            this.flatGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FlatGroupBox fgb_superAdmin;
        private FlatUITheme.FlatButton b_delSuperAdmin;
        private FlatUITheme.FlatButton b_addSuperAdmin;
        private FlatUITheme.FlatTextBox tb_superAdmin;
        private FlatUITheme.FlatTextBox tb_admins;
        private FlatUITheme.FlatButton b_addAdmin;
        private FlatUITheme.FlatGroupBox flatGroupBox1;
        private FlatUITheme.FlatButton b_delAdmins;
        private FlatUITheme.FlatTextBox tb_moderators;
        private FlatUITheme.FlatButton b_addModerator;
        private FlatUITheme.FlatGroupBox flatGroupBox2;
        private FlatUITheme.FlatButton b_delModerator;
        private FlatUITheme.FlatButton b_save;
        private System.Windows.Forms.ListBox l_superAdmin;
        private System.Windows.Forms.ListBox l_admins;
        private System.Windows.Forms.ListBox l_moderators;
    }
}
