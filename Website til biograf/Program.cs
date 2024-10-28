//angiver hvad der bliver brugt
using System;
using System.Collections.Generic;
// Opretter namespace, klasser og voids.
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
                // Udspyt fejlkode og lad dem prøve igen
                Console.WriteLine("Ugyldigt valg. Prøv igen.");
                goto FilmValg;
            }

        SædeValg:
            // Opret en liste med sæderne
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
                // Vis det valgte sæde
                Console.WriteLine($"Du har valgt: {sædeListe[sædeValg - 1]}");
            }
            else
            {
                // Udspyt fejlkode og lad dem prøve igen
                Console.WriteLine("Ugyldigt valg. Prøv igen.");
                goto SædeValg;
            }

        Reservationsvalg:
            // Opret en liste med valg af reservation
            List<string> reservationsliste = new List<string>
            {
                "Ja",
                "Nej"
            };

            // Udskriv menuen med reservationsvalg
            Console.WriteLine("Vil du reservere dette sæde?");
            for (int i = 0; i < reservationsliste.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {reservationsliste[i]}");
            }

            // Læs brugerens input
            Console.Write("Indtast valg (1 for Ja, 2 for Nej): ");
            string input3 = Console.ReadLine();
            int reservationsValg;

            //generer et tilfældigt tal, til reservationsnummer
            Random rnd= new Random();
            int reservationsnummer = rnd.Next(0, 999999999); 
            string formattedReservationsnummer = reservationsnummer.ToString().PadLeft(13, '0');



            // Kontroller om input er et gyldigt tal og inden for det rigtige område
            if (int.TryParse(input3, out reservationsValg) && reservationsValg > 0 && reservationsValg <= reservationsliste.Count)
            {
                // Vis reservationsbekræftelsen
                if (reservationsValg == 1)
                {
                    // Få input med for- og efternavn
                    Console.WriteLine("Indtast fornavn");
                    string fornavn = Console.ReadLine();
                    Console.WriteLine("Indtast efternavn");
                    string efternavn = Console.ReadLine();
                    //udskriver kvittering
                    Console.WriteLine($"Kære {fornavn} {efternavn}, du har reserveret {sædeListe[sædeValg - 1]} til filmen {filmListe[filmValg - 1]}, med reservationsnummeret {formattedReservationsnummer}.");
                }
                else
                {
                    Console.WriteLine("Du valgte ikke at reservere et sæde til den valgte film?");
                }
            }
            else
            {
                // Udspyt fejlkode og lad dem prøve igen
                Console.WriteLine("Ugyldigt valg. Prøv igen.");
                goto Reservationsvalg;
            }

            Console.ReadLine();
        }
    }
}
