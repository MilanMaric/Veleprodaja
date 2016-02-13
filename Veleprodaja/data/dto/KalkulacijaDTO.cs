using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veleprodaja.data.dto
{
    public class KalkulacijaDTO :StavkaKnjigeTrgovineNaVelikoDTO
    {
        private string brojFaktureDobavljaca;

        public KalkulacijaDTO()
        {

        }

        public KalkulacijaDTO(StavkaKnjigeTrgovineNaVelikoDTO stavka)
        {
            this.Datum = stavka.Datum;
            this.Partner = stavka.Partner;
            this.PoslovnaGodina = stavka.PoslovnaGodina;
            this.RedniBroj = stavka.RedniBroj;
        }

        public string BrojFaktureDobavljaca
        {
            get { return brojFaktureDobavljaca; }
            set { brojFaktureDobavljaca = value; }
        }
        private double veleprodajnaVrijednost;

        public double VeleprodajnaVrijednost
        {
            get { return veleprodajnaVrijednost; }
            set { veleprodajnaVrijednost = value; }
        }
        private double netoNabavnaVrijednost;

        public double NetoNabavnaVrijednost
        {
            get { return netoNabavnaVrijednost; }
            set { netoNabavnaVrijednost = value; }
        }
        private double razlikaUCijeni;

        public double RazlikaUCijeni
        {
            get { return razlikaUCijeni; }
            set { razlikaUCijeni = value; }
        }

    }
}
