using Fitness.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCentra.Persictance.Mappers
{
    public class ToestelMapper: IToestelRepository
    {
        private string _gebruikerFile = @"FitnessToestellen.txt";
        private string _connectionString = @"Data Source=DESKTOP-VPL2RFG\SQLEXPRESS;Initial Catalog=DatabankFitnessCentra;Integrated Security=True";
        private string _tableName = "Toestellen";
        private SqlConnection _connection;

        public ToestelMapper()
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

                    string type = verwerkteData[1];
                    
                    VoegToestelToe(type);
                }
            }
        }

        public void VoegToestelToe(string toestelType)
        {
            try
            {
                _connection.Open();
                string query = $"INSERT INTO {_tableName} (ToestelType, InOnderhoud, WordtVerwijderd)" +
                    $" VALUES (@ToestelType, @InOnderhoud, @WordtVerwijderd);";
                SqlCommand cmd = new(query, _connection);

                cmd.Parameters.Add("@ToestelType", SqlDbType.VarChar);
                cmd.Parameters["@ToestelType"].Value = toestelType;

                cmd.Parameters.Add("@InOnderhoud", SqlDbType.Bit);
                cmd.Parameters["@InOnderhoud"].Value = 0;

                cmd.Parameters.Add("@WordtVerwijderd", SqlDbType.Bit);
                cmd.Parameters["@WordtVerwijderd"].Value = 0;

                cmd.ExecuteScalar();
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
        
        public List<Toestel> GeefAlleToestellen()
        {
            try
            {
                _connection.Open();

                List<Toestel> result = new List<Toestel>();
                string query = $"SELECT * FROM {_tableName};";
                SqlCommand cmd = new(query, _connection);

                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["Id"];
                        string toestelType = (string)dataReader["ToestelType"];
                        bool inOnderhoud = (bool)dataReader["InOnderhoud"];
                        bool wordtVerwijderd = (bool)dataReader["WordtVerwijderd"];

                        result.Add(new Toestel(id, toestelType, inOnderhoud, wordtVerwijderd));
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

            return null;
        }

        public List<Toestel> GeefToestellenOpType(string type)
        {
            try
            {
                _connection.Open();

                List<Toestel> result = new List<Toestel>();
                string query = $"SELECT * FROM {_tableName} WHERE ToestelType = '{type}';";
                SqlCommand cmd = new(query, _connection);

                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["Id"];
                        string toestelType = (string)dataReader["ToestelType"];

                        result.Add(new Toestel(id, toestelType));
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

            return null;
        }

        public Toestel GeefToestelOpId(int id)
        {
            try
            {
                _connection.Open();

                string query = $"SELECT * FROM {_tableName} WHERE Id = {id};";
                SqlCommand cmd = new(query, _connection);

                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int i = (int)dataReader["Id"];
                        string toestelType = (string)dataReader["ToestelType"];
                        bool inOnderhoud = (bool)dataReader["InOnderhoud"];
                        bool wordtVerwijderd = (bool)dataReader["WordtVerwijderd"];

                        return new Toestel(i, toestelType, inOnderhoud, wordtVerwijderd);
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

        public void UpdateToestel(Toestel toestel)
        {
            try
            {
                _connection.Open();
                var inOnderhoud = Convert.ToByte(toestel.OnderhoudBijVolgendeVrijStelling);
                var wordtVerwijderd = Convert.ToByte(toestel.VerwijderBijVolgendeVrijStelling);

                string query = $"UPDATE {_tableName} " +
                    $"SET InOnderhoud={inOnderhoud}, WordtVerwijderd={wordtVerwijderd} " +
                    $"WHERE Id = {toestel.Id};";
                SqlCommand cmd = new(query, _connection);
                SqlDataReader dataReader = cmd.ExecuteReader();
               
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

        public void VerwijderToestel(int id)
        {
            try
            {
                _connection.Open();
               
                string query = $"DELETE FROM {_tableName} WHERE Id = {id};";
                SqlCommand cmd = new(query, _connection);
                SqlDataReader dataReader = cmd.ExecuteReader();

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

        public List<string> GeefAlleToestelTypes()
        {
            try
            {
                _connection.Open();

                List<string> result = new List<string>();
                string query = $"SELECT DISTINCT ToestelType FROM {_tableName};";
                SqlCommand cmd = new(query, _connection);

                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        string toestelType = (string)dataReader["ToestelType"];
                        result.Add(toestelType);
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

            return null;
        }
    }
}
