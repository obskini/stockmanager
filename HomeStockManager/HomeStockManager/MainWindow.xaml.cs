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

            if (db.Register(firstName, lastName, username, email, password))
            {
                MessageBox.Show("Registration successful!");
                db.InsertNotification(username, "You have registered an account.");
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
