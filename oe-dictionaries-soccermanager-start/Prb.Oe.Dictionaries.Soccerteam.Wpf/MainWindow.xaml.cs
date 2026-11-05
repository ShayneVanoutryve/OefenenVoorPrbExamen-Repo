
using System.Collections.Generic;
using System.Windows;

namespace Prb.Oe.Dictionaries.Soccerteam.Wpf
{
    public partial class MainWindow : Window
    {
        // Dictionaries declareren
        private Dictionary<int, string> team = new Dictionary<int, string>();
        private Dictionary<int, string> teamNextGame = new Dictionary<int, string>();
        private Dictionary<int, string> reserveNextGame = new Dictionary<int, string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Venster laden
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadClubBruggePlayers();
            UpdateTeamNumbersListbox();
            UpdateTeamListbox();
            UpdateTeamNextGameListbox();
            UpdateReservesNextGameListbox();
        }
        private void LoadClubBruggePlayers()
        {
            team.Add(1, "Yann Sommer");
            team.Add(3, "Lee Han-Beom");
            team.Add(4, "Joel Ordóñez");
            team.Add(7, "Nicolò Tresoldi");
            team.Add(8, "Freddie Potts");
            team.Add(9, "Carlos Forbs");
            team.Add(10, "Hugo Vetlesen");
            team.Add(11, "Jan Virgili");
            team.Add(16, "Cheveyo Tsawa");
            team.Add(17, "Romeo Vermant");
            team.Add(20, "Hans Vanaken");
            team.Add(27, "Wisdom Mike");
            team.Add(29, "Nordin Jackers");
            team.Add(32, "Matteo Dams");
            team.Add(39, "Milan Robberechts");
            team.Add(41, "Hugo Siquet");
            team.Add(44, "Brandon Mechele");
            team.Add(54, "Samba Coulibaly");
            team.Add(58, "Jorne Spileers");
            team.Add(62, "Lynnt Audoor");
            team.Add(64, "Kyriani Sabbe");
            team.Add(65, "Joaquin Seys");
            team.Add(67, "Mamadou Diakhon");
            team.Add(71, "Axl De Corte");
            team.Add(77, "Andrej Vasovic");
            team.Add(80, "Félix Lemaréchal");
            team.Add(81, "Argus Vanden Driessche");
            team.Add(85, "Tian Nai Koren");
            team.Add(86, "Gianluca Okon-Engstler");
        }
        private void CheckSelection()
        {
            if (teamNextGame.Count > 11)
            {
                MessageBox.Show("De opstelling mag maximaal 11 spelers bevatten.");
                return;
            }

            if (reserveNextGame.Count < 7)
            {
                MessageBox.Show("Je moet minstens 7 reserves selecteren.");
                return;
            }

            if (reserveNextGame.Count > 9)
            {
                MessageBox.Show("Je mag maximaal 9 reserves selecteren.");
                return;
            }

            MessageBox.Show("Je selectie is geldig!");
        }
        private void BtnCheckSelection_Click(object sender, RoutedEventArgs e)
        {
            CheckSelection();
        }
        // Speler toevoegen aan het volledige team
        private void BtnAddPlayerToTeam_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtPlayerNumber.Text, out int playerNumber))
            {
                MessageBox.Show("Vul een geldig rugnummer in.");
                return;
            }

            if (playerNumber <= 0)
            {
                MessageBox.Show("Het rugnummer moet groter zijn dan 0.");
                return;
            }

            if (team.ContainsKey(playerNumber) ||
                teamNextGame.ContainsKey(playerNumber) ||
                reserveNextGame.ContainsKey(playerNumber))
            {
                MessageBox.Show("Dit rugnummer is al in gebruik.");
                return;
            }

            string playerName = txtPlayerName.Text.Trim();

            if (playerName == "")
            {
                MessageBox.Show("Geef een naam in.");
                return;
            }

            team.Add(playerNumber, playerName);

            UpdateTeamNumbersListbox();
            UpdateTeamListbox();

            txtPlayerName.Clear();
            txtPlayerNumber.Clear();
        }

        // Details tonen bij selectie van een rugnummer
        private void LstTeamNumbers_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lstTeamNumbers.SelectedItem != null)
            {
                int playerNumber = (int)lstTeamNumbers.SelectedItem;
                lblPlayerNumber.Content = playerNumber;
                lblPlayerName.Content = team[playerNumber];
            }
        }

        private void LstTeamNextGame_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lstTeamNextGame.SelectedItem != null)
            {
                int playerNumber = (int)lstTeamNextGame.SelectedItem;
                lblPlayerNumber.Content = playerNumber;
                lblPlayerName.Content = teamNextGame[playerNumber];
            }
            if (teamNextGame.Count >= 11)
            {
                MessageBox.Show("De opstelling mag maximaal 11 spelers bevatten.");
                return;
            }
        }

        private void LstReserveNextGame_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lstReserveNextGame.SelectedItem != null)
            {
                int playerNumber = (int)lstReserveNextGame.SelectedItem;
                lblPlayerNumber.Content = playerNumber;
                lblPlayerName.Content = reserveNextGame[playerNumber];
            }
            if (reserveNextGame.Count >= 9)
            {
                MessageBox.Show("Je mag maximaal 9 reserves meenemen.");
                return;
            }
        }

        // Speler toevoegen aan de opstelling
        private void BtnAddPlayerToTeamNextGame_Click(object sender, RoutedEventArgs e)
        {
            if (lstTeamNumbers.SelectedItem == null)
            {
                MessageBox.Show("Selecteer eerst een speler uit het team.");
                return;
            }
            if (teamNextGame.Count >= 11)
            {
                MessageBox.Show("De opstelling zit al vol (maximaal 11 spelers).");
                return;
            }

            int playerNumber = (int)lstTeamNumbers.SelectedItem;
            string playerName = team[playerNumber];

            teamNextGame.Add(playerNumber, playerName);
            team.Remove(playerNumber);

            UpdateTeamNumbersListbox();
            UpdateTeamListbox();
            UpdateTeamNextGameListbox();
        }

        // Speler toevoegen aan de reserves
        private void BtnAddPlayerToReserveNextGame_Click(object sender, RoutedEventArgs e)
        {
            if (lstTeamNumbers.SelectedItem == null)
            {
                MessageBox.Show("Selecteer eerst een speler uit het team.");
                return;
            }
            if (reserveNextGame.Count >= 9)
            {
                MessageBox.Show("Je mag maximaal 9 reserves meenemen.");
                return;
            }

            int playerNumber = (int)lstTeamNumbers.SelectedItem;
            string playerName = team[playerNumber];

            reserveNextGame.Add(playerNumber, playerName);
            team.Remove(playerNumber);

            UpdateTeamNumbersListbox();
            UpdateTeamListbox();
            UpdateReservesNextGameListbox();
        }

        // Speler verwijderen uit de opstelling
        private void BtnRemovePlayerFromTeamNextGame_Click(object sender, RoutedEventArgs e)
        {
            if (lstTeamNextGame.SelectedItem == null)
            {
                MessageBox.Show("Selecteer eerst een speler uit de opstelling.");
                return;
            }

            int playerNumber = (int)lstTeamNextGame.SelectedItem;
            string playerName = teamNextGame[playerNumber];

            team.Add(playerNumber, playerName);
            teamNextGame.Remove(playerNumber);

            UpdateTeamNumbersListbox();
            UpdateTeamListbox();
            UpdateTeamNextGameListbox();
        }

        // Speler verplaatsen van opstelling naar reserves
        private void BtnMovePlayerToReserveNextGame_Click(object sender, RoutedEventArgs e)
        {
            if (lstTeamNextGame.SelectedItem == null)
            {
                MessageBox.Show("Selecteer eerst een speler uit de opstelling.");
                return;
            }
            if (reserveNextGame.Count >= 9)
            {
                MessageBox.Show("Je mag maximaal 9 reserves meenemen.");
                return;
            }

            int playerNumber = (int)lstTeamNextGame.SelectedItem;
            string playerName = teamNextGame[playerNumber];

            reserveNextGame.Add(playerNumber, playerName);
            teamNextGame.Remove(playerNumber);

            UpdateTeamNextGameListbox();
            UpdateReservesNextGameListbox();
        }

        // Speler verwijderen uit de reserves
        private void BtnRemovePlayerFromReserveNextGame_Click(object sender, RoutedEventArgs e)
        {
            if (lstReserveNextGame.SelectedItem == null)
            {
                MessageBox.Show("Selecteer eerst een speler uit de reserves.");
                return;
            }

            int playerNumber = (int)lstReserveNextGame.SelectedItem;
            string playerName = reserveNextGame[playerNumber];

            team.Add(playerNumber, playerName);
            reserveNextGame.Remove(playerNumber);

            UpdateTeamNumbersListbox();
            UpdateTeamListbox();
            UpdateReservesNextGameListbox();
        }

        // Speler verplaatsen van reserves naar opstelling
        private void BtnMovePlayerToTeamNextGame_Click(object sender, RoutedEventArgs e)
        {
            if (lstReserveNextGame.SelectedItem == null)
            {
                MessageBox.Show("Selecteer eerst een speler uit de reserves.");
                return;
            }
            if (teamNextGame.Count >= 11)
            {
                MessageBox.Show("De opstelling zit al vol (maximaal 11 spelers).");
                return;
            }

            int playerNumber = (int)lstReserveNextGame.SelectedItem;
            string playerName = reserveNextGame[playerNumber];

            teamNextGame.Add(playerNumber, playerName);
            reserveNextGame.Remove(playerNumber);

            UpdateTeamNextGameListbox();
            UpdateReservesNextGameListbox();
        }

        // Listboxen bijwerken
        private void UpdateTeamNumbersListbox()
        {
            lstTeamNumbers.Items.Clear();

            foreach (int playerNumber in team.Keys)
            {
                lstTeamNumbers.Items.Add(playerNumber);
            }
        }

        private void UpdateTeamListbox()
        {
            lstTeam.Items.Clear();

            foreach (string playerName in team.Values)
            {
                lstTeam.Items.Add(playerName);
            }
        }

        private void UpdateTeamNextGameListbox()
        {
            lstTeamNextGame.Items.Clear();

            foreach (int playerNumber in teamNextGame.Keys)
            {
                lstTeamNextGame.Items.Add(playerNumber);
            }
        }

        private void UpdateReservesNextGameListbox()
        {
            lstReserveNextGame.Items.Clear();

            foreach (int playerNumber in reserveNextGame.Keys)
            {
                lstReserveNextGame.Items.Add(playerNumber);
            }
        }
    }
}

