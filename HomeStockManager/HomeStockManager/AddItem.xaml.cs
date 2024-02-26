using System;
using System.Windows;
using System.Windows.Controls;
using HomeStockManager.Classes;

namespace HomeStockManager
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        User me;
        private DB db;
        string itemType, storagePlace;
        public AddItem(User loggedInUser, string StoragePlace)
        {
            InitializeComponent();
            me = loggedInUser;
            storagePlace = StoragePlace;
            db = new DB();
        }

        private void btnVegetablesPreset_Click(object sender, RoutedEventArgs e)
        {
            lblPreset.Content = "Preset:\r\nVegetables";
            itemType = "Vegetables";

            DateTime currentDate = DateTime.Today;
            DateTime futureDate = currentDate.AddDays(5);
            datePicker.SelectedDate = futureDate;
        }

        private void btnMeatPreset_Click(object sender, RoutedEventArgs e)
        {
            lblPreset.Content = "Preset:\r\nMeat";
            itemType = "Meat";

            DateTime currentDate = DateTime.Today;
            DateTime futureDate = currentDate.AddDays(3);
            datePicker.SelectedDate = futureDate;
        }

        private void btnDrinksPreset_Click(object sender, RoutedEventArgs e)
        {
            lblPreset.Content = "Preset:\r\nDrinks";
            itemType = "Drinks";

            DateTime currentDate = DateTime.Today;
            DateTime futureDate = currentDate.AddMonths(6);
            datePicker.SelectedDate = futureDate;
        }

        private void btnCheesePreset_Click(object sender, RoutedEventArgs e)
        {
            lblPreset.Content = "Preset:\r\nCheese";
            itemType = "Cheese";

            DateTime currentDate = DateTime.Today;
            DateTime futureDate = currentDate.AddDays(14);
            datePicker.SelectedDate = futureDate;
        }

        private void btnEggPreset_Click(object sender, RoutedEventArgs e)
        {
            lblPreset.Content = "Preset:\r\nEgg";
            itemType = "Egg";

            DateTime currentDate = DateTime.Today;
            DateTime futureDate = currentDate.AddDays(28);
            datePicker.SelectedDate = futureDate;
        }

        private void btnFruitPreset_Click(object sender, RoutedEventArgs e)
        {
            lblPreset.Content = "Preset:\r\nFruits";
            itemType = "Fruits";

            DateTime currentDate = DateTime.Today;
            DateTime futureDate = currentDate.AddDays(7);
            datePicker.SelectedDate = futureDate;
        }

        private void btnToppingPreset_Click(object sender, RoutedEventArgs e)
        {
            lblPreset.Content = "Preset:\r\nTopping";
            itemType = "Topping";

            DateTime currentDate = DateTime.Today;
            DateTime futureDate = currentDate.AddDays(7);
            datePicker.SelectedDate = futureDate;
        }

        private void btnMilkPreset_Click(object sender, RoutedEventArgs e)
        {
            lblPreset.Content = "Preset:\r\nMilk";
            itemType = "Milk";

            DateTime currentDate = DateTime.Today;
            DateTime futureDate = currentDate.AddDays(6);
            datePicker.SelectedDate = futureDate;
        }

        private void btnSaucePreset_Click(object sender, RoutedEventArgs e)
        {
            lblPreset.Content = "Preset:\r\nSauce";
            itemType = "Sauce";

            DateTime currentDate = DateTime.Today;
            DateTime futureDate = currentDate.AddMonths(2);
            datePicker.SelectedDate = futureDate;
        }

        private void btnOther_Click(object sender, RoutedEventArgs e)
        {
            lblPreset.Content = "Preset:\r\nNone";
            itemType = "Other";
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (txtNameOfItem.Text != "" || txtNameOfItem.Text != " ")
            {
                if (itemType != "" || itemType != null)
                {
                    if (datePicker.SelectedDate.HasValue)
                    {
                        string itemname = txtNameOfItem.Text;
                        DateTime selectedDate = datePicker.SelectedDate.Value;
                        bool success = db.InsertIntoStorageTable(me.Username, storagePlace, itemname, selectedDate, itemType);

                        if (success)
                        {
                            MessageBox.Show("Item added to " + storagePlace);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to insert record.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select an expiry date or use a preset.");
                    }
                } 
                else MessageBox.Show("Please select a item type.");
            }
            else MessageBox.Show("Please fill in a valid name. For example: Banana");
        }
    }
}
