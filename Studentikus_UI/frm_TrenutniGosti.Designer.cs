namespace Studentikus_UI
{
    partial class frm_TrenutniGosti
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
            this.dgKorisnici = new System.Windows.Forms.DataGridView();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojSobe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sprat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgKorisnici)).BeginInit();
            this.SuspendLayout();
            // 
            // dgKorisnici
            // 
            this.dgKorisnici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgKorisnici.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ime,
            this.Prezime,
            this.BrojSobe,
            this.Sprat});
            this.dgKorisnici.Location = new System.Drawing.Point(12, 2);
            this.dgKorisnici.Name = "dgKorisnici";
            this.dgKorisnici.Size = new System.Drawing.Size(445, 150);
            this.dgKorisnici.TabIndex = 0;
            // 
            // Ime
            // 
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "Ime";
            this.Ime.Name = "Ime";
            // 
            // Prezime
            // 
            this.Prezime.DataPropertyName = "Prezime";
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.Name = "Prezime";
            // 
            // BrojSobe
            // 
            this.BrojSobe.DataPropertyName = "BrojSobe";
            this.BrojSobe.HeaderText = "Broj sobe";
            this.BrojSobe.Name = "BrojSobe";
            // 
            // Sprat
            // 
            this.Sprat.DataPropertyName = "Sprat";
            this.Sprat.HeaderText = "Sprat";
            this.Sprat.Name = "Sprat";
            // 
            // frm_TrenutniGosti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 156);
            this.Controls.Add(this.dgKorisnici);
            this.Name = "frm_TrenutniGosti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trenutni gosti u hotelu";
            this.Load += new System.EventHandler(this.frm_TrenutniGosti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgKorisnici)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgKorisnici;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojSobe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sprat;
    }
}