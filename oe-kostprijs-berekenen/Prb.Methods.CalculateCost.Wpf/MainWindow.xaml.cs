using System;
using System.Windows;

namespace Prb.Methods.CalculateCost.Wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Methode om de totaalprijs te berekenen op basis van dagprijs en aantal dagen.
        /// </summary>
        private decimal CalculateTotalPrice(decimal dailyPrice, int numberOfDays)
        {
            return dailyPrice * numberOfDays;
        }

        /// <summary>
        /// Event handler voor de bereken-knop.
        /// </summary>
        private void btnCalculatTotalPrice_Click(object sender, RoutedEventArgs e)
        {
            // 1. Probeer de dagprijs uit de tekstbox te lezen en te converteren
            if (!decimal.TryParse(txtDayPrice.Text, out decimal dailyPrice))
            {
                MessageBox.Show("Voer een geldige dagprijs in.", "Foutieve invoer", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // 2. Probeer het aantal dagen uit de tekstbox te lezen en te converteren
            if (!int.TryParse(txtNumberOfDays.Text, out int numberOfDays))
            {
                MessageBox.Show("Voer een geldig aantal dagen in.", "Foutieve invoer", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // 3. Bereken de totaalprijs via de methode
            decimal totalPrice = CalculateTotalPrice(dailyPrice, numberOfDays);

            // 4. Toon het resultaat in het label (geformatteerd als valuta)
            lblTotalPrice.Content = totalPrice.ToString("C");
        }

        /// <summary>
        /// Event handler voor de slider. Wordt uitgevoerd bij elke wijziging van de waarde.
        /// </summary>
        private void sldNumberOfDays_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Omdat de componenten initialiseren bij het opstarten, controleren we of txtNumberOfDays al bestaat
            if (txtNumberOfDays != null)
            {
                // Converteer de double waarde van de slider naar een afgerond geheel getal (int)
                int days = Convert.ToInt32(sldNumberOfDays.Value);
                txtNumberOfDays.Text = days.ToString();
            }
        }
    }
}