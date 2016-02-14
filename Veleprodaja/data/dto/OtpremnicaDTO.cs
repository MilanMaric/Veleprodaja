using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veleprodaja.data.dto
{
    public class OtpremnicaDTO:StavkaKnjigeTrgovineNaVelikoDTO
    {
        private RacunDTO racun;
        private StavkaKnjigeTrgovineNaVelikoDTO stavkaKnjigeTrgovineNaVelikoDTO;

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

    }
}
