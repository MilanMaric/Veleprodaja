using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veleprodaja.data.dto;

namespace Veleprodaja.data.dao.MySqlDao
{
    public class MySqlOtpremnicaDAO:OtpremnicaDAO
    {
        private string qGetAll = "select * from otpremnica_osnovno where PoslovnaGodina=?PoslovnaGodina;";
        private string qInsert = "insert into otpremnica (RedniBroj) values (?RedniBroj);";
        public List<OtpremnicaDTO> getAll()
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = qGetAll;
            command.Parameters.AddWithValue("PoslovnaGodina", VeleprodajaUtil.PoslovnaGodina);
            MySqlDataReader reader = command.ExecuteReader();
            List<OtpremnicaDTO> lista = new List<OtpremnicaDTO>();
            while (reader.Read())
            {
                OtpremnicaDTO kalkulacija = readerToOtpremnicaDTO(reader);
                kalkulacija.Partner = MySqlPartnerDAO.readerToPartnerDTO(reader);
                kalkulacija.Partner.Mjesto = MySqlMjestoDAO.readerToMjestoDTO(reader);
                lista.Add(kalkulacija);
            }
            reader.Close();
            ConnectionPool.checkInConnection(connection);
            return lista;
        }

        private OtpremnicaDTO readerToOtpremnicaDTO(MySqlDataReader reader)
        {
            OtpremnicaDTO otpremnica = new OtpremnicaDTO(MySqlStavkaKnjigeTrgovineNaVeliko.readerToStavkaKnjigeTrgovineNaVeliko(reader));
            return otpremnica;
        }

        public int insert(dto.OtpremnicaDTO otpremnica)
        {
            int rows = new MySqlStavkaKnjigeTrgovineNaVeliko().insert(otpremnica);
            if (rows > 0)
            {
                 MySqlConnection connection = ConnectionPool.checkOutConnection();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = qInsert;
                command.Parameters.AddWithValue("RedniBroj", otpremnica.RedniBroj);
                int rows1=command.ExecuteNonQuery();
                ConnectionPool.checkInConnection(connection);
                return rows;
            }
            return rows;
        }
    }
}
