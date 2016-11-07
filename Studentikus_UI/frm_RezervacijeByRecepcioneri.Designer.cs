namespace Studentikus_UI
{
    partial class frm_RezervacijeByRecepcioneri
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
            this.dgRezervacije = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumPrijave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumOdjave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojSobe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxBrojeviSoba = new System.Windows.Forms.ComboBox();
            this.btnPrintaj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgRezervacije)).BeginInit();
            this.SuspendLayout();
            // 
            // dgRezervacije
            // 
            this.dgRezervacije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRezervacije.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.DatumPrijave,
            this.DatumOdjave,
            this.BrojSobe,
            this.Ime,
            this.Prezime});
            this.dgRezervacije.Location = new System.Drawing.Point(4, 42);
            this.dgRezervacije.Name = "dgRezervacije";
            this.dgRezervacije.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRezervacije.Size = new System.Drawing.Size(550, 158);
            this.dgRezervacije.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "RezervacijaId";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // DatumPrijave
            // 
            this.DatumPrijave.DataPropertyName = "DatumPrijave";
            this.DatumPrijave.HeaderText = "Datum prijave";
            this.DatumPrijave.Name = "DatumPrijave";
            // 
            // DatumOdjave
            // 
            this.DatumOdjave.DataPropertyName = "DatumOdjave";
            this.DatumOdjave.HeaderText = "Datum odjave";
            this.DatumOdjave.Name = "DatumOdjave";
            // 
            // BrojSobe
            // 
            this.BrojSobe.DataPropertyName = "BrojSobe";
            this.BrojSobe.HeaderText = "Broj sobe";
            this.BrojSobe.Name = "BrojSobe";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ime";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(219, 13);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(75, 20);
            this.txtIme.TabIndex = 2;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(469, 10);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 3;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Prezime";
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(351, 12);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(100, 20);
            this.txtPrezime.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(415, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Broj rezervacija: ";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(509, 205);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(35, 13);
            this.lblNumber.TabIndex = 7;
            this.lblNumber.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Broj sobe";
            // 
            // cbxBrojeviSoba
            // 
            this.cbxBrojeviSoba.FormattingEnabled = true;
            this.cbxBrojeviSoba.Location = new System.Drawing.Point(61, 10);
            this.cbxBrojeviSoba.Name = "cbxBrojeviSoba";
            this.cbxBrojeviSoba.Size = new System.Drawing.Size(93, 21);
            this.cbxBrojeviSoba.TabIndex = 10;
            // 
            // btnPrintaj
            // 
            this.btnPrintaj.Location = new System.Drawing.Point(78, 206);
            this.btnPrintaj.Name = "btnPrintaj";
            this.btnPrintaj.Size = new System.Drawing.Size(135, 30);
            this.btnPrintaj.TabIndex = 11;
            this.btnPrintaj.Text = "Print";
            this.btnPrintaj.UseVisualStyleBackColor = true;
            this.btnPrintaj.Click += new System.EventHandler(this.btnPrintaj_Click);
            // 
            // frm_RezervacijeByRecepcioneri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 267);
            this.Controls.Add(this.btnPrintaj);
            this.Controls.Add(this.cbxBrojeviSoba);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgRezervacije);
            this.Name = "frm_RezervacijeByRecepcioneri";
            this.Text = "Pretraga rezervacija";
            this.Load += new System.EventHandler(this.frm_RezervacijeByRecepcioneri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgRezervacije)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgRezervacije;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxBrojeviSoba;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumPrijave;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumOdjave;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojSobe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.Button btnPrintaj;
    }
}