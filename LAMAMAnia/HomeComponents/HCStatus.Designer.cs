namespace LamaMania.HomeComponents
{
    partial class HCStatus
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
            this.gb_status = new FlatUITheme.FlatGroupBox();
            this.b_uasecoStop = new FlatUITheme.FlatButton();
            this.b_usaecoStart = new FlatUITheme.FlatButton();
            this.l_uaseco = new FlatUITheme.FlatLabel();
            this.b_serverStop = new FlatUITheme.FlatButton();
            this.b_xmlrpcClose = new FlatUITheme.FlatButton();
            this.b_serverStarted = new FlatUITheme.FlatButton();
            this.b_xmlrpcConnect = new FlatUITheme.FlatButton();
            this.l_server = new FlatUITheme.FlatLabel();
            this.l_xmlrpc = new FlatUITheme.FlatLabel();
            this.gb_status.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_status
            // 
            this.gb_status.BackColor = System.Drawing.Color.Transparent;
            this.gb_status.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.gb_status.Controls.Add(this.b_uasecoStop);
            this.gb_status.Controls.Add(this.b_usaecoStart);
            this.gb_status.Controls.Add(this.l_uaseco);
            this.gb_status.Controls.Add(this.b_serverStop);
            this.gb_status.Controls.Add(this.b_xmlrpcClose);
            this.gb_status.Controls.Add(this.b_serverStarted);
            this.gb_status.Controls.Add(this.b_xmlrpcConnect);
            this.gb_status.Controls.Add(this.l_server);
            this.gb_status.Controls.Add(this.l_xmlrpc);
            this.gb_status.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gb_status.Location = new System.Drawing.Point(2, 2);
            this.gb_status.Margin = new System.Windows.Forms.Padding(2);
            this.gb_status.Name = "gb_status";
            this.gb_status.ShowText = true;
            this.gb_status.Size = new System.Drawing.Size(332, 126);
            this.gb_status.TabIndex = 1;
            this.gb_status.Text = "Status";
            // 
            // b_uasecoStop
            // 
            this.b_uasecoStop.BackColor = System.Drawing.Color.Transparent;
            this.b_uasecoStop.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.b_uasecoStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_uasecoStop.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_uasecoStop.Location = new System.Drawing.Point(250, 86);
            this.b_uasecoStop.Margin = new System.Windows.Forms.Padding(2);
            this.b_uasecoStop.Name = "b_uasecoStop";
            this.b_uasecoStop.Rounded = false;
            this.b_uasecoStop.Size = new System.Drawing.Size(64, 19);
            this.b_uasecoStop.TabIndex = 8;
            this.b_uasecoStop.Text = "Stop";
            this.b_uasecoStop.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // b_usaecoStart
            // 
            this.b_usaecoStart.BackColor = System.Drawing.Color.Transparent;
            this.b_usaecoStart.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.b_usaecoStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_usaecoStart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_usaecoStart.Location = new System.Drawing.Point(179, 86);
            this.b_usaecoStart.Margin = new System.Windows.Forms.Padding(2);
            this.b_usaecoStart.Name = "b_usaecoStart";
            this.b_usaecoStart.Rounded = false;
            this.b_usaecoStart.Size = new System.Drawing.Size(64, 19);
            this.b_usaecoStart.TabIndex = 7;
            this.b_usaecoStart.Text = "Start";
            this.b_usaecoStart.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // l_uaseco
            // 
            this.l_uaseco.AutoSize = true;
            this.l_uaseco.BackColor = System.Drawing.Color.Transparent;
            this.l_uaseco.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_uaseco.ForeColor = System.Drawing.Color.White;
            this.l_uaseco.Location = new System.Drawing.Point(12, 86);
            this.l_uaseco.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_uaseco.Name = "l_uaseco";
            this.l_uaseco.Size = new System.Drawing.Size(100, 17);
            this.l_uaseco.TabIndex = 6;
            this.l_uaseco.Text = "UASECO : None";
            // 
            // b_serverStop
            // 
            this.b_serverStop.BackColor = System.Drawing.Color.Transparent;
            this.b_serverStop.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.b_serverStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_serverStop.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_serverStop.Location = new System.Drawing.Point(250, 64);
            this.b_serverStop.Margin = new System.Windows.Forms.Padding(2);
            this.b_serverStop.Name = "b_serverStop";
            this.b_serverStop.Rounded = false;
            this.b_serverStop.Size = new System.Drawing.Size(64, 19);
            this.b_serverStop.TabIndex = 5;
            this.b_serverStop.Text = "Stop";
            this.b_serverStop.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_serverStop.Click += new System.EventHandler(this.B_serverStop_Click);
            // 
            // b_xmlrpcClose
            // 
            this.b_xmlrpcClose.BackColor = System.Drawing.Color.Transparent;
            this.b_xmlrpcClose.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.b_xmlrpcClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_xmlrpcClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_xmlrpcClose.Location = new System.Drawing.Point(250, 41);
            this.b_xmlrpcClose.Margin = new System.Windows.Forms.Padding(2);
            this.b_xmlrpcClose.Name = "b_xmlrpcClose";
            this.b_xmlrpcClose.Rounded = false;
            this.b_xmlrpcClose.Size = new System.Drawing.Size(64, 19);
            this.b_xmlrpcClose.TabIndex = 4;
            this.b_xmlrpcClose.Text = "Close";
            this.b_xmlrpcClose.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // b_serverStarted
            // 
            this.b_serverStarted.BackColor = System.Drawing.Color.Transparent;
            this.b_serverStarted.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.b_serverStarted.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_serverStarted.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_serverStarted.Location = new System.Drawing.Point(179, 64);
            this.b_serverStarted.Margin = new System.Windows.Forms.Padding(2);
            this.b_serverStarted.Name = "b_serverStarted";
            this.b_serverStarted.Rounded = false;
            this.b_serverStarted.Size = new System.Drawing.Size(64, 19);
            this.b_serverStarted.TabIndex = 3;
            this.b_serverStarted.Text = "Connect";
            this.b_serverStarted.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // b_xmlrpcConnect
            // 
            this.b_xmlrpcConnect.BackColor = System.Drawing.Color.Transparent;
            this.b_xmlrpcConnect.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.b_xmlrpcConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_xmlrpcConnect.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_xmlrpcConnect.Location = new System.Drawing.Point(179, 41);
            this.b_xmlrpcConnect.Margin = new System.Windows.Forms.Padding(2);
            this.b_xmlrpcConnect.Name = "b_xmlrpcConnect";
            this.b_xmlrpcConnect.Rounded = false;
            this.b_xmlrpcConnect.Size = new System.Drawing.Size(64, 19);
            this.b_xmlrpcConnect.TabIndex = 2;
            this.b_xmlrpcConnect.Text = "Connect";
            this.b_xmlrpcConnect.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // l_server
            // 
            this.l_server.AutoSize = true;
            this.l_server.BackColor = System.Drawing.Color.Transparent;
            this.l_server.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_server.ForeColor = System.Drawing.Color.White;
            this.l_server.Location = new System.Drawing.Point(12, 64);
            this.l_server.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_server.Name = "l_server";
            this.l_server.Size = new System.Drawing.Size(103, 17);
            this.l_server.TabIndex = 1;
            this.l_server.Text = "Server : Running";
            // 
            // l_xmlrpc
            // 
            this.l_xmlrpc.AutoSize = true;
            this.l_xmlrpc.BackColor = System.Drawing.Color.Transparent;
            this.l_xmlrpc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_xmlrpc.ForeColor = System.Drawing.Color.White;
            this.l_xmlrpc.Location = new System.Drawing.Point(12, 41);
            this.l_xmlrpc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_xmlrpc.Name = "l_xmlrpc";
            this.l_xmlrpc.Size = new System.Drawing.Size(130, 17);
            this.l_xmlrpc.TabIndex = 0;
            this.l_xmlrpc.Text = "Xml-Rpc : Connected";
            // 
            // HCStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.gb_status);
            this.Name = "HCStatus";
            this.Size = new System.Drawing.Size(329, 128);
            this.gb_status.ResumeLayout(false);
            this.gb_status.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FlatGroupBox gb_status;
        private FlatUITheme.FlatButton b_uasecoStop;
        private FlatUITheme.FlatButton b_usaecoStart;
        private FlatUITheme.FlatLabel l_uaseco;
        private FlatUITheme.FlatButton b_serverStop;
        private FlatUITheme.FlatButton b_xmlrpcClose;
        private FlatUITheme.FlatButton b_serverStarted;
        private FlatUITheme.FlatButton b_xmlrpcConnect;
        private FlatUITheme.FlatLabel l_server;
        private FlatUITheme.FlatLabel l_xmlrpc;
    }
}
