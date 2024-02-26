using HomeStockManager.Classes;
using System;
using System.Windows;
using System.Windows.Media;

namespace HomeStockManager
{
    /// <summary>
    /// Interaction logic for Hub.xaml
    /// </summary>
    public partial class Hub : Window
    {
        User me;
        private DB db;
        int countertje = 1;
        public Hub(User loggedInUser)
        {
            InitializeComponent();
            me = loggedInUser;
            db = new DB();
            lblSayHi.Content = "Hello, " + me.FirstName;
            HideStorage();
        }

        private void HideStorage()
        {
            btnAddStoragePlace.Visibility = Visibility.Collapsed;
            lblAddStorage.Visibility = Visibility.Collapsed;
            lblStoragePlaceName.Visibility = Visibility.Collapsed;
            txtStoragePlaceName.Visibility = Visibility.Collapsed;
            btnSaveStoragePlace.Visibility = Visibility.Collapsed;
            btnCloseSaveOption.Visibility = Visibility.Collapsed;
            btnFirstStoragePlace.Visibility = Visibility.Collapsed;
            imgArrowDown.Visibility = Visibility.Collapsed;
            btnSecondStoragePlace.Visibility = Visibility.Collapsed;
            imgArrowDown_Copy.Visibility = Visibility.Collapsed;
            lblNoStoragePlaces.Visibility = Visibility.Collapsed;
        }

        private void btnStorage_Click(object sender, RoutedEventArgs e)
        {
            btnAddStoragePlace.Visibility = Visibility.Visible;
            lblAddStorage.Visibility = Visibility.Visible;
            CheckForStoragePlaces();
        }

        private void CheckForStoragePlaces()
        {
            int storagePlacesCount = db.CheckAmountStoragePlaces(me.Username);

            if (storagePlacesCount == 1)
            {
                lblNoStoragePlaces.Visibility = Visibility.Collapsed;
                btnFirstStoragePlace.Visibility = Visibility.Visible;
                imgArrowDown.Visibility = Visibility.Visible;
                btnFirstStoragePlace.Content = db.GetStoragePlaceName(me.Username);
            }
            else if (storagePlacesCount == 2)
            {
                btnFirstStoragePlace.Visibility = Visibility.Visible;
                imgArrowDown.Visibility = Visibility.Visible;
                btnFirstStoragePlace.Content = db.GetStoragePlaceName(me.Username);

                btnSecondStoragePlace.Visibility = Visibility.Visible;
                imgArrowDown_Copy.Visibility = Visibility.Visible;
            }
            else
            {
                lblNoStoragePlaces.Visibility = Visibility.Visible;
            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            HideStorage();
        }

        private void btnAddStoragePlace_Click(object sender, RoutedEventArgs e)
        {
            lblStoragePlaceName.Visibility = Visibility.Visible;
            txtStoragePlaceName.Visibility = Visibility.Visible;
            btnSaveStoragePlace.Visibility = Visibility.Visible;
            btnCloseSaveOption.Visibility = Visibility.Visible;
        }

        private void btnSaveStoragePlace_Click(object sender, RoutedEventArgs e)
        {
            string StoragePlaceName = txtStoragePlaceName.Text;
            if (StoragePlaceName != "" && StoragePlaceName != " ")
            {
                db.SaveStoragePlace(me.Username, StoragePlaceName);
            }
            else MessageBox.Show("Please fill in a valid name. For example: Fridge");

            CheckForStoragePlaces();
        }

        private void CloseStorageSaveOption(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            lblStoragePlaceName.Visibility = Visibility.Collapsed;
            txtStoragePlaceName.Visibility = Visibility.Collapsed;
            btnSaveStoragePlace.Visibility = Visibility.Collapsed;
            btnCloseSaveOption.Visibility = Visibility.Collapsed;
        }

        private void btnNotifications_Click(object sender, RoutedEventArgs e)
        {
            HideStorage();
        }

        private void btnFirstStoragePlace_Click(object sender, RoutedEventArgs e)
        {
            FlipFirstArrow();

        }

        private void FirstArrowClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            FlipFirstArrow();
        }

        private void FlipFirstArrow()
        {
            if (countertje == 2)
            {
                imgArrowDown.RenderTransform = new RotateTransform(0);
                countertje = 1;
            }
            else
            {
                imgArrowDown.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flipTransform = new ScaleTransform(1, -1);
                imgArrowDown.RenderTransform = flipTransform;

                countertje = 2;
            }
        }
    }
}
