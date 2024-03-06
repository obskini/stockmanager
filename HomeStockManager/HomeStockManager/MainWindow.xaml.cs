using System.Collections.Generic;
using System.Linq;
using System.Windows;
using HomeStockManager.Classes;

namespace HomeStockManager
{
    public partial class MainWindow : Window
    {
        private DB db;

        public MainWindow()
        {
            InitializeComponent();
            db = new DB();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (db.Login(username, password))
            {
                User loggedInUser = db.GetUserInfo(username);

                if (loggedInUser != null)
                {
                    MessageBox.Show("Login successful!");

                    Hub hubWindow = new Hub(loggedInUser);
                    hubWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to retrieve user information from the database.");
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = RegisterFirstNameTextBox.Text;
            string lastName = RegisterLastNameTextBox.Text;
            string username = RegisterUsernameTextBox.Text;
            string email = RegisterEmailTextBox.Text;
            string password = RegisterPasswordBox.Password;

            bool validUser = CheckUser(firstName, lastName, username, email, password, out string notification);

            if (validUser)
            {
                if (db.Register(firstName, lastName, username, email, password))
                {
                    MessageBox.Show("Registration successful!");
                    RegisterFirstNameTextBox.Clear();
                    RegisterLastNameTextBox.Clear();
                    RegisterUsernameTextBox.Clear();
                    RegisterEmailTextBox.Clear();
                    RegisterPasswordBox.Clear();
                }
                else
                {
                    MessageBox.Show("Registration failed!");
                }
            }
            else
            {
                MessageBox.Show($"Error: {notification}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CheckUser(string firstName, string lastName, string username, string email, string password, out string notification)
        {
            bool output = true;
            List<string> meldingen = new List<string>();
            notification = "";

            if (string.IsNullOrWhiteSpace(firstName))
            {
                meldingen.Add("First name is required.");
                output = false;
            }
            else
            {
                if (firstName.Length < 2)
                {
                    meldingen.Add("First name should contain at least 2 letters.");
                    output = false;
                }

                if (!firstName.All(char.IsLetter))
                {
                    meldingen.Add("First name can only contain alphabetic characters.");
                    output = false;
                }
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                meldingen.Add("Last name is required.");
                output = false;
            }
            else
            {
                if (lastName.Length < 2)
                {
                    meldingen.Add("Last name should contain at least 2 letters.");
                    output = false;
                }

                if (!lastName.All(char.IsLetter))
                {
                    meldingen.Add("Last name can only contain alphabetic characters.");
                    output = false;
                }
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                meldingen.Add("Username is required.");
                output = false;
            }
            else
            {
                if (username.Length < 4 || username.Length > 20)
                {
                    meldingen.Add("Username should be between 4 and 20 characters long.");
                    output = false;
                }

                if (!username.All(char.IsLetterOrDigit))
                {
                    meldingen.Add("Username can only contain letters and digits.");
                    output = false;
                }
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                meldingen.Add("Email is required.");
                output = false;
            }
            else if (!email.Contains("@") || !email.Contains("."))
            {
                meldingen.Add("Invalid email format.");
                output = false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                meldingen.Add("Password is required.");
                output = false;
            }
            else
            {
                if (password.Length < 8)
                {
                    meldingen.Add("Password should be at least 8 characters long and ");
                    output = false;
                }
                else if (!password.Any(char.IsDigit) || !password.Any(char.IsUpper))
                {
                    meldingen.Add("Password should include at least one digit and one uppercase letter.");
                    output = false;
                }
            }

            foreach (string error in meldingen)
            {
                notification += $"\r\n{error}";
            }

            return output;
        }
    }
}
