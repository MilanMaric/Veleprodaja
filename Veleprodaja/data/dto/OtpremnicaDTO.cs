using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veleprodaja.data.dto
{
    public class OtpremnicaDTO: StavkaKnjigeTrgovineNaVelikoDTO
    {
        private RacunDTO racun;

        public OtpremnicaDTO(StavkaKnjigeTrgovineNaVelikoDTO stavkaKnjigeTrgovineNaVelikoDTO)
        {
            this.RedniBroj = stavkaKnjigeTrgovineNaVelikoDTO.RedniBroj;
            this.PoslovnaGodina = stavkaKnjigeTrgovineNaVelikoDTO.PoslovnaGodina;
            this.Partner = stavkaKnjigeTrgovineNaVelikoDTO.Partner;
            this.Datum = stavkaKnjigeTrgovineNaVelikoDTO.Datum;
        }

        public OtpremnicaDTO()
        {

        }

        public RacunDTO Racun
        {
            get { return racun; }
            set { racun = value; }
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
        private double iznosRabata;

        public double IznosRabata
        {
            get { return iznosRabata; }
            set { iznosRabata = value; }
        }

    }
}
