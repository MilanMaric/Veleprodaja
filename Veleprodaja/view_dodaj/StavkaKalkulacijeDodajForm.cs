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
    public partial class StavkaKalkulacijeDodajForm : WelcomeForm
    {
        private KalkulacijaDTO kalkulacija = null;
        private RobaDTO izabranaRoba = null;
        private StavkaKalkulacijeDTO stavka = null;

        public StavkaKalkulacijeDodajForm()
        {
            InitializeComponent();
            fillStavke();
        }

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
            List<StavkaKalkulacijeDTO> listaStavki = VeleprodajaUtil.getDAOFactory().getStavkaKalkulacijeDAO().getByKalkulacija(kalkulacija);
            foreach (StavkaKalkulacijeDTO stavka in listaStavki)
            {
                dgStavke.Rows.Add(new object[] { stavka, stavka.Roba.Naziv, stavka.Kolicina, stavka.NabavnaCijena, stavka.Rabat, stavka.VeleprodajnaCijena, stavka });
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

        private void fillObject(StavkaKalkulacijeDTO stavka)
        {
            stavka.NabavnaCijena = Convert.ToDouble(tbxNabavnaCijena.Text);
            stavka.Kolicina = Convert.ToDouble(tbxKolicina.Text);
            stavka.Rabat = Convert.ToDouble(tbxRabat.Text);
            stavka.VeleprodajnaCijena = Convert.ToDouble(tbxVeleprodajnaCijena.Text);
            stavka.Kalkulacija = kalkulacija;
            stavka.Roba = izabranaRoba;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (izabranaRoba != null && kalkulacija!=null)
            {
                if (stavka == null)
                {
                    stavka = new StavkaKalkulacijeDTO();
                    fillObject(stavka);
                    VeleprodajaUtil.getDAOFactory().getStavkaKalkulacijeDAO().insert(stavka);
                }
            }
        }
    }
}
