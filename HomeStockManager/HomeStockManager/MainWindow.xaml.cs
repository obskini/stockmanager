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

            // Controleer inloggegevens in de database
            if (db.Login(username, password))
            {
                // Haal gebruikersgegevens op uit de database
                User loggedInUser = db.GetUserInfo(username);

                // Controleer of de gebruikersgegevens met succes zijn opgehaald
                if (loggedInUser != null)
                {
                    MessageBox.Show("Login successful!");

                    // Maak een nieuw instantie van Hub.xaml aan en geef de gebruikersgegevens door
                    Hub hubWindow = new Hub(loggedInUser);

                    // Toon het Hub venster
                    hubWindow.Show();

                    // Sluit het huidige venster (indien nodig)
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
    }
}
