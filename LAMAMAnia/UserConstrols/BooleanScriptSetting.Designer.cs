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
            this.flatCheckBox1.Location = new System.Drawing.Point(13, 11);
            this.flatCheckBox1.Name = "flatCheckBox1";
            this.flatCheckBox1.Options = FlatUITheme.FlatCheckBox._Options.Style2;
            this.flatCheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flatCheckBox1.Size = new System.Drawing.Size(1053, 22);
            this.flatCheckBox1.TabIndex = 1;
            this.flatCheckBox1.Text = "flatCheckBox1";
            // 
            // BooleanScriptSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.Controls.Add(this.flatCheckBox1);
            this.Name = "BooleanScriptSetting";
            this.Size = new System.Drawing.Size(1069, 46);
            this.Load += new System.EventHandler(this.StringScriptSetting_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FlatCheckBox flatCheckBox1;
    }
}
