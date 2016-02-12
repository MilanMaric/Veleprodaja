using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Veleprodaja.data.dto
{
    public class BankaDTO
    {
        private int idBanka;

        public int IdBanka
        {
            get { return idBanka; }
            set { idBanka = value; }
        }
        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }
        private MjestoDTO mjesto;

        public MjestoDTO Mjesto
        {
            get { return mjesto; }
            set { mjesto = value; }
        }
    }
}
