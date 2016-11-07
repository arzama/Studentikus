namespace Studentikus_UI
{
    partial class frm_ZaduzenjeKljuca
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DatumPreuzimanja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumVracanja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojKljuca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sprat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DatumPreuzimanja,
            this.DatumVracanja,
            this.BrojKljuca,
            this.Sprat});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(441, 344);
            this.dataGridView1.TabIndex = 0;
            // 
            // DatumPreuzimanja
            // 
            this.DatumPreuzimanja.DataPropertyName = "DatumPreuzimanja";
            this.DatumPreuzimanja.HeaderText = "Datum preuzimanja";
            this.DatumPreuzimanja.Name = "DatumPreuzimanja";
            // 
            // DatumVracanja
            // 
            this.DatumVracanja.DataPropertyName = "DatumVracanja";
            this.DatumVracanja.HeaderText = "Datum vracanja";
            this.DatumVracanja.Name = "DatumVracanja";
            // 
            // BrojKljuca
            // 
            this.BrojKljuca.DataPropertyName = "BrojKljuca";
            this.BrojKljuca.HeaderText = "Broj kljuca";
            this.BrojKljuca.Name = "BrojKljuca";
            // 
            // Sprat
            // 
            this.Sprat.DataPropertyName = "Sprat";
            this.Sprat.HeaderText = "Sprat";
            this.Sprat.Name = "Sprat";
            // 
            // frm_ZaduzenjeKljuca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 344);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frm_ZaduzenjeKljuca";
            this.Text = "Prikaz zaduženja ključeva";
            this.Load += new System.EventHandler(this.frm_ZaduzenjeKljuca_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumPreuzimanja;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumVracanja;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojKljuca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sprat;
    }
}