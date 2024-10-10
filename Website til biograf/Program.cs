using System;
using System.Collections.Generic;

namespace Website_til_styring_af_biograf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Indtast navn");
            Console.ReadLine();
            Console.WriteLine("Indtast kodeord");
            Console.ReadLine();
            // Opret en liste af film
            List<string> filmListe = new List<string>
            {
                "How To Train Your Dragon 2",
                "Shrek 4",
                "Fat Albert"
            };
        FilmValg:
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
                goto FilmValg;
            }
            SædeValg:
            List<string> sædeListe = new List<string>
                {
                    "Sædet helt til venstre",
                    "Sædet til venstre fra midten",
                    "Sædet i midten",
                    "Sædet til højre fra midten",
                    "Sædet helt til højre"
                };
            // Udskriv menuen med sæderne
            Console.WriteLine("Vælg et sæde ved at indtaste nummeret:");
            for (int i = 0; i < sædeListe.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sædeListe[i]}");
            }

            // Læs brugerens input
            Console.Write("Indtast filmnummer: ");
            string input2 = Console.ReadLine();
            int sædeValg;

            // Kontroller om input er et gyldigt tal og inden for det rigtige område
            if (int.TryParse(input2, out sædeValg) && sædeValg > 0 && sædeValg <= sædeListe.Count)
            {
                // Vis den valgte film
                Console.WriteLine($"Du har valgt: {sædeListe[sædeValg - 1]}");
            }
            else
            {
                Console.WriteLine("Ugyldigt valg. Prøv igen.");

                goto SædeValg;
            }
            Console.ReadLine();
        }
    }
}

