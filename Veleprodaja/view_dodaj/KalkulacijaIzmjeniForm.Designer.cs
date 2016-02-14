namespace Veleprodaja.view_dodaj
{
    partial class KalkulacijaIzmjeniForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDatumKalkulacije = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.cbDobavljac = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxBrojFaktureDobavljaca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-115, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Datum kalkulacije";
            // 
            // dtpDatumKalkulacije
            // 
            this.dtpDatumKalkulacije.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumKalkulacije.Location = new System.Drawing.Point(13, 132);
            this.dtpDatumKalkulacije.Name = "dtpDatumKalkulacije";
            this.dtpDatumKalkulacije.Size = new System.Drawing.Size(390, 20);
            this.dtpDatumKalkulacije.TabIndex = 21;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(252, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Izmjeni";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbDobavljac
            // 
            this.cbDobavljac.FormattingEnabled = true;
            this.cbDobavljac.Location = new System.Drawing.Point(13, 57);
            this.cbDobavljac.Name = "cbDobavljac";
            this.cbDobavljac.Size = new System.Drawing.Size(390, 21);
            this.cbDobavljac.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-118, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Broj fakture dobavljaca";
            // 
            // tbxBrojFaktureDobavljaca
            // 
            this.tbxBrojFaktureDobavljaca.Location = new System.Drawing.Point(13, 100);
            this.tbxBrojFaktureDobavljaca.Name = "tbxBrojFaktureDobavljaca";
            this.tbxBrojFaktureDobavljaca.Size = new System.Drawing.Size(390, 20);
            this.tbxBrojFaktureDobavljaca.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-115, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Dobavljac";
            // 
            // KalkulacijaIzmjeniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 259);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDatumKalkulacije);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbDobavljac);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxBrojFaktureDobavljaca);
            this.Controls.Add(this.label1);
            this.Name = "KalkulacijaIzmjeniForm";
            this.Text = "KalkulacijaIzmjeniForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDatumKalkulacije;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbDobavljac;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxBrojFaktureDobavljaca;
        private System.Windows.Forms.Label label1;
    }
}