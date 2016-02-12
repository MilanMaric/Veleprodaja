using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Veleprodaja.data.dto;

namespace Veleprodaja.data.dao
{
    public interface PartnerDAO
    {
        List<PartnerDTO> getAll();
        int insert(PartnerDTO partner);
        int update(PartnerDTO partner);
    }
}
