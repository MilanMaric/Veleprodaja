using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veleprodaja.data.dto;

namespace Veleprodaja.data.dao
{
    public interface StavkaOtpremniceDAO
    {
        List<StavkaOtpremniceDTO> getByOtpremnica(OtpremnicaDTO kalkulacija);

        int insert(StavkaOtpremniceDTO stavka);

        void update(StavkaOtpremniceDTO stavka, int staraSifraRobe);
    }
}
