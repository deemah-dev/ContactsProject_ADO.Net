using Modules;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public static class CountriesCRUD
    {
        public static bool Create(Country country)
        {
            string query = "INSERT INTO Countries (CountryName, Code, PhoneCall) VALUES (@CountryName, @Code, @PhoneCall)";

            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(@"CountryName", country.Name);
            command.Parameters.AddWithValue(@"Code", country.Code);
            command.Parameters.AddWithValue(@"PhoneCall", country.PhoneCall);

            int rowsAffected = 0;
            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }

        public static Country Read(int id)
        {
            string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";

            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(@"CountryID", id);

            Country country = new Country();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    country.Name = Convert.ToString(reader["CountryName"]);
                }
                reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return country;
        }

        public static Country Read(string CountryName)
        {
            string query = "SELECT * FROM Countries WHERE CountryName = @CountryName";

            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(@"CountryName", CountryName);

            Country country = new Country();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    country.Name = Convert.ToString(reader["CountryName"]);
                }
                reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return country;
        }

        public static bool Update(int id, Country country)
        {
            string query = "UPDATE Countries SET CountryName = @CountryName, Code = @Code, PhoneCall = @PhoneCall WHERE CountryID = @CountryID";

            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(@"CountryID", id);
            command.Parameters.AddWithValue(@"CountryName", country.Name);
            command.Parameters.AddWithValue(@"Code", country.Code);
            command.Parameters.AddWithValue(@"PhoneCall", country.PhoneCall);

            int rowsAffected = 0;
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }

        public static bool Delete(int id)
        {
            string query = "DELETE FROM Countries WHERE CountryID = @CountryID";
            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(@"CountryID", id);

            int rowsAffected = 0;
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }

        public static bool IsExist(int id)
        {
            bool IsExist = false;

            string query = "SELECT EXIST = 1 FROM Countries WHERE CountryID = @CountryID";

            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(@"CountryID", id);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) IsExist = true;
                reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsExist;
        }

        public static bool IsExist(string CountryName)
        {
            bool IsExist = false;

            string query = "SELECT EXIST = 1 FROM Countries WHERE CountryName = @CountryName";

            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(@"CountryName", CountryName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) IsExist = true;
                reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsExist;
        }

        public static DataTable GetAll()
        {
            DataTable dataTable = new DataTable();

            string query = "SELECT * FROM Countries";

            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    dataTable.Load(reader);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }
    }
}
