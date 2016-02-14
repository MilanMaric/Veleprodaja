using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Veleprodaja.data.dto
{
    public  class RacunDTO
    {
        private int redniBroj;

        public int RedniBroj
        {
            get { return redniBroj; }
            set { redniBroj = value; }
        }
        private DateTime datum;

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
    }
}
