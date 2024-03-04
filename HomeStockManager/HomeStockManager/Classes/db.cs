using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace HomeStockManager.Classes
{
    public class DB
    {
        private MySqlConnection connection;
        private string server, database, username, password;

        public DB()
        {
            server = "";
            database = "stockbeheer";
            username = "stockbeheerder";
            password = "hahatesting123";

            connection = new MySqlConnection($"server={server};port=3306;uid={username};pwd={password};database={database}");

            //HEB DE DATABASE FF OFFLINE GEHAALD DUS DE APP WERKT VOORLOPIG NIET

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

        public int CheckAmountStoragePlaces(string username)
        {
            string query = "SELECT COUNT(*) FROM storagePlaces WHERE username = @username";

            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return -1;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        public string GetFirstStoragePlaceName(string username)
        {
            string storagePlaceName = null;
            string query = "SELECT storageplaceName FROM storagePlaces WHERE username = @username ORDER BY storageplaceid DESC LIMIT 1;";

            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    storagePlaceName = result.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }

            return storagePlaceName;
        }

        public string GetSecondStoragePlaceName(string username)
        {
            string storagePlaceName = null;
            string query = "SELECT storageplaceName FROM storagePlaces WHERE username = @username ORDER BY storageplaceid ASC LIMIT 1;";

            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    storagePlaceName = result.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }

            return storagePlaceName;
        }

        public bool SaveStoragePlace(string username, string storagePlaceName)
        {
            string checkCountQuery = "SELECT COUNT(*) FROM storagePlaces WHERE username = @username";
            string checkExistenceQuery = "SELECT COUNT(*) FROM storagePlaces WHERE username = @username AND storageplaceName = @storagePlaceName";

            try
            {
                connection.Open();

                MySqlCommand checkCountCmd = new MySqlCommand(checkCountQuery, connection);
                checkCountCmd.Parameters.AddWithValue("@username", username);
                int storagePlacesCount = Convert.ToInt32(checkCountCmd.ExecuteScalar());

                if (storagePlacesCount >= 2)
                {
                    MessageBox.Show("You have reached the limit of two storage places.");
                    return false;
                }

                MySqlCommand checkExistenceCmd = new MySqlCommand(checkExistenceQuery, connection);
                checkExistenceCmd.Parameters.AddWithValue("@username", username);
                checkExistenceCmd.Parameters.AddWithValue("@storagePlaceName", storagePlaceName);
                int existingCount = Convert.ToInt32(checkExistenceCmd.ExecuteScalar());

                if (existingCount > 0)
                {
                    MessageBox.Show("Storage place already exists.");
                    return false;
                }

                string insertQuery = "INSERT INTO storagePlaces (username, storageplaceName) VALUES (@username, @storagePlaceName)";
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);
                insertCmd.Parameters.AddWithValue("@username", username);
                insertCmd.Parameters.AddWithValue("@storagePlaceName", storagePlaceName);

                int rowsAffected = insertCmd.ExecuteNonQuery();
                MessageBox.Show("Storage place saved.");
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
        }

        public bool InsertIntoStorageTable(string user, string storagePlace, string storageContent, DateTime contentsExpiry, string contentType)
        {
            string query = "INSERT INTO storage (user, storagePlace, storageContent, ContentsExpiry, ContentType) " +
                           "VALUES (@user, @storagePlace, @storageContent, @contentsExpiry, @contentType)";

            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@storagePlace", storagePlace);
                cmd.Parameters.AddWithValue("@storageContent", storageContent);
                cmd.Parameters.AddWithValue("@contentsExpiry", contentsExpiry);
                cmd.Parameters.AddWithValue("@contentType", contentType);

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

        public bool DeleteStoragePlace(string username, string storagePlaceName)
        {
            try
            {
                connection.Open();

                string deleteContentQuery = "DELETE FROM storage WHERE user = @username AND storagePlace = @storagePlaceName";
                MySqlCommand deleteContentCmd = new MySqlCommand(deleteContentQuery, connection);
                deleteContentCmd.Parameters.AddWithValue("@username", username);
                deleteContentCmd.Parameters.AddWithValue("@storagePlaceName", storagePlaceName);
                int contentRowsAffected = deleteContentCmd.ExecuteNonQuery();

                string deleteStoragePlaceQuery = "DELETE FROM storagePlaces WHERE username = @username AND storageplaceName = @storagePlaceName";
                MySqlCommand deleteStoragePlaceCmd = new MySqlCommand(deleteStoragePlaceQuery, connection);
                deleteStoragePlaceCmd.Parameters.AddWithValue("@username", username);
                deleteStoragePlaceCmd.Parameters.AddWithValue("@storagePlaceName", storagePlaceName);
                int storagePlaceRowsAffected = deleteStoragePlaceCmd.ExecuteNonQuery();

                if (contentRowsAffected == 0 && storagePlaceRowsAffected > 0)
                {
                    contentRowsAffected = 1;
                }

                return contentRowsAffected > 0 && storagePlaceRowsAffected > 0;
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

        public DataTable GetStorageData(string username, string storagePlaceName)
        {
            DataTable dt = new DataTable();

            string query = "SELECT storageContent, ContentsExpiry, ContentType FROM storage WHERE user = @username AND storagePlace = @storagePlaceName";

            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@storagePlaceName", storagePlaceName);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

            return dt;
        }

        public DataTable GetNotifications(string username)
        {
            DataTable dt = new DataTable();

            string query = "SELECT notification, notificationDate, hasread_notification FROM notifications WHERE username = @username";

            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

            return dt;
        }

        public bool InsertNotification(string username, string notification)
        {
            string query = "INSERT INTO notifications (username, notification, notificationDate, hasread_notification) " +
                           "VALUES (@username, @notification, @notificationDate, @hasRead)";

            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@notification", notification);
                cmd.Parameters.AddWithValue("@notificationDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@hasRead", 0);

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

        public bool MarkNotificationsAsRead(string username)
        {
            string query = "UPDATE notifications SET hasread_notification = 1 WHERE username = @username";

            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);

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
