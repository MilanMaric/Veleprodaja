namespace Veleprodaja
{
    partial class RobaDodajForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxSifra = new System.Windows.Forms.TextBox();
            this.tbxNaziv = new System.Windows.Forms.TextBox();
            this.lblUspjesnoSacuvana = new System.Windows.Forms.Label();
            this.cbJedinicaMjere = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(204, 145);
            this.btnSacuvaj.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(109, 145);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Šifra robe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Naziv robe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Jedinica mjere";
            // 
            // tbxSifra
            // 
            this.tbxSifra.Location = new System.Drawing.Point(87, 22);
            this.tbxSifra.Name = "tbxSifra";
            this.tbxSifra.Size = new System.Drawing.Size(185, 20);
            this.tbxSifra.TabIndex = 5;
            // 
            // tbxNaziv
            // 
            this.tbxNaziv.Location = new System.Drawing.Point(87, 65);
            this.tbxNaziv.Name = "tbxNaziv";
            this.tbxNaziv.Size = new System.Drawing.Size(185, 20);
            this.tbxNaziv.TabIndex = 6;
            // 
            // lblUspjesnoSacuvana
            // 
            this.lblUspjesnoSacuvana.AutoSize = true;
            this.lblUspjesnoSacuvana.ForeColor = System.Drawing.Color.Lime;
            this.lblUspjesnoSacuvana.Location = new System.Drawing.Point(84, 6);
            this.lblUspjesnoSacuvana.Name = "lblUspjesnoSacuvana";
            this.lblUspjesnoSacuvana.Size = new System.Drawing.Size(139, 13);
            this.lblUspjesnoSacuvana.TabIndex = 8;
            this.lblUspjesnoSacuvana.Text = "Roba je uspjesno sacuvana";
            this.lblUspjesnoSacuvana.Visible = false;
            // 
            // cbJedinicaMjere
            // 
            this.cbJedinicaMjere.FormattingEnabled = true;
            this.cbJedinicaMjere.Location = new System.Drawing.Point(87, 111);
            this.cbJedinicaMjere.Name = "cbJedinicaMjere";
            this.cbJedinicaMjere.Size = new System.Drawing.Size(185, 21);
            this.cbJedinicaMjere.TabIndex = 9;
            // 
            // RobaDodajForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 173);
            this.Controls.Add(this.cbJedinicaMjere);
            this.Controls.Add(this.lblUspjesnoSacuvana);
            this.Controls.Add(this.tbxNaziv);
            this.Controls.Add(this.tbxSifra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RobaDodajForm";
            this.Text = "RobaDodajForm";
            this.Controls.SetChildIndex(this.btnSacuvaj, 0);
            this.Controls.SetChildIndex(this.btnOdustani, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbxSifra, 0);
            this.Controls.SetChildIndex(this.tbxNaziv, 0);
            this.Controls.SetChildIndex(this.lblUspjesnoSacuvana, 0);
            this.Controls.SetChildIndex(this.cbJedinicaMjere, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxSifra;
        private System.Windows.Forms.TextBox tbxNaziv;
        private System.Windows.Forms.Label lblUspjesnoSacuvana;
        private System.Windows.Forms.ComboBox cbJedinicaMjere;
    }
}