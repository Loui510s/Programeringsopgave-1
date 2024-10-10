//bestem hvad der bliver brugt
using System;
using System.Collections.Generic;
//lav namespace
namespace Website_til_styring_af_biograf
{
    //opret klasse
    internal class Program
    {
        //opret static void
        static void Main(string[] args)
        {
            //få input med navn og kode
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
            Console.WriteLine("Vælg en film du gerne vil se, ved at indtaste nummeret:");
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
                //udspyt fejlkode og lad dem prøve igen
                Console.WriteLine("Ugyldigt valg. Prøv igen.");
                goto FilmValg;
            }
            SædeValg:
            //opret en liste med sæderne
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
            Console.Write("Indtast sædenummer: ");
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
                //udspyt fejlkode og lad dem prøve igen
                Console.WriteLine("Ugyldigt valg. Prøv igen.");

                goto SædeValg;
            }
            //opret en liste med valg af reservation
            List<string> reservationsliste = new List<string>
                {
                    "Ja",
                    "Nej"
                };
            //Udskriv menuen med sæderne
            for (int i = 0; i < reservationsliste.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {reservationsliste[i]}");
            }
         

      
            Console.ReadLine();
        }
    }
}

