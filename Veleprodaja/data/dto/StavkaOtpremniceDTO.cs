using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veleprodaja.data.dto
{
    public class StavkaOtpremniceDTO
    {
        private double kolicina;

        public double Kolicina
        {
            get { return kolicina; }
            set { kolicina = value; }
        }
        private double veleprodajnaCijena;

        public double VeleprodajnaCijena
        {
            get { return veleprodajnaCijena; }
            set { veleprodajnaCijena = value; }
        }
        private double rabat;

        public double Rabat
        {
            get { return rabat; }
            set { rabat = value; }
        }
        private double cijenaSaRabatom;

        public double CijenaSaRabatom
        {
            get { return cijenaSaRabatom; }
            set { cijenaSaRabatom = value; }
        }
        private RobaDTO roba;

        public RobaDTO Roba
        {
            get { return roba; }
            set { roba = value; }
        }

        private OtpremnicaDTO otpremnica;

        public OtpremnicaDTO Otpremnica
        {
            get { return otpremnica; }
            set { otpremnica = value; }
        }

        private double veleprodajniIznos;

        public double VeleprodajniIznos
        {
            get { return veleprodajniIznos; }
            set { veleprodajniIznos = value; }
        }
        private double iznosSaRabatom;

        public double IznosSaRabatom
        {
            get { return iznosSaRabatom; }
            set { iznosSaRabatom = value; }
        }
    }
}
