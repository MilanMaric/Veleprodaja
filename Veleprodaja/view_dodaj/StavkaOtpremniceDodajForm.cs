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
        public StavkaOtpremniceDodajForm(OtpremnicaDTO otpremnica)
        {
            InitializeComponent();
            fillStavke();
        }

        private void fillStavke()
        {
            List<StavkaOtpremniceDTO> lista = VeleprodajaUtil.getDAOFactory().getStavkaOtpremniceDAO().getByOtpremnica(otpremnica);
            foreach (StavkaOtpremniceDTO stavka in lista)
            {
                dgStavke.Rows.Add(stavka, stavka.Roba.Naziv, stavka.Kolicina, stavka.Rabat, stavka.CijenaSaRabatom, stavka.VeleprodajniIznos, stavka.VeleprodajniIznos, stavka.IznosSaRabatom, "Izmjeni");
            }
        }
    }
}
