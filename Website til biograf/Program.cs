using System;
using System.Collections.Generic;

namespace Website_til_styring_af_biograf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Opret en liste af film
            List<string> filmListe = new List<string>
            {
                "How To Train Your Dragon 2",
                "Shrek 4",
                "Fat Albert"
            };

            // Udskriv menuen med filmene
            Console.WriteLine("Vælg en film ved at indtaste nummeret:");
            for (int i = 0; i < filmListe.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {filmListe[i]}");
            }

            // Læs brugerens input
            Console.Write("Indtast filmnummer: ");
            string input = Console.ReadLine();
            int filmValg;

            // Kontroller om input er et gyldigt tal og inden for det rigtige område
            if (int.TryParse(input, out filmValg) && filmValg > 0 && filmValg <= filmListe.Count)
            {
                // Vis den valgte film
                Console.WriteLine($"Du har valgt: {filmListe[filmValg - 1]}");
            }
            else
            {
                Console.WriteLine("Ugyldigt valg. Prøv igen.");
            }

            Console.ReadLine();
        }
    }
}
