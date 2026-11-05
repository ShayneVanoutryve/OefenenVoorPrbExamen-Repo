using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Prb.Dictionary.Friends.Wpf
{
    public partial class MainWindow : Window
    {
        // Dictionary: Key = Name (string), Value = BirthYear (int)
        private Dictionary<string, int> _friendsDictionary = new Dictionary<string, int>();

        public MainWindow()
        {
            InitializeComponent();
            UpdateUI();
        }

        // 1. ADD FRIEND
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text.Trim();

            // Validate inputs: name must not be empty, year must be a valid integer
            if (!string.IsNullOrEmpty(name) && int.TryParse(txtYear.Text, out int birthYear))
            {
                // Check if the friend does not exist yet
                if (!_friendsDictionary.ContainsKey(name))
                {
                    _friendsDictionary.Add(name, birthYear);

                    // Clear input fields after successful addition
                    txtName.Clear();
                    txtYear.Clear();

                    UpdateUI();
                }
                else
                {
                    MessageBox.Show("This friend is already in the list!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid name and birth year.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // 2. SELECT FRIEND IN LISTBOX
        private void LstFriends_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Verify if an item is actually selected
            if (lstFriends.SelectedItem != null)
            {
                string selectedName = lstFriends.SelectedItem.ToString();

                // Retrieve the birth year from the dictionary using the name
                if (_friendsDictionary.TryGetValue(selectedName, out int birthYear))
                {
                    // Calculate age based on the assignment criteria: (2020 - birthYear)
                    int age = 2020 - birthYear;

                    lblAge.Content = $"{selectedName} is {age} years old.";
                }
            }
            else
            {
                // Clear the label if no item is selected
                lblAge.Content = "";
            }
        }

        // 3. REMOVE FRIEND
        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lstFriends.SelectedItem != null)
            {
                string selectedName = lstFriends.SelectedItem.ToString();

                // Remove the item from the dictionary
                _friendsDictionary.Remove(selectedName);

                UpdateUI();
            }
        }

        // HELPER METHOD: Refreshes the ListBox, updates the counter and button status
        private void UpdateUI()
        {
            // Door .ToList() te gebruiken dwingen we WPF om de ListBox direct te verversen
            lstFriends.ItemsSource = _friendsDictionary.Keys.ToList();

            // Update het aantal vrienden label
            lblNumberOfFriends.Content = $"Number of friends: {_friendsDictionary.Count}";

            // De verwijderknop is alleen klikbaar als er vrienden in de lijst staan
            btnRemove.IsEnabled = _friendsDictionary.Count > 0;
        }
    }
}