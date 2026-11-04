using System;

namespace Prb.Selection.Switch.Cons
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

                // TODO: Bepaal het seizoen op basis van het maandnummer met een switch-constructie
                // Maanden 12, 1, 2 = Winter
                // Maanden 3, 4, 5 = Lente
                // Maanden 6, 7, 8 = Zomer
                // Maanden 9, 10, 11 = Herfst

                switch (monthNumber)
                {
                    // ZET HIER JE CASES, BREAKS EN DEFAULT NEER

                    default:
                        season = "Onbekend (ongeldig maandnummer)";
                        break;
                }

                // Toon het resultaat
                Console.WriteLine($"Het seizoen voor maand {monthNumber} is: {season}");
            }
            else
            {
                Console.WriteLine("Foutieve invoer. Voer aanzienlijk een getal in.");
            }

            // Wacht op de gebruiker om af te sluiten
            Console.ReadLine();
        }
    }
}