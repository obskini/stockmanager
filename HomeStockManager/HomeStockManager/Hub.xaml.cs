using HomeStockManager.Classes;
using System;
using System.Data;
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
            btnEditFirstStoragePlace.Visibility = Visibility.Collapsed;
            btnDeleteFirstStoragePlace.Visibility = Visibility.Collapsed;
            btnAddContentFirstStoragePlace.Visibility = Visibility.Collapsed;
            lblAddFirst.Visibility = Visibility.Collapsed;
            lblEditFirst.Visibility = Visibility.Collapsed;
            lblDeleteFirst.Visibility = Visibility.Collapsed;
            dgFirst.Visibility = Visibility.Collapsed;
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
                lblNoStoragePlaces.Visibility = Visibility.Collapsed;
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

                btnEditFirstStoragePlace.Visibility = Visibility.Collapsed;
                btnDeleteFirstStoragePlace.Visibility = Visibility.Collapsed;
                btnAddContentFirstStoragePlace.Visibility = Visibility.Collapsed;


                lblEditFirst.Visibility = Visibility.Collapsed;
                lblDeleteFirst.Visibility = Visibility.Collapsed;
                lblAddFirst.Visibility = Visibility.Collapsed;

                dgFirst.Visibility = Visibility.Collapsed;

                countertje = 1;
            }
            else
            {
                imgArrowDown.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flipTransform = new ScaleTransform(1, -1);
                imgArrowDown.RenderTransform = flipTransform;

                btnEditFirstStoragePlace.Visibility = Visibility.Visible;
                btnDeleteFirstStoragePlace.Visibility = Visibility.Visible;
                btnAddContentFirstStoragePlace.Visibility = Visibility.Visible;

                lblEditFirst.Visibility = Visibility.Visible;
                lblDeleteFirst.Visibility = Visibility.Visible;
                lblAddFirst.Visibility = Visibility.Visible;

                DataTable dt = db.GetStorageData(me.Username, btnFirstStoragePlace.Content.ToString());
                dgFirst.ItemsSource = dt.DefaultView;
                dgFirst.Visibility = Visibility.Visible;

                countertje = 2;
            }
        }

        private void btnAddContentFirstStoragePlace_Click(object sender, RoutedEventArgs e)
        {
            string storagePlaceName = btnFirstStoragePlace.Content.ToString();
            AddItem nieuweContent = new AddItem(me, storagePlaceName);
            nieuweContent.Show();
        }

        private void btnDeleteFirstStoragePlace_Click(object sender, RoutedEventArgs e)
        {
            string storagePlaceName = btnFirstStoragePlace.Content.ToString();
            string username = me.Username;

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this storage place and its contents?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                bool success = db.DeleteStoragePlace(username, storagePlaceName);

                if (success)
                {
                    btnEditFirstStoragePlace.Visibility = Visibility.Collapsed;
                    btnDeleteFirstStoragePlace.Visibility = Visibility.Collapsed;
                    btnAddContentFirstStoragePlace.Visibility = Visibility.Collapsed;

                    btnFirstStoragePlace.Visibility = Visibility.Collapsed;
                    imgArrowDown.Visibility = Visibility.Collapsed;

                    lblEditFirst.Visibility = Visibility.Collapsed;
                    lblDeleteFirst.Visibility = Visibility.Collapsed;
                    lblAddFirst.Visibility = Visibility.Collapsed;

                    MessageBox.Show("Storage place and its contents deleted successfully.");
                    CheckForStoragePlaces();
                }
                else
                {
                    MessageBox.Show("Failed to delete storage place and its contents.");
                    CheckForStoragePlaces();
                }
            }
            else
            {
                MessageBox.Show("Deleting cancelled.");
            }
        }
    }
}
