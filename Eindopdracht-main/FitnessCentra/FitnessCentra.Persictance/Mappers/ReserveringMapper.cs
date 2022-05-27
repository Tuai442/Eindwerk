using Fitness.Domain.Models;
using Fitness.Domain.Models.Gebruikers;
using FitnessCentra.Domain.Interfaces;
using FitnessCentra.Domain.Models.Reservaties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCentra.Persictance.Mappers
{
    public class ReserveringMapper : IReserveerRepository
    {
        private string _reservatieFile = @"Reservatie.txt";
        private string _connectionString = @"Data Source=DESKTOP-VPL2RFG\SQLEXPRESS;Initial Catalog=DatabankFitnessCentra;Integrated Security=True";
        private string _tableName = "Rezerveringen";
        private SqlConnection _connection;
        private ToestelMapper _toestelMapper;
        private GebruikerMapper _gebruikerMapper;
        public ReserveringMapper()
        {
            _connection = new SqlConnection(_connectionString);
            _toestelMapper = new ToestelMapper();
            _gebruikerMapper = new GebruikerMapper();

        }

        public List<string> VerwijderQuotes(string[] woorden)
        {
            List<string> temp = new List<string>();
            foreach (string s in woorden)
            {
                temp.Add(s.Replace("\'", ""));
            }
            return temp;

        }

        public void TextBestandNaarDatabase()
        {
            using (StreamReader reader = new StreamReader(_reservatieFile))
            {
                while (!reader.EndOfStream)
                {
                    // Niet beschikbaar
                }
            }
        }

        public void VoegRezerveringToe(Reservatie reservatie)
        {
            try
            {
                _connection.Open();
                string query = $"INSERT INTO {_tableName} (KlantNr, Email, ToestelId, BeginDatum, EindDatum)" +
                    $" VALUES (@KlantNr, @Email, @ToestelId, @BeginDatum, @EindDatum);";

                SqlCommand cmd = new(query, _connection);

                
                cmd.Parameters.Add("@KlantNr", SqlDbType.Int);
                cmd.Parameters["@KlantNr"].Value = reservatie.Gebruiker.Id;

                cmd.Parameters.Add("@Email", SqlDbType.VarChar);
                cmd.Parameters["@Email"].Value = reservatie.Gebruiker.Id;

                cmd.Parameters.Add("@ToestelId", SqlDbType.Int);
                cmd.Parameters["@ToestelId"].Value = reservatie.Toestel.Id;

                cmd.Parameters.Add("@BeginDatum", SqlDbType.DateTime);
                cmd.Parameters["@BeginDatum"].Value = reservatie.BeginDatum;

                cmd.Parameters.Add("@EindDatum", SqlDbType.DateTime);
                cmd.Parameters["@EindDatum"].Value = reservatie.EindDatum;
                

               
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }

        }

        public List<Reservatie> GeefAlleRezerveringen()
        {
            try
            {
                _connection.Open();

                List<Reservatie> result = new List<Reservatie>();

                string query = $"SELECT * FROM {_tableName};";
                SqlCommand cmd = new(query, _connection);

                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {

                        int gebruikerId = (int)dataReader["KlantNr"];
                        string email = (string)dataReader["Email"];
                        int toestelId = (int)dataReader["ToestelId"];
                        DateTime startDatum = (DateTime)dataReader["BeginDatum"];
                        DateTime eindDatum = (DateTime)dataReader["EindDatum"];

                        Toestel toestel = _toestelMapper.GeefToestelOpId(toestelId);
                        Gebruiker gebruiker = _gebruikerMapper.GeefGebruikerOpId(gebruikerId);
                        result.Add(new Reservatie(gebruiker, toestel, startDatum, eindDatum));


                    }
                    return result;
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                _connection.Close();
            }

            return new List<Reservatie>();
        }

    }
}
