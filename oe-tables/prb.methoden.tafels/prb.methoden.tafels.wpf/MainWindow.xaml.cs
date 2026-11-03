using System;
using System.Windows;
using System.Windows.Controls;

namespace prb.methoden.tafels.wpf
{
    public partial class MainWindow : Window
    {
        // VEREISTE: 3 klassevariabelen
        private Random rnd;
        private int tafel;
        private int vermenigvuldiger;

        public MainWindow()
        {
            InitializeComponent();

            // Handmatige eventkoppeling zodat je de XAML niet hoeft aan te passen
            lstTables.SelectionChanged += lstTables_SelectionChanged;
            btnOK.Click += btnOK_Click;
        }

        // Startsituatie: Uitgevoerd wanneer het venster laadt (gekoppeld in jouw XAML via Loaded="Window_Loaded")
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialiseer de random generator (slechts 1 keer aanmaken!)
            rnd = new Random();

            // Vul lstTables met de getallen 1 tot en met 10
            for (int i = 1; i <= 10; i++)
            {
                lstTables.Items.Add(i);
            }

            // Verberg wrpRight bij de opstart
            wrpRight.Visibility = Visibility.Hidden;
        }

        // Werking: Uitgevoerd wanneer een getal in lstTables wordt aangeklikt
        private void lstTables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstTables.SelectedItem != null)
            {
                // Sla de geselecteerde tafel op in de klassevariabele
                tafel = Convert.ToInt32(lstTables.SelectedItem);

                // Maak wrpRight zichtbaar
                wrpRight.Visibility = Visibility.Visible;

                // Maak lstFeedBack leeg
                lstFeedBack.Items.Clear();

                // Genereer de eerste vraag
                MaakVraag();
            }
        }

        // VEREISTE: Eigen methode voor het aanmaken van de vraag
        private void MaakVraag()
        {
            // Genereer een random getal van 1 tot 10 (bovengrens 11 telt niet mee)
            vermenigvuldiger = rnd.Next(1, 11);

            // Vul lblTable en lblMultiplier
            lblTable.Content = tafel.ToString();
            lblMultiplier.Content = vermenigvuldiger.ToString();

            // Stel txtAnswer in op "0" en geef deze textbox de focus
            txtAnswer.Text = "0";
            txtAnswer.Focus();
            txtAnswer.SelectAll(); // Selecteert direct de '0' zodat de gebruiker meteen kan typen
        }

        // Werking: Uitgevoerd wanneer de gebruiker op btnOK klikt
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            // Lees het antwoord van de gebruiker uit
            int ingevoerdAntwoord = 0;
            int.TryParse(txtAnswer.Text, out ingevoerdAntwoord);

            // Bereken de juiste oplossing
            int juisteOplossing = tafel * vermenigvuldiger;

            // Bepaal of het antwoord juist of fout is voor de feedback
            string resultaatTekst = (ingevoerdAntwoord == juisteOplossing) ? "Juist!" : "Fout!";

            // VEREISTE: Voeg minstens 3 lijnen bovenaan toe via de Insert-methode (index 0)
            // Note: We voegen ze in omgekeerde volgorde toe aan index 0 zodat ze juist omhoog komen te staan
            lstFeedBack.Items.Insert(0, "=================================");
            lstFeedBack.Items.Insert(0, $"Oplossing: {tafel} x {vermenigvuldiger} = {juisteOplossing} ({resultaatTekst})");
            lstFeedBack.Items.Insert(0, $"Jouw antwoord: {ingevoerdAntwoord}");

            // Maak onmiddellijk een nieuwe vraag aan (zonder lstFeedBack leeg te maken)
            MaakVraag();
        }
    }
}