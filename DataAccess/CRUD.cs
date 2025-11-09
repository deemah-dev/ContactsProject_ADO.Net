using Modules;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public static class CRUD
    {
        public static bool Create(Contact contact)
        {
            int rowsAffected = 0;
            string query = @"INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, DateOfBirth, CountryID, ImagePath)
                                    VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @DateOfBirth, @CountryID, @ImagePath)";

            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(@"FirstName", contact.FirstName);
            command.Parameters.AddWithValue(@"LastName", contact.LastName);
            command.Parameters.AddWithValue(@"Email", contact.Email);
            command.Parameters.AddWithValue(@"Phone", contact.Phone);
            command.Parameters.AddWithValue(@"DateOfBirth", contact.DateOfBirth);
            command.Parameters.AddWithValue(@"Address", contact.Address);
            command.Parameters.AddWithValue(@"CountryID", contact.CountryID);
            if (contact.ImagePath == "") command.Parameters.AddWithValue(@"ImagePath", DBNull.Value);
            else command.Parameters.AddWithValue(@"ImagePath", contact.ImagePath);
            try
            {
                connection.Open();

                rowsAffected =  command.ExecuteNonQuery();
            }
            catch(Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }

        public static Contact Read(int contactID)
        {
            Contact contact = new Contact();
            string query = "SELECT * FROM Contacts WHERE ContactID = @ContactID";

            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(@"ContactID", contactID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    contact.FirstName = Convert.ToString(reader["FirstName"]);
                    contact.LastName = Convert.ToString(reader["LastName"]);
                    contact.Email = Convert.ToString(reader["Email"]);
                    contact.Phone = Convert.ToString(reader["Phone"]);
                    contact.Address = Convert.ToString(reader["Address"]);
                    contact.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    contact.CountryID = Convert.ToInt32(reader["CountryID"]);
                    if (reader["ImagePath"] == DBNull.Value) contact.ImagePath = "";
                    else contact.ImagePath = Convert.ToString(reader["ImagePath"]);
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
            return contact;
        }

        public static bool Update(int contactID, Contact contact)
        {
            int rowsAffected = 0;
            string query = "UPDATE Contacts SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, Address = @Address, DateOfBirth = @DateOfBirth, CountryID = @CountryID, ImagePath = @ImagePath WHERE ContactID = @ContactID";

            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(@"ContactID", contactID);
            command.Parameters.AddWithValue(@"FirstName", contact.FirstName);
            command.Parameters.AddWithValue(@"LastName", contact.LastName);
            command.Parameters.AddWithValue(@"Email", contact.Email);
            command.Parameters.AddWithValue(@"Phone", contact.Phone);
            command.Parameters.AddWithValue(@"DateOfBirth", contact.DateOfBirth);
            command.Parameters.AddWithValue(@"Address", contact.Address);
            command.Parameters.AddWithValue(@"CountryID", contact.CountryID);
            if(contact.ImagePath == "") command.Parameters.AddWithValue(@"ImagePath", DBNull.Value);
            else command.Parameters.AddWithValue(@"ImagePath", contact.ImagePath);

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

        public static bool Delete(int contactID)
        {
            int rowsAffected = 0;
            string query = "DELETE Contacts WHERE ContactID = @ContactID";

            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(@"ContactID", contactID);

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

        public static bool IsExist(int contactID)
        {
            bool IsExist = false;
            string query = "SELECT Exist = 1 FROM Contacts WHERE ContactID = @ContactID";

            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(@"ContactID", contactID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                IsExist = reader.HasRows;
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

            string query = "SELECT * FROM Contacts";

            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dataTable.Load(reader);
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
            return dataTable;
        }
    }
}