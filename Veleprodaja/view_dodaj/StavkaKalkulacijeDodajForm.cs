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
    public partial class StavkaKalkulacijeDodajForm : RootForm
    {
        private KalkulacijaDTO kalkulacija = null;
        private RobaDTO izabranaRoba = null;
        private StavkaKalkulacijeDTO stavka = null;

        

        public StavkaKalkulacijeDodajForm(KalkulacijaDTO kalkulacija)
        {
            InitializeComponent();
            this.kalkulacija = kalkulacija;
            gbIzabranaRoba.Hide();
            fillKalkulacijaData();
            fillKalkulacijaValues();
            fillStavke();
        }

        private void fillStavke()
        {
            dgStavke.Rows.Clear();
            List<StavkaKalkulacijeDTO> listaStavki = VeleprodajaUtil.getDAOFactory().getStavkaKalkulacijeDAO().getByKalkulacija(kalkulacija);
            foreach (StavkaKalkulacijeDTO stavka in listaStavki)
            {
                dgStavke.Rows.Add(new object[] { stavka, stavka.Roba.Naziv, stavka.Kolicina, stavka.NabavnaCijena, stavka.Rabat, stavka.VeleprodajnaCijena, "Izmjeni" });
            }
        }

        private void fillKalkulacijaData()
        {
            lblDatumKalkulacije.Text = kalkulacija.Datum.ToShortDateString();
            lblDobavljacKalkulacije.Text = kalkulacija.Partner.ToString();
            lblRedniBrojKalkulacije.Text = kalkulacija.RedniBroj.ToString();
        }

        private void fillKalkulacijaValues()
        {
            VeleprodajaUtil.getDAOFactory().getKalkulacijaDAO().updateObjectIznos(kalkulacija);
            lblKalNabavna.Text = kalkulacija.NetoNabavnaVrijednost.ToString();
            lblKalVeleprodajni.Text = kalkulacija.VeleprodajnaVrijednost.ToString() ;
            lblKalRUC.Text = kalkulacija.RazlikaUCijeni.ToString() ;
        }

        private void fillIzabranaRobaData()
        {
            gbIzabranaRoba.Show();
            lblRobaNaziv.Text = izabranaRoba.Naziv;
            lblRobaJedinicaMjere.Text = izabranaRoba.JedinicaMjere.ToString();
            tbxSifraRobe.Text = "";
        }

        private void tbxSifraRobe_Leave(object sender, EventArgs e)
        {
            RobaPregledForm rpf = new RobaPregledForm(tbxSifraRobe.Text);
            if(rpf.ShowDialog()==DialogResult.OK)
            {
                izabranaRoba = rpf.IzabranaRoba;
                fillIzabranaRobaData();
            }

        }

        private void fillControls()
        {
            izabranaRoba = stavka.Roba;
            fillIzabranaRobaData();
            tbxKolicina.Text = stavka.Kolicina.ToString();
            tbxRabat.Text = stavka.Rabat.ToString() ;
            tbxNabavnaCijena.Text = stavka.NabavnaCijena.ToString();
            tbxVeleprodajnaCijena.Text = stavka.VeleprodajnaCijena.ToString();
        }

        private void fillObject(StavkaKalkulacijeDTO stavka)
        {
            stavka.NabavnaCijena = Convert.ToDouble(tbxNabavnaCijena.Text);
            stavka.Kolicina = Convert.ToDouble(tbxKolicina.Text);
            stavka.Rabat = Convert.ToDouble(tbxRabat.Text);
            stavka.VeleprodajnaCijena = Convert.ToDouble(tbxVeleprodajnaCijena.Text);
            stavka.Kalkulacija = kalkulacija;
            stavka.Roba = izabranaRoba;
        }

        private void emptyControlls()
        {
            tbxKolicina.Text = "";
            tbxNabavnaCijena.Text = "";
            tbxRabat.Text = "";
            tbxKolicina.Text = "";
            tbxSifraRobe.Text = "";
            tbxVeleprodajnaCijena.Text = "";
            izabranaRoba = null;
            gbIzabranaRoba.Hide();
            stavka = null;
        }

        private bool validate()
        {
            bool check = true;
            double result;
            if (izabranaRoba == null)
            {
                check = false;
            }
            if (string.IsNullOrEmpty(tbxKolicina.Text))
            {
                check = false;
            }
            if (!Double.TryParse(tbxKolicina.Text, out result))
            {
                check = false;
            }
            if (!Double.TryParse(tbxKolicina.Text,out  result))
            {
                check = false;
            }
            if (!Double.TryParse(tbxNabavnaCijena.Text, out result))
            {
                check = false;
            }
            if (!Double.TryParse(tbxVeleprodajnaCijena.Text, out result))
            {
                check = false;
            }
            return check;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if(validate())
            {
                if (stavka == null)
                {
                    stavka = new StavkaKalkulacijeDTO();
                    fillObject(stavka);
                    VeleprodajaUtil.getDAOFactory().getStavkaKalkulacijeDAO().insert(stavka);
                    fillStavke();
                    fillKalkulacijaValues();
                    emptyControlls();
                    stavka = null;
                }
                else
                {
                    int staraRoba = stavka.Roba.SifraRoba;
                    fillObject(stavka);
                    VeleprodajaUtil.getDAOFactory().getStavkaKalkulacijeDAO().update(stavka,staraRoba);
                    stavka = null;
                    fillStavke();
                }
            }
            else
            {
                MessageBox.Show(this, "Neispravan unos", "Neispravan unos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgStavke_SelectionChanged(object sender, EventArgs e)
        {
          
        }

        private void dgStavke_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 6)
                {
                    stavka = (StavkaKalkulacijeDTO)dgStavke.Rows[e.RowIndex].Cells["colObject"].Value;
                    fillControls();
                }
            }
        }

        private void btnPonistiUnos_Click(object sender, EventArgs e)
        {
            emptyControlls();
        }
    }
}
