using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veleprodaja.data.dto
{
    public class RobaDTO
    {
        private int sifraRoba;

        public int SifraRoba
        {
            get { return sifraRoba; }
            set { sifraRoba = value; }
        }
        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }
        private JedinicaMjereDTO jedinicaMjere;

        public JedinicaMjereDTO JedinicaMjere
        {
            get { return jedinicaMjere; }
            set { jedinicaMjere = value; }
        }
    }
}
