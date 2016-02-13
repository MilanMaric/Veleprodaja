using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veleprodaja.data.dto;

namespace Veleprodaja.data.dao.MySqlDao
{
    public class MySqlKalkulacijaDAO : KalkulacijaDAO
    {
        private string qGetAll = "select * from kalkulacija_osnovno where PoslovnaGodina=?PoslovnaGodina;";
        private string qInsert = "INSERT INTO `veleprodaja`.`kalkulacija` (`RedniBroj`, `BrojFaktureDobavljaca`) VALUES (?RedniBroj, ?BrojFaktureDobavljaca);";
        public List<KalkulacijaDTO> getAll()
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = qGetAll;
            command.Parameters.AddWithValue("PoslovnaGodina", VeleprodajaUtil.PoslovnaGodina);
            MySqlDataReader reader = command.ExecuteReader();
            List<KalkulacijaDTO> lista = new List<KalkulacijaDTO>();
            while (reader.Read())
            {
                KalkulacijaDTO kalkulacija = readerToKalkulacijaDTO(reader);
                kalkulacija.Partner = MySqlPartnerDAO.readerToPartnerDTO(reader);
                kalkulacija.Partner.Mjesto = MySqlMjestoDAO.readerToMjestoDTO(reader);
                lista.Add(kalkulacija);
            }
            reader.Close();
            ConnectionPool.checkInConnection(connection);
            return lista;
        }

        public int insert(KalkulacijaDTO kalkulacija)
        {
            int rows=new MySqlStavkaKnjigeTrgovineNaVeliko().insert(kalkulacija);
            if (rows > 0)
            {
                MySqlConnection connection = ConnectionPool.checkOutConnection();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = qInsert;
                command.Parameters.AddWithValue("RedniBroj", kalkulacija.RedniBroj);
                command.Parameters.AddWithValue("BrojFaktureDobavljaca", kalkulacija.BrojFaktureDobavljaca);
                int rows1=command.ExecuteNonQuery();
                ConnectionPool.checkInConnection(connection);
                return rows;
            }
            return 0;
        }

        public static KalkulacijaDTO readerToKalkulacijaDTO(MySqlDataReader reader)
        {
            KalkulacijaDTO kalkulacija = new KalkulacijaDTO(MySqlStavkaKnjigeTrgovineNaVeliko.readerToStavkaKnjigeTrgovineNaVeliko(reader));
            kalkulacija.BrojFaktureDobavljaca = reader.GetString("BrojFaktureDobavljaca");
            return kalkulacija;
        }
    }
}
