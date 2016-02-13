using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veleprodaja.data.dto;

namespace Veleprodaja.data.dao.MySqlDao
{
    public class MySqlStavkaKalkulacijeDAO:StavkaKalkulacijeDAO
    {
        private string qGetByKalkulacija = "select * from stavka_kalkulacija_view1 where RedniBroj=?RedniBroj;";
        private string qInsert = "INSERT INTO `veleprodaja`.`stavka_kalkulacije` (`RedniBroj`, `SifraRoba`, `Kolicina`, `NabavnaCijena`, `Rabat`, `VeleprodajnaCijena`) VALUES (?RedniBroj,?SifraRoba , ?Kolicina, ?NabavnaCijena, ?Rabat, ?VeleprodajnaCijena);";

        public List<StavkaKalkulacijeDTO> getByKalkulacija(KalkulacijaDTO kalkulacija)
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = qGetByKalkulacija;
            command.Parameters.AddWithValue("RedniBroj", kalkulacija.RedniBroj);
            MySqlDataReader reader = command.ExecuteReader();
            List<StavkaKalkulacijeDTO> lista = new List<StavkaKalkulacijeDTO>();
            while (reader.Read())
            {
                StavkaKalkulacijeDTO stavka = readerToStavkaKalkulacijeDTO(reader);
                stavka.Kalkulacija = kalkulacija;
                stavka.Roba = MySqlRobaDAO.readerToRobaDTO(reader);
                stavka.Roba.JedinicaMjere = MySqlJedinicaMjereDAO.readerToJedinicaMjereDTO(reader);
                lista.Add(stavka);
            }
            reader.Close();
            ConnectionPool.checkInConnection(connection);
            return lista;
        }

        public int insert(StavkaKalkulacijeDTO stavka)
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = qInsert;
            command.Parameters.AddWithValue("RedniBroj", stavka.Kalkulacija.RedniBroj);
            command.Parameters.AddWithValue("SifraRoba", stavka.Roba.SifraRoba);
            command.Parameters.AddWithValue("Kolicina", stavka.Kolicina);
            command.Parameters.AddWithValue("NabavnaCijena", stavka.NabavnaCijena);
            command.Parameters.AddWithValue("Rabat", stavka.Rabat);
            command.Parameters.AddWithValue("VeleprodajnaCijena", stavka.VeleprodajnaCijena);
            int rows=command.ExecuteNonQuery();
            stavka.RedniBroj = (int)command.LastInsertedId;
            ConnectionPool.checkInConnection(connection);
            return rows;
        }


        private StavkaKalkulacijeDTO readerToStavkaKalkulacijeDTO(MySqlDataReader reader)
        {
            StavkaKalkulacijeDTO stavka = new StavkaKalkulacijeDTO();
            stavka.Kolicina = reader.GetDouble("Kolicina");
            stavka.NabavnaCijena = reader.GetDouble("NabavnaCijena");
            stavka.Rabat = reader.GetDouble("Rabat");
            stavka.NetoNabavnaCijena = reader.GetDouble("NetoNabavnaCijena");
            stavka.VeleprodajnaCijena = reader.GetDouble("VeleprodajnaCijena");
            stavka.RazlikaUCijeni = reader.GetDouble("RazlikaUCijeni");
            stavka.NabavnaVrijednost = reader.GetDouble("NabavnaVrijednost");
            stavka.VeleprodajnaVrijednost = reader.GetDouble("VeleprodajnaVrijednost");
            return stavka;
        }

        
    }
}
