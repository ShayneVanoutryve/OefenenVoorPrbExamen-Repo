using System;
using System.Windows;
using System.Windows.Controls;

namespace Prb.Methods.Quiz.Wpf
{
    public partial class MainWindow : Window
    {
        // Globale variabele om de score bij te houden
        private int score = 0;

        public MainWindow()
        {
            InitializeComponent();
            StartToestand();
            KoppelEvents();
        }

        /// <summary>
        /// Brengt de quiz naar de initiële opstartfase.
        /// </summary>
        private void StartToestand()
        {
            score = 0;
            lblScore.Content = score.ToString();

            // Vraag 1 actief en zichtbaar, rest onzichtbaar/collapsed en uitgeschakeld
            BeheerPanel(wrpQuestion1, true, Visibility.Visible);
            BeheerPanel(wrpQuestion2, false, Visibility.Collapsed);
            BeheerPanel(wrpQuestion3, false, Visibility.Collapsed);

            // Standaard feedbackteksten terugzetten
            lblFeedBack1.Content = "Kies het juiste antwoord";
            lblFeedBack2.Content = "Kies het juiste antwoord";
            lblFeedBack3.Content = "Kies het juiste antwoord";

            // Resetknop verbergen bij de start
            btnReset.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Koppelt alle knoppen handmatig aan de juiste Event Handlers.
        /// (Dit bespaart je het typen van Click="" in de XAML-code)
        /// </summary>
        private void KoppelEvents()
        {
            // Vraag 1 knoppen
            btnAnswer1a.Click += BtnAnswer1_Click;
            btnAnswer1b.Click += BtnAnswer1_Click;
            btnAnswer1c.Click += BtnAnswer1_Click;

            // Vraag 2 knoppen
            btnAnswer2a.Click += BtnAnswer2_Click;
            btnAnswer2b.Click += BtnAnswer2_Click;
            btnAnswer2c.Click += BtnAnswer2_Click;

            // Vraag 3 knoppen
            btnAnswer3a.Click += BtnAnswer3_Click;
            btnAnswer3b.Click += BtnAnswer3_Click;
            btnAnswer3c.Click += BtnAnswer3_Click;

            // Reset knop
            btnReset.Click += BtnReset_Click;
        }

        /// <summary>
        /// Centrale herbruikbare methode om de Visibility en IsEnabled van een WrapPanel te beheren.
        /// </summary>
        private void BeheerPanel(WrapPanel panel, bool isEnabled, Visibility visibility)
        {
            panel.IsEnabled = isEnabled;
            panel.Visibility = visibility;
        }

        /// <summary>
        /// Centrale logica om te controleren of het geklikte antwoord juist is, 
        /// de feedback te tonen, het huidige panel te locken en het volgende te openen.
        /// </summary>
        private void VerwerkAntwoord(Button geklikteKnop, string correctAntwoord, Label lblFeedback, WrapPanel huidigPanel, WrapPanel volgendPanel)
        {
            // Haal de tekst van de geklikte knop op (bijv. "Xamarin")
            string gekozenAntwoord = geklikteKnop.Content.ToString();

            // Beoordeel het antwoord
            if (gekozenAntwoord == correctAntwoord)
            {
                lblFeedback.Content = "Goed!";
                score++;
                lblScore.Content = score.ToString();
            }
            else
            {
                lblFeedback.Content = "Fout!";
            }

            // Schakel het huidige panel uit (gebruiker kan geen nieuwe keuze maken)
            BeheerPanel(huidigPanel, false, Visibility.Visible);

            // Activeer het volgende panel indien aanwezig
            if (volgendPanel != null)
            {
                BeheerPanel(volgendPanel, true, Visibility.Visible);
            }
        }

        // ==================== CLICK EVENTS PER VRAAG ====================

        private void BtnAnswer1_Click(object sender, RoutedEventArgs e)
        {
            // Vraag 1: Juiste antwoord is "Xamarin"
            Button geklikteKnop = (Button)sender;
            VerwerkAntwoord(geklikteKnop, "Xamarin", lblFeedBack1, wrpQuestion1, wrpQuestion2);
        }

        private void BtnAnswer2_Click(object sender, RoutedEventArgs e)
        {
            // Vraag 2: Juiste antwoord is ".Net Core"
            Button geklikteKnop = (Button)sender;
            VerwerkAntwoord(geklikteKnop, ".Net Core", lblFeedBack2, wrpQuestion2, wrpQuestion3);
        }

        private void BtnAnswer3_Click(object sender, RoutedEventArgs e)
        {
            // Vraag 3: Juiste antwoord is "Xamarin"
            Button geklikteKnop = (Button)sender;

            // Er is geen volgend panel meer, dus we geven 'null' mee
            VerwerkAntwoord(geklikteKnop, "Xamarin", lblFeedBack3, wrpQuestion3, null);

            // Quiz is klaar, toon de reset-knop
            btnReset.Visibility = Visibility.Visible;
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            // Reset de volledige applicatie naar startpositie
            StartToestand();
        }
    }
}