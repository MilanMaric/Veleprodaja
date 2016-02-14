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
    public partial class KalkulacijaDodajForm : RootForm
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
            dgPredhodneKalkulacije.Rows.Clear();
            dgPredhodneKalkulacije.Columns.Clear();
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
            col = new DataGridViewTextBoxColumn();
            col.Name = "colNabavnaVrijednost";
            col.HeaderText = "Nabavna vrijednost";
            col.FillWeight = 70;
            dgPredhodneKalkulacije.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.Name = "colVeleprodajnaVrijednost";
            col.HeaderText = "Veleprodajna vrijednost";
            col.FillWeight = 70;
            dgPredhodneKalkulacije.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.Name = "colRazlikaUCijeni";
            col.HeaderText = "Razlika u cijeni";
            col.FillWeight = 70;
            dgPredhodneKalkulacije.Columns.Add(col);
            col = new DataGridViewButtonColumn();
            col.Name = "colIzmjena";
            col.HeaderText = "Izmjeni";
            col.FillWeight = 50;
            dgPredhodneKalkulacije.Columns.Add(col);
            col = new DataGridViewButtonColumn();
            col.Name = "colIzmjenaStavke";
            col.FillWeight = 50;
            col.HeaderText = "Izmjeni stavke";
            dgPredhodneKalkulacije.Columns.Add(col);
            dgPredhodneKalkulacije.CellContentClick += new DataGridViewCellEventHandler(dgPredhodneKalkulacijeCellContentClick);
        }

        private void dgPredhodneKalkulacijeCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                if (e.RowIndex >= 0)
                {
                    KalkulacijaDTO kalkulacija = (KalkulacijaDTO)dgPredhodneKalkulacije.Rows[e.RowIndex].Cells["colObjekat"].Value;
                    StavkaKalkulacijeDodajForm skdf = new StavkaKalkulacijeDodajForm(kalkulacija);
                    skdf.ShowDialog();
                    popuniPredhodneKalkulacije();
                }
            }
            if (e.ColumnIndex == 7)
            {
                if (e.RowIndex >= 0)
                {
                    KalkulacijaDTO kalkulacija = (KalkulacijaDTO)dgPredhodneKalkulacije.Rows[e.RowIndex].Cells["colObjekat"].Value;
                    KalkulacijaIzmjeniForm kif = new KalkulacijaIzmjeniForm(kalkulacija);
                    if (kif.ShowDialog() == DialogResult.OK)
                    {
                        popuniPredhodneKalkulacije();
                    }
                }
            }

        }

        private void popuniPredhodneKalkulacije()
        {
            dgPredhodneKalkulacije.Rows.Clear();
            listaPredhodnihKalkulacija = VeleprodajaUtil.getDAOFactory().getKalkulacijaDAO().getAll();
            foreach (KalkulacijaDTO kalkulacija in listaPredhodnihKalkulacija)
            {
                dgPredhodneKalkulacije.Rows.Add(new object[] { kalkulacija, kalkulacija.RedniBroj, kalkulacija.Datum.ToShortDateString(), kalkulacija.Partner.Naziv,kalkulacija.NetoNabavnaVrijednost,kalkulacija.VeleprodajnaVrijednost,kalkulacija.RazlikaUCijeni, "Izmjeni","Izmjeni stavke" });
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
            sk.ShowDialog();

        }
    }
}
