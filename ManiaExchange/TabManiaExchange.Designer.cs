namespace ManiaExchange
{
    partial class TabManiaExchange
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dw_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dw_uid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dw_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dw_id,
            this.dw_uid,
            this.dw_name});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(899, 477);
            this.dataGridView1.TabIndex = 0;
            // 
            // dw_id
            // 
            this.dw_id.HeaderText = "ID";
            this.dw_id.Name = "dw_id";
            // 
            // dw_uid
            // 
            this.dw_uid.HeaderText = "Uid";
            this.dw_uid.Name = "dw_uid";
            // 
            // dw_name
            // 
            this.dw_name.HeaderText = "Name";
            this.dw_name.Name = "dw_name";
            // 
            // TabManiaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "TabManiaControl";
            this.Size = new System.Drawing.Size(905, 480);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dw_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dw_uid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dw_name;
    }
}
