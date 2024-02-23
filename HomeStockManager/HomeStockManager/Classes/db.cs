using MySql.Data.MySqlClient;
using System;

namespace HomeStockManager.Classes
{
    public class DB
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string username;
        private string password;

        public DB()
        {
            server = "";
            database = "stockbeheer";
            username = "";
            password = "";

            connection = new MySqlConnection($"server={server};port=3306;uid={username};pwd={password};database={database}");
        }

        public bool Login(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM users WHERE username = @username AND passwdd = @password";

            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        public bool Register(string firstName, string lastName, string username, string email, string password)
        {
            string query = "INSERT INTO users (username, email, passwdd, firstName, lastName) VALUES (@username, @email, @password, @firstName, @lastName)";

            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
