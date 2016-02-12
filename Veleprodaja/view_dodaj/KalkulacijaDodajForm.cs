using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veleprodaja.view_dodaj
{
    public partial class KalkulacijaDodajForm : WelcomeForm
    {
        public KalkulacijaDodajForm()
        {
            InitializeComponent();
            initKalkulacijaColumns();
        }

        private void initKalkulacijaColumns()
        {
            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            col.Name = "colRedniBroj";
            col.HeaderText = "Redni broj";
            col.ToolTipText = "Redni broj kalkulacije";
            col.FillWeight = 50;
            dgPredhodneKalkulacije.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.Name = "colDatum";
            col.HeaderText = "Datum";
            col.FillWeight = 50;
            dgPredhodneKalkulacije.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.Name = "colDobavljac";
            col.HeaderText = "Dobavljac";
            col.FillWeight = 200;
            dgPredhodneKalkulacije.Columns.Add(col);
            col = new DataGridViewButtonColumn();
            col.Name = "colIzmjena";
            col.HeaderText = "Izmjeni";
            col.FillWeight = 50;
            dgPredhodneKalkulacije.Columns.Add(col);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            StavkaKalkulacijeDodajForm sk = new StavkaKalkulacijeDodajForm();
            this.Hide();
            sk.ShowDialog();
            this.Show();

        }
    }
}
