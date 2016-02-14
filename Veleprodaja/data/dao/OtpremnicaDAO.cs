using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veleprodaja.data.dto;

namespace Veleprodaja.data.dao
{
    public interface OtpremnicaDAO
    {
         List<OtpremnicaDTO> getAll();
         int insert(OtpremnicaDTO otpremnica);
        void updateObjectIznos(OtpremnicaDTO otpremnica);
    }
}
