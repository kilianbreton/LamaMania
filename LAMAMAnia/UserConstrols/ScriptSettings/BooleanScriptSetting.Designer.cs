namespace LamaMania.UserConstrols
{
    partial class BooleanScriptSetting
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
            this.flatCheckBox1 = new FlatUITheme.FlatCheckBox();
            this.flatLabel1 = new FlatUITheme.FlatLabel();
            this.SuspendLayout();
            // 
            // flatCheckBox1
            // 
            this.flatCheckBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flatCheckBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.flatCheckBox1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.flatCheckBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatCheckBox1.Checked = false;
            this.flatCheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatCheckBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatCheckBox1.Location = new System.Drawing.Point(495, 6);
            this.flatCheckBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flatCheckBox1.Name = "flatCheckBox1";
            this.flatCheckBox1.Options = FlatUITheme.FlatCheckBox._Options.Style1;
            this.flatCheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flatCheckBox1.Size = new System.Drawing.Size(27, 22);
            this.flatCheckBox1.TabIndex = 1;
            // 
            // flatLabel1
            // 
            this.flatLabel1.AutoSize = true;
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel1.ForeColor = System.Drawing.Color.White;
            this.flatLabel1.Location = new System.Drawing.Point(3, 7);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(78, 21);
            this.flatLabel1.TabIndex = 2;
            this.flatLabel1.Text = "flatLabel1";
            // 
            // BooleanScriptSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.Controls.Add(this.flatLabel1);
            this.Controls.Add(this.flatCheckBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BooleanScriptSetting";
            this.Size = new System.Drawing.Size(524, 37);
            this.Load += new System.EventHandler(this.StringScriptSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlatUITheme.FlatCheckBox flatCheckBox1;
        private FlatUITheme.FlatLabel flatLabel1;
    }
}
