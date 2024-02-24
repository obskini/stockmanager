using HomeStockManager.Classes;
using System;
using System.Windows;

namespace HomeStockManager
{
    /// <summary>
    /// Interaction logic for Hub.xaml
    /// </summary>
    public partial class Hub : Window
    {
        User me;
        public Hub(User loggedInUser)
        {
            InitializeComponent();
            me = loggedInUser;
            lblSayHi.Content = "Hello, " + me.FirstName;
            HideStorage();
        }

        private void HideStorage()
        {
            btnAddStoragePlace.Visibility = Visibility.Collapsed;
            lblAddStorage.Visibility = Visibility.Collapsed;
        }

        private void btnStorage_Click(object sender, RoutedEventArgs e)
        {
            btnAddStoragePlace.Visibility = Visibility.Visible;
            lblAddStorage.Visibility = Visibility.Visible;
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            HideStorage();
        }
    }
}
