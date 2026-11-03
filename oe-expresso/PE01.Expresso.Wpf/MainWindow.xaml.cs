using System;
using System.Windows;
using System.Windows.Controls;

namespace PE01.Expresso.Wpf
{
    public partial class MainWindow : Window
    {
        // CONSTANT: All coffees cost the same
        const decimal CoffeePrice = 3.50m;

        // GLOBAL VARIABLES (Class scope for statistics and queue tracking)
        int totalOrders = 0;
        int totalCoffeesSold = 0;
        decimal totalRevenue = 0;

        // Global variable to remember the single queued order summary
        string queuedOrderText = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Triggered when the window loads. Ideal for setting default values.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Populate coffee sizes into the ComboBox
            cmbSize.Items.Add("Small");
            cmbSize.Items.Add("Medium");
            cmbSize.Items.Add("Large");
            cmbSize.SelectedIndex = 1; // Default to Medium

            // Populate initial coffee assortment into the ListBox
            lstCoffees.Items.Add("Espresso");
            lstCoffees.Items.Add("Latte Macchiato");
            lstCoffees.Items.Add("Cappuccino");
            lstCoffees.Items.Add("Americano");
            lstCoffees.SelectedIndex = 0; // Select first one by default

            // Connect click events that weren't linked in XAML
            btnAdd.Click += BtnAdd_Click;
            btnEmptyQueue.Click += BtnEmptyQueue_Click;

            // Set up initial state
            SetDefaultValues();
            UpdateStatisticsUi();
            btnEmptyQueue.IsEnabled = false; // Disable until something is queued
        }

        /// <summary>
        /// Resets the input fields for usability.
        /// </summary>
        void SetDefaultValues()
        {
            txtCups.Text = "1";
            txtTip.Text = "0,00";
            txtNewCoffee.Text = "";
            txtCups.Focus();
        }

        /// <summary>
        /// Calculates the total price of the order including the tip.
        /// </summary>
        decimal CalculateOrderPrice(int amount, decimal tip)
        {
            return (amount * CoffeePrice) + tip;
        }

        /// <summary>
        /// Formats the summary text line for any order.
        /// </summary>
        string GenerateOrderText(string size, string coffeeType, int amount)
        {
            return $"{amount}x {size} {coffeeType}";
        }

        /// <summary>
        /// Updates all statistics labels in the UI.
        /// </summary>
        void UpdateStatisticsUi()
        {
            lblNumberOfCustomers.Content = totalOrders.ToString();
            lblCoffeesSold.Content = totalCoffeesSold.ToString();
            lblProfit.Content = $"€ {totalRevenue.ToString("0.00")}";
        }

        // ==========================================
        // EVENT HANDLERS (WPF Controls Interfacing)
        // ==========================================

        /// <summary>
        /// Lets the cashier add a completely new coffee type to the assortment ListBox.
        /// </summary>
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string newCoffee = txtNewCoffee.Text;
            lstCoffees.Items.Add(newCoffee);
            SetDefaultValues();
        }

        /// <summary>
        /// Handles a direct order when "Bestel" is clicked.
        /// </summary>
        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            // 1. Read values from inputs
            int amount = int.Parse(txtCups.Text);
            decimal tip = decimal.Parse(txtTip.Text);
            string selectedSize = cmbSize.SelectedItem.ToString();
            string selectedCoffee = lstCoffees.SelectedItem.ToString();

            // 2. Compute order math using methods
            decimal priceToPay = CalculateOrderPrice(amount, tip);
            string orderSummary = GenerateOrderText(selectedSize, selectedCoffee, amount);

            // 3. Adjust data state
            totalOrders++;
            totalCoffeesSold += amount;
            totalRevenue += priceToPay;

            // 4. Output to historical orders ListBox (lstOrders)
            lstOrders.Items.Add($"{orderSummary} (Total: € {priceToPay.ToString("0.00")})");

            // 5. Clean up UI
            UpdateStatisticsUi();
            SetDefaultValues();
        }

        /// <summary>
        /// Places the current configuration into the single-use queue.
        /// </summary>
        private void BtnQueue_Click(object sender, RoutedEventArgs e)
        {
            int amount = int.Parse(txtCups.Text);
            decimal tip = decimal.Parse(txtTip.Text);
            string selectedSize = cmbSize.SelectedItem.ToString();
            string selectedCoffee = lstCoffees.SelectedItem.ToString();

            decimal priceToPay = CalculateOrderPrice(amount, tip);

            // Customer pays IMMEDIATELY according to specification
            totalOrders++;
            totalCoffeesSold += amount;
            totalRevenue += priceToPay;
            UpdateStatisticsUi();

            // Save details internally
            queuedOrderText = GenerateOrderText(selectedSize, selectedCoffee, amount) + $" (Paid: € {priceToPay.ToString("0.00")})";

            // DYNAMICALLY ADD TEXT TO STACKPANEL (What you asked in your first question!)
            // We insert it at index 1 so it stands neatly between the label and the button.
            TextBlock txtQueueDisplay = new TextBlock();
            txtQueueDisplay.Text = $" [{queuedOrderText}] ";
            txtQueueDisplay.VerticalAlignment = VerticalAlignment.Center;
            txtQueueDisplay.Margin = new Thickness(5, 0, 5, 0);
            stpQueue.Children.Insert(1, txtQueueDisplay);

            // Lock queue button so it is "only 1x available simultaneously" (No if-else needed!)
            btnQueue.IsEnabled = false;
            btnEmptyQueue.IsEnabled = true;

            SetDefaultValues();
        }

        /// <summary>
        /// Clears the queue and pushes the queued item to the final list.
        /// </summary>
        private void BtnEmptyQueue_Click(object sender, RoutedEventArgs e)
        {
            // Move item to the final orders history list
            lstOrders.Items.Add(queuedOrderText + " [ON DEMAND DELIVERED]");

            // Wipe out the dynamic TextBlock from the StackPanel's Children collection
            // Index 1 is the TextBlock we inserted earlier!
            stpQueue.Children.RemoveAt(1);

            // Reset variables and swap button accessibility back
            queuedOrderText = "";
            btnQueue.IsEnabled = true;
            btnEmptyQueue.IsEnabled = false;
        }
    }
}