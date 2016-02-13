using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veleprodaja.data.dto
{
    public class StavkaKnjigeTrgovineNaVelikoDTO
    {
        protected int redniBroj;

        public int RedniBroj
        {
            get { return redniBroj; }
            set { redniBroj = value; }
        }
        protected int poslovnaGodina;

        public int PoslovnaGodina
        {
            get { return poslovnaGodina; }
            set { poslovnaGodina = value; }
        }
        protected PartnerDTO partner;

        public PartnerDTO Partner
        {
            get { return partner; }
            set { partner = value; }
        }
        protected DateTime datum;

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }


    }
}
