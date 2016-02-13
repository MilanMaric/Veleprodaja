using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veleprodaja.data.dto;

namespace Veleprodaja.data.dao
{
    interface StavkaKnjigeTrgovineNaVelikoDAO
    {
        int insert(StavkaKnjigeTrgovineNaVelikoDTO stavka);
    }
}
