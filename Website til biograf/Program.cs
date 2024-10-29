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
            //laver filmvalg
        FilmValg:
            Console.WriteLine("Vælg en film du gerne vil se, ved at indtaste nummeret:");
            for (int i = 0; i < filmListe.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {filmListe[i]}");
            }

            Console.Write("Indtast filmnummer: ");
            string input = Console.ReadLine();
            int filmValg;

            if (int.TryParse(input, out filmValg) && filmValg > 0 && filmValg <= filmListe.Count)
            {
                Console.WriteLine($"Du har valgt: {filmListe[filmValg - 1]}");
            }
            else
            {
                Console.WriteLine("Ugyldigt valg. Prøv igen.");
                goto FilmValg;
            }
            SV:
            // Spørg hvor mange sæder brugeren vil reservere
            Console.WriteLine("Hvor mange sæder vil du reservere?");
            string antalSæderInput = Console.ReadLine();
            int antalSæder;

            // Kontroller om input er et gyldigt tal og om det er indenfor det tilladte antal
            if (!int.TryParse(antalSæderInput, out antalSæder) || antalSæder <= 0 || antalSæder > 5)
            {
                Console.WriteLine("Ugyldigt antal. Du kan maksimalt reservere 5 sæder. Prøv igen.");
                goto SV;
            }

            // Liste over tilgængelige sæder
            List<string> sædeListe = new List<string>
            {
                "Sæde nr. 1",
                "Sæde nr. 2",
                "Sæde nr. 3",
                "Sæde nr. 4",
                "Sæde nr. 5"
            };

            List<string> valgteSæder = new List<string>();
            //laver sædevalg
            for (int i = 0; i < antalSæder; i++)
            {
            SædeValg:
                Console.WriteLine("Vælg et sæde ved at indtaste nummeret:");
                for (int j = 0; j < sædeListe.Count; j++)
                {
                    if (!valgteSæder.Contains(sædeListe[j]))
                    {
                        Console.WriteLine($"{j + 1}. {sædeListe[j]}");
                    }
                }

                Console.Write("Indtast sædenummer: ");
                string inputSV = Console.ReadLine();
                int sædeValg;

                if (int.TryParse(inputSV, out sædeValg) && sædeValg > 0 && sædeValg <= sædeListe.Count && !valgteSæder.Contains(sædeListe[sædeValg - 1]))
                {
                    valgteSæder.Add(sædeListe[sædeValg - 1]);
                    Console.WriteLine($"Du har valgt: {sædeListe[sædeValg - 1]}");
                }
                else
                {
                    Console.WriteLine("Ugyldigt valg eller sæde allerede valgt. Prøv igen.");
                    goto SædeValg;
                }
            }
            //Laver reservationsvalg
        Reservationsvalg:
            List<string> reservationsliste = new List<string>
            {
                "Ja",
                "Nej"
            };

            Console.WriteLine("Vil du reservere de valgte sæder?");
            for (int i = 0; i < reservationsliste.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {reservationsliste[i]}");
            }

            Console.Write("Indtast valg (1 for Ja, 2 for Nej): ");
            string input3 = Console.ReadLine();
            int reservationsValg;
            Random rnd = new Random();
            int reservationsnummer = rnd.Next(0, 999999999); // Generer et 9-cifret nummer
            string formattedReservationsnummer = reservationsnummer.ToString().PadLeft(13, '0');
            
            //lav et reservationsvalg med evt. reservationsnummer.
            if (int.TryParse(input3, out reservationsValg) && reservationsValg > 0 && reservationsValg <= reservationsliste.Count)
            {
                if (reservationsValg == 1)
                {
                    Console.WriteLine("Indtast fornavn");
                    string fornavn = Console.ReadLine();
                    Console.WriteLine("Indtast efternavn");
                    string efternavn = Console.ReadLine();
                    Console.WriteLine($"Kære {fornavn} {efternavn}, du har reserveret følgende sæder til filmen {filmListe[filmValg - 1]}: {string.Join(", ", valgteSæder)}. Dit reservationsnummer er {formattedReservationsnummer}.");
                }
                else
                {
                    Console.WriteLine("Du valgte ikke at reservere sæder til den valgte film.");
                    goto FilmValg;
                }
            }
            else
            {
                Console.WriteLine("Ugyldigt valg. Prøv igen.");
                goto Reservationsvalg;
            }

            Console.ReadLine();
        }
    }
}
