using MySql.Data.MySqlClient;
using System;

namespace HomeStockManager.Classes
{
    public class DB
    {
        private MySqlConnection connection;
        private string server, database, username, password;

        public DB()
        {
            server = "35.197.205.190";
            database = "stockbeheer";
            username = "stockbeheerder";
            password = "hahatesting123";

            connection = new MySqlConnection($"server={server};port=3306;uid={username};pwd={password};database={database}");

            //jullie kunnen de database bekijken op 35.197.205.190/phpmyadmin
            //database zelf noemt stockbeheer
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

        public User GetUserInfo(string username)
        {
            string query = "SELECT username, email, firstName, lastName, role FROM users WHERE username = @username";

            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string userEmail = reader["email"].ToString();
                        string firstName = reader["firstName"].ToString();
                        string lastName = reader["lastName"].ToString();
                        string role = reader["role"].ToString();

                        User user = new User
                        {
                            Username = username,
                            Email = userEmail,
                            FirstName = firstName,
                            LastName = lastName,
                            Role = role
                        };

                        return user;
                    }
                    else
                    {
                        Console.WriteLine("User not found in the database.");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
