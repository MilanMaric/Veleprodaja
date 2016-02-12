using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veleprodaja.data.dto
{
    public class JedinicaMjereDTO
    {
        private string sifraJediniceMjere;

        public string SifraJediniceMjere
        {
            get { return sifraJediniceMjere; }
            set { sifraJediniceMjere = value; }
        }

        private string opisJediniceMjere;

        public string OpisJediniceMjere
        {
            get { return opisJediniceMjere; }
            set { opisJediniceMjere = value; }
        }

        public override string ToString()
        {
            return sifraJediniceMjere + " : " + opisJediniceMjere;
        }
    }
}
