using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veleprodaja.data.dto
{
    public class StavkaKalkulacijeDTO
    {
        private KalkulacijaDTO kalkulacija;

        public KalkulacijaDTO Kalkulacija
        {
            get { return kalkulacija; }
            set { kalkulacija = value; }
        }
        private RobaDTO roba;

        public RobaDTO Roba
        {
            get { return roba; }
            set { roba = value; }
        }
        private double nabavnaCijena;

        public double NabavnaCijena
        {
            get { return nabavnaCijena; }
            set { nabavnaCijena = value; }
        }
        private double netoNabavnaCijena;

        public double NetoNabavnaCijena
        {
            get { return netoNabavnaCijena; }
            set { netoNabavnaCijena = value; }
        }

        private double rabat;

        public double Rabat
        {
            get { return rabat; }
            set { rabat = value; }
        }

        private double veleprodajnaCijena;

        public double VeleprodajnaCijena
        {
            get { return veleprodajnaCijena; }
            set { veleprodajnaCijena = value; }
        }
        private double razlikaUCijeni;

        public double RazlikaUCijeni
        {
            get { return razlikaUCijeni; }
            set { razlikaUCijeni = value; }
        }

        private double kolicina;

        public double Kolicina
        {
            get { return kolicina; }
            set { kolicina = value; }
        }

        private double nabavnaVrijednost;

        public double NabavnaVrijednost
        {
            get { return nabavnaVrijednost; }
            set { nabavnaVrijednost = value; }
        }

        private double veleprodajnaVrijednost;

        public double VeleprodajnaVrijednost
        {
            get { return veleprodajnaVrijednost; }
            set { veleprodajnaVrijednost = value; }
        }
    }
}
