using HomeStockManager.Classes;
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
        }
    }
}
