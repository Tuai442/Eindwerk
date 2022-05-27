using Fitness.Domain.Models.Gebruikers;
using FitnessCentra.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCentra.Persictance.Mappers
{


    public class GebruikerMapper: IGebruikerRepository
    {
        private string _gebruikerFile = @"Klanten.txt";
        private string _connectionString = @"Data Source=DESKTOP-VPL2RFG\SQLEXPRESS;Initial Catalog=DatabankFitnessCentra;Integrated Security=True";
        private string _tableName = "Gebruikers";
        private SqlConnection _connection;

        public GebruikerMapper()
        {
            _connection = new SqlConnection(_connectionString);
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
            using (StreamReader reader = new StreamReader(_gebruikerFile))
            {
                while (!reader.EndOfStream)
                {
                    string[] data = reader.ReadLine().Split(',');
                    List<string> verwerkteData = VerwijderQuotes(data);

                    DateTime dt = DateTime.ParseExact(verwerkteData[4], "yyyy-MM-dd HH:mm:ss", null);

                    string intresse = verwerkteData[5];
                   

                    Gebruiker gebruiker = new Gebruiker(verwerkteData[0], verwerkteData[1], verwerkteData[2], 0,
                        verwerkteData[3], dt, intresse, verwerkteData[5]);
                    VoegGebruikerToe(gebruiker);
                }
            }
        }

        public void VoegGebruikerToe(Gebruiker gebruiker)
        {
            try
            {
                _connection.Open();
                string query = $"INSERT INTO {_tableName} (Voornaam, Achternaam, Email, Stad, Geboortedatum, Intresse, KlantType)" +
                   $" VALUES (@Voornaam, @Achternaam, @Email, @Stad, @Geboortedatum, @Intresse, @KlantType);";
                SqlCommand cmd = new(query, _connection);

                cmd.Parameters.Add("@Voornaam", SqlDbType.VarChar);
                cmd.Parameters["@Voornaam"].Value = gebruiker.Voornaam;

                cmd.Parameters.Add("@Achternaam", SqlDbType.VarChar);
                cmd.Parameters["@Achternaam"].Value = gebruiker.Achternaam;

                cmd.Parameters.Add("@Email", SqlDbType.VarChar);
                cmd.Parameters["@Email"].Value = gebruiker.Email;

                cmd.Parameters.Add("@Stad", SqlDbType.VarChar);
                cmd.Parameters["@Stad"].Value = gebruiker.Adres;

                cmd.Parameters.Add("@Geboortedatum", SqlDbType.DateTime);
                cmd.Parameters["@Geboortedatum"].Value = gebruiker.GeboorteDatum;

                cmd.Parameters.Add("@Intresse", SqlDbType.VarChar);
                cmd.Parameters["@Intresse"].Value = gebruiker.Intresse.ToString();

                cmd.Parameters.Add("@KlantType", SqlDbType.VarChar);
                cmd.Parameters["@KlantType"].Value = gebruiker.KlantType;

                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                _connection.Close();
            }
        }
        
        public Gebruiker GeefGebruikerOpEmail(string email)
        {
            try
            {
                _connection.Open();

                string query = $"SELECT * FROM {_tableName} WHERE Email = '{email}';";
                SqlCommand cmd = new(query, _connection);

                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["KlantNr"];
                        string voornaam = (string)dataReader["Voornaam"];
                        string achternaam = (string)dataReader["Achternaam"];
                        string stad = (string)dataReader["Stad"];
                        string em = (string)dataReader["Email"];
                        DateTime geboorteDatum = (DateTime)dataReader["Geboortedatum"];
                        string intresse = (string)dataReader["Intresse"];
                        string klantType = (string)dataReader["KlantType"];

                        return new Gebruiker(voornaam, achternaam, email, id, stad, geboorteDatum, intresse, klantType);
                    }

                }
            }

            catch (Exception ex)
            {
               throw(ex);
            }
            finally
            {
                _connection.Close();
            }

            return null;

        }

        public Gebruiker GeefGebruikerOpId(int id)
        {
            try
            {
                _connection.Open();

                string query = $"SELECT * FROM {_tableName} WHERE KlantNr = '{id}';";
                SqlCommand cmd = new(query, _connection);

                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int i = (int)dataReader["KlantNr"];
                        string voornaam = (string)dataReader["Voornaam"];
                        string achternaam = (string)dataReader["Achternaam"];
                        string stad = (string)dataReader["Stad"];
                        string email = (string)dataReader["Email"];
                        DateTime geboorteDatum = (DateTime)dataReader["Geboortedatum"];
                        string intresse = (string)dataReader["Intresse"];
                        string klantType = (string)dataReader["KlantType"];

                        return new Gebruiker(voornaam, achternaam, email, i, stad, geboorteDatum, intresse, klantType);
                    }

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

            return null;
        }

        public Gebruiker GeefGebruikerOpKlantNr(int klantNr)
        {
            try
            {
                _connection.Open();

                string query = $"SELECT * FROM {_tableName} WHERE KlantNr = {klantNr}";
                SqlCommand cmd = new(query, _connection);

                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["KlantNr"];
                        string voornaam = (string)dataReader["Voornaam"];
                        string achternaam = (string)dataReader["Achternaam"];
                        string stad = (string)dataReader["Stad"];
                        string email = (string)dataReader["Email"];
                        DateTime geboorteDatum = (DateTime)dataReader["Geboortedatum"];
                        string intresse = (string)dataReader["Intresse"];
                        string klantType = (string)dataReader["KlantType"];

                        return new Gebruiker(voornaam, achternaam, email, id, stad, geboorteDatum, intresse, klantType);
                    }
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

            return null;
        }

      
    }
}
