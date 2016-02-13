using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veleprodaja.data.dto;

namespace Veleprodaja.view_dodaj
{
    public partial class KalkulacijaDodajForm : WelcomeForm
    {
        private List<KalkulacijaDTO> listaPredhodnihKalkulacija;
        public KalkulacijaDodajForm()
        {
            InitializeComponent();
            initKalkulacijaColumns();
            popuniPredhodneKalkulacije();
            VeleprodajaUtil.initPartnerComboBox(cbDobavljac, -1);
        }

        private void initKalkulacijaColumns()
        {
            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            col.Name = "colObjekat";
            col.Visible = false;
            dgPredhodneKalkulacije.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
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
            dgPredhodneKalkulacije.CellContentClick += new DataGridViewCellEventHandler(dgPredhodneKalkulacijeCellContentClick);
        }

        private void dgPredhodneKalkulacijeCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (e.RowIndex >= 0)
                {
                    KalkulacijaDTO kalkulacija = (KalkulacijaDTO)dgPredhodneKalkulacije.Rows[e.RowIndex].Cells["colObjekat"].Value;
                    StavkaKalkulacijeDodajForm skdf = new StavkaKalkulacijeDodajForm(kalkulacija);
                    this.Hide();
                    skdf.ShowDialog();
                    this.Show();
                }
            }
        }

        private void popuniPredhodneKalkulacije()
        {
            listaPredhodnihKalkulacija = VeleprodajaUtil.getDAOFactory().getKalkulacijaDAO().getAll();
            foreach (KalkulacijaDTO kalkulacija in listaPredhodnihKalkulacija)
            {
                dgPredhodneKalkulacije.Rows.Add(new object[] { kalkulacija, kalkulacija.RedniBroj, kalkulacija.Datum, kalkulacija.Partner.Naziv, "Izmjeni" });
            }
        }

        private void fillObject(KalkulacijaDTO kalkulacija)
        {
            kalkulacija.PoslovnaGodina = VeleprodajaUtil.PoslovnaGodina;
            kalkulacija.BrojFaktureDobavljaca = tbxBrojFaktureDobavljaca.Text;
            kalkulacija.Partner = (PartnerDTO)cbDobavljac.Items[cbDobavljac.SelectedIndex];
            kalkulacija.Datum = dtpDatumKalkulacije.Value;
        }

        private KalkulacijaDTO insertKalkulacija()
        {
            KalkulacijaDTO kalkulacija = new KalkulacijaDTO();
            fillObject(kalkulacija);
            VeleprodajaUtil.getDAOFactory().getKalkulacijaDAO().insert(kalkulacija);
            return kalkulacija;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            StavkaKalkulacijeDodajForm sk = new StavkaKalkulacijeDodajForm(insertKalkulacija());
            this.Hide();
            sk.ShowDialog();
            this.Show();

        }
    }
}
