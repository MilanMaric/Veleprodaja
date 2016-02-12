using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Veleprodaja.data.dto
{
    public class MjestoDTO
    {
        private int postanskiBroj;

        public int PostanskiBroj
        {
            get { return postanskiBroj; }
            set { postanskiBroj = value; }
        }
        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        public override string ToString()
        {
            return postanskiBroj + " : " + naziv;
        }
    }
}
