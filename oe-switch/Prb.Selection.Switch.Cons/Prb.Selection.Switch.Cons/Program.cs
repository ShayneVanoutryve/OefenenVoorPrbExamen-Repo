using System;

namespace Prb.Selection.SwitchOefening.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Vraag invoer aan de gebruiker
            Console.Write("Voer een maandnummer in (1 tot 12): ");
            string input = Console.ReadLine();

            // Controleer of de invoer een geldig getal is
            if (int.TryParse(input, out int monthNumber))
            {
                string season;

                // De switch-constructie controleert de waarde van maandNummer
                switch (monthNumber)
                {
                    // Maanden december, januari en februari
                    case 12:
                    case 1:
                    case 2:
                        season = "Winter";
                        break; // Beëindigt de switch

                    // Maanden maart, april en mei
                    case 3:
                    case 4:
                    case 5:
                        season = "Spring";
                        break;

                    // Maanden juni, juli en augustus
                    case 6:
                    case 7:
                    case 8:
                        season = "Summer";
                        break;

                    // Maanden september, oktober en november
                    case 9:
                    case 10:
                    case 11:
                        season = "Autumn";
                        break;

                    // Vangnet voor alle andere getallen (bijv. 0 of 15)
                    default:
                        season = "Onbekend (ongeldig maandnummer)";
                        break;
                }

                // Toon het resultaat aan de gebruiker
                Console.WriteLine($"Het seizoen voor maand {monthNumber} is: {season}");
            }
            else
            {
                Console.WriteLine("Foutieve invoer. Voer aanzienlijk een getal in.");
            }

            // Zorgt ervoor dat de console open blijft
            Console.ReadLine();
        }
    }
}