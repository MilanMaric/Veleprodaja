using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veleprodaja.data.dto
{
    public class PartnerDTO
    {
        private int jib;

        public int Jib
        {
            get { return jib; }
            set { jib = value; }
        }
        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }
        private string adresa;

        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }
        private MjestoDTO mjesto;

        public MjestoDTO Mjesto
        {
            get { return mjesto; }
            set { mjesto = value; }
        }
        public override string ToString()
        {
            return jib + " " + naziv + " " + mjesto.Naziv;
        }
    }
}
