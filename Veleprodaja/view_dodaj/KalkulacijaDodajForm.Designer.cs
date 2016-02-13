namespace Veleprodaja.view_dodaj
{
    partial class KalkulacijaDodajForm
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
            this.tbxBrojFaktureDobavljaca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDobavljac = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dgPredhodneKalkulacije = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDatumKalkulacije = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgPredhodneKalkulacije)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dobavljac";
            // 
            // tbxBrojFaktureDobavljaca
            // 
            this.tbxBrojFaktureDobavljaca.Location = new System.Drawing.Point(140, 97);
            this.tbxBrojFaktureDobavljaca.Name = "tbxBrojFaktureDobavljaca";
            this.tbxBrojFaktureDobavljaca.Size = new System.Drawing.Size(390, 20);
            this.tbxBrojFaktureDobavljaca.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Broj fakture dobavljaca";
            // 
            // cbDobavljac
            // 
            this.cbDobavljac.FormattingEnabled = true;
            this.cbDobavljac.Location = new System.Drawing.Point(140, 54);
            this.cbDobavljac.Name = "cbDobavljac";
            this.cbDobavljac.Size = new System.Drawing.Size(390, 21);
            this.cbDobavljac.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(379, 177);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Dodaj stavke";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgPredhodneKalkulacije
            // 
            this.dgPredhodneKalkulacije.AllowUserToAddRows = false;
            this.dgPredhodneKalkulacije.AllowUserToDeleteRows = false;
            this.dgPredhodneKalkulacije.AllowUserToOrderColumns = true;
            this.dgPredhodneKalkulacije.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPredhodneKalkulacije.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPredhodneKalkulacije.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgPredhodneKalkulacije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPredhodneKalkulacije.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgPredhodneKalkulacije.Location = new System.Drawing.Point(12, 234);
            this.dgPredhodneKalkulacije.Name = "dgPredhodneKalkulacije";
            this.dgPredhodneKalkulacije.ReadOnly = true;
            this.dgPredhodneKalkulacije.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgPredhodneKalkulacije.RowHeadersVisible = false;
            this.dgPredhodneKalkulacije.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPredhodneKalkulacije.Size = new System.Drawing.Size(774, 269);
            this.dgPredhodneKalkulacije.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Predhodne kalkulacije:";
            // 
            // dtpDatumKalkulacije
            // 
            this.dtpDatumKalkulacije.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumKalkulacije.Location = new System.Drawing.Point(140, 129);
            this.dtpDatumKalkulacije.Name = "dtpDatumKalkulacije";
            this.dtpDatumKalkulacije.Size = new System.Drawing.Size(390, 20);
            this.dtpDatumKalkulacije.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Datum kalkulacije";
            // 
            // KalkulacijaDodajForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 515);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDatumKalkulacije);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgPredhodneKalkulacije);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbDobavljac);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxBrojFaktureDobavljaca);
            this.Controls.Add(this.label1);
            this.Name = "KalkulacijaDodajForm";
            this.Text = "KalkulacijaDodajForm";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbxBrojFaktureDobavljaca, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cbDobavljac, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.dgPredhodneKalkulacije, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.dtpDatumKalkulacije, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgPredhodneKalkulacije)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxBrojFaktureDobavljaca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDobavljac;
        private System.Windows.Forms.Button button2;
        protected System.Windows.Forms.DataGridView dgPredhodneKalkulacije;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDatumKalkulacije;
        private System.Windows.Forms.Label label3;
    }
}