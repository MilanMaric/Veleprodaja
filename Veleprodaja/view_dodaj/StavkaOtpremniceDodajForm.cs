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
    public partial class StavkaOtpremniceDodajForm : RootForm
    {
        private OtpremnicaDTO otpremnica;
        private RobaDTO izabranaRoba;
        private StavkaOtpremniceDTO stavka = null;

        public StavkaOtpremniceDodajForm(OtpremnicaDTO otpremnica)
        {
            InitializeComponent();
            this.otpremnica = otpremnica;
            fillStavke();
            gbIzabranaRoba.Hide();
            fillOtpremnicaData();
            fillOtpremnicaValues();
        }

        private void fillOtpremnicaData()
        {
            lblDatum.Text = otpremnica.Datum.ToShortDateString();
            lblRedniBrojKalkulacije.Text = otpremnica.RedniBroj.ToString() ;
        }

        private void fillOtpremnicaValues()
        {
            VeleprodajaUtil.getDAOFactory().getOtpremnicaDAO().updateObjectIznos(otpremnica);
            lblKalIznos.Text = otpremnica.IznosSaRabatom.ToString();
            lblKalRabat.Text = otpremnica.IznosRabata.ToString();
            lblKalVeleprodajni.Text = otpremnica.VeleprodajniIznos.ToString();
        }

        private void fillStavke()
        {
            List<StavkaOtpremniceDTO> lista = VeleprodajaUtil.getDAOFactory().getStavkaOtpremniceDAO().getByOtpremnica(otpremnica);
            foreach (StavkaOtpremniceDTO stavka in lista)
            {
                dgStavke.Rows.Add(stavka, stavka.Roba.Naziv, stavka.Kolicina, stavka.Rabat, stavka.CijenaSaRabatom, stavka.VeleprodajniIznos, stavka.VeleprodajniIznos, stavka.IznosSaRabatom, "Izmjeni");
            }
        }

        private void tbxSifraRobe_Leave(object sender, EventArgs e)
        {
            RobaPregledForm rpf = new RobaPregledForm(tbxSifraRobe.Text);
            if (rpf.ShowDialog() == DialogResult.OK)
            {
                this.izabranaRoba = rpf.IzabranaRoba;
                VeleprodajaUtil.getDAOFactory().getRobaDAO().getKolicinaICijena(izabranaRoba);
                tbxKolicina.Text =izabranaRoba.RaspolozivaKolicina.ToString();
                tbxVeleprodajnaCijena.Text = izabranaRoba.PoslednjaCijena.ToString();
                tbxVeleprodajnaCijena.ReadOnly = true;
                gbIzabranaRoba.Show();
                lblRobaNaziv.Text = izabranaRoba.Naziv;
                lblRobaJedinicaMjere.Text = izabranaRoba.JedinicaMjere.ToString() ;
            }
        }

        private void fillObject(StavkaOtpremniceDTO stavka)
        {
            stavka.Otpremnica = otpremnica;
            stavka.Roba = izabranaRoba;
            stavka.VeleprodajnaCijena = izabranaRoba.PoslednjaCijena;
            stavka.Kolicina=double.Parse(tbxKolicina.Text);
            if (string.IsNullOrEmpty(tbxRabat.Text))
            {
                stavka.Rabat = 0;
            }
            else
            {
                stavka.Rabat = double.Parse(tbxRabat.Text);
            }
        }


        private bool validate()
        {
            bool check = true;
            if (izabranaRoba == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(tbxKolicina.Text))
            {
                return false;
            }
            
            double kolicina;
            if (!double.TryParse(tbxKolicina.Text, out kolicina))
            {
                return false;
            }
            if (kolicina > izabranaRoba.RaspolozivaKolicina)
            {
                return false;
            }
            return check;
        }

        private void emptyControlls()
        {
            tbxKolicina.Text = "";
            tbxRabat.Text = "";
            tbxSifraRobe.Text = "";
            tbxVeleprodajnaCijena.Text = "";

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                if (stavka == null)
                {
                    stavka = new StavkaOtpremniceDTO();
                    fillObject(stavka);
                    if (string.IsNullOrEmpty(tbxRabat.Text))
                    {
                        stavka.Rabat = 0.0;
                    }
                    VeleprodajaUtil.getDAOFactory().getStavkaOtpremniceDAO().insert(stavka);
                    stavka = null;
                    emptyControlls();
                    fillStavke();
                    fillOtpremnicaValues();
                }
                else
                {

                }
            }
        }

        private void tbxRabat_TextChanged(object sender, EventArgs e)
        {
            if (izabranaRoba != null)
            {
                double rabat;
                if (double.TryParse(tbxRabat.Text, out rabat))
                {
                    tbxVeleprodajnaCijena.Text = (izabranaRoba.PoslednjaCijena - rabat * izabranaRoba.PoslednjaCijena / 100).ToString();
                }
            }
        }

        private void obrisiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
