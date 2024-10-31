using System;
using System.Collections.Generic;

namespace BiografSystem
{
    //laver relevant klasse for reservation af sæde 
    internal class Film
    {
        public string Navn { get; set; }
        public List<string> Sæder { get; private set; } = new List<string> { "Sæde nr. 1", "Sæde nr. 2", "Sæde nr. 3", "Sæde nr. 4", "Sæde nr. 5" };
    }
    //laver relevant klasse for reservation af film
    internal class Reservation
    {
        public Film Film { get; set; }
        public List<string> Seats { get; set; }
        public string ReservationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    //laver relevant klasse for at kunne foretage en bestilling bestille
    internal class BestillingHandler
    {
        private List<Reservation> reservations = new List<Reservation>();
        private List<Film> filmListe = new List<Film>
        {
            new Film { Navn = "How To Train Your Dragon 2" },
            new Film { Navn = "Shrek 4" },
            new Film { Navn = "Fat Albert" }
        };

        public void Reserve()
        {
            //laver filmvalg
        FilmValg:
            Console.WriteLine("Vælg en film eller gå tilbage til hovedmenuen:");
            Console.WriteLine("0. Tilbage til hovedmenuen");
            for (int i = 0; i < filmListe.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {filmListe[i].Navn}");
            }

            int filmValg = VælgFilm();
            if (filmValg == 0) return;  // Gå tilbage til hovedmenuen
            if (filmValg == -1) goto FilmValg;

            Film valgtFilm = filmListe[filmValg - 1];

        AntalSæderValg:
            int antalSæder = HentAntalSæder();
            if (antalSæder == -1) goto AntalSæderValg;

            List<string> valgteSæder = HentSæder(valgtFilm, antalSæder);
            if (valgteSæder == null) goto AntalSæderValg;

            string reservationNumber = GenererReservationsnummer();

            Console.Write("Indtast fornavn (eller 0 for at gå til hovedmenu): ");
            string fornavn = Console.ReadLine();
            if (fornavn == "0") return;  // Gå tilbage til hovedmenuen
            Console.Write("Indtast efternavn: ");
            string efternavn = Console.ReadLine();

            reservations.Add(new Reservation
            {
                Film = valgtFilm,
                Seats = valgteSæder,
                ReservationNumber = reservationNumber,
                FirstName = fornavn,
                LastName = efternavn
            });

            Console.WriteLine($"Reservation oprettet med nummer {reservationNumber} for {valgtFilm.Navn}. Sæder: {string.Join(", ", valgteSæder)}");
        }

        public void Afreserve()
        {
        Afbestilling:
            Console.Write("Indtast reservationsnummer (eller 0 for at gå til hovedmenu): ");
            string reservationsNummer = Console.ReadLine();
            if (reservationsNummer == "0") return;  // Gå tilbage til hovedmenuen

            var reservation = reservations.Find(r => r.ReservationNumber == reservationsNummer);
            if (reservation != null)
            {
                reservations.Remove(reservation);
                Console.WriteLine($"Reservation {reservationsNummer} er afbestilt.");
            }
            else
            {
                Console.WriteLine("Ingen reservation fundet med det nummer. Prøv igen.");
                goto Afbestilling;
            }
        }

        private int VælgFilm()
        {
            Console.Write("Indtast filmnummer (eller 0 for at gå til hovedmenu): ");
            if (int.TryParse(Console.ReadLine(), out int filmValg) && filmValg >= 0 && filmValg <= filmListe.Count)
            {
                return filmValg;
            }
            Console.WriteLine("Ugyldigt valg. Prøv igen.");
            return -1;
        }

        private int HentAntalSæder()
        {
            Console.Write("Hvor mange sæder vil du reservere? (maks. 5, eller 0 for at gå til hovedmenu): ");
            if (int.TryParse(Console.ReadLine(), out int antalSæder) && (antalSæder == 0 || (antalSæder > 0 && antalSæder <= 5)))
            {
                if (antalSæder == 0) return 0; // Gå tilbage til hovedmenuen
                return antalSæder;
            }
            Console.WriteLine("Ugyldigt antal. Prøv igen.");
            return -1;
        }

        private List<string> HentSæder(Film film, int antalSæder)
        {
            List<string> valgteSæder = new List<string>();
            int i = 0;

        SædeValg:
            if (i < antalSæder)
            {
                Console.WriteLine("Vælg et sæde eller indtast 0 for at gå til hovedmenuen:");
                for (int j = 0; j < film.Sæder.Count; j++)
                {
                    if (!valgteSæder.Contains(film.Sæder[j]))
                    {
                        Console.WriteLine($"{j + 1}. {film.Sæder[j]}");
                    }
                }

                string input = Console.ReadLine();
                if (input == "0") return null;  // Gå tilbage til hovedmenuen

                if (int.TryParse(input, out int sædeValg) && sædeValg > 0 && sædeValg <= film.Sæder.Count && !valgteSæder.Contains(film.Sæder[sædeValg - 1]))
                {
                    valgteSæder.Add(film.Sæder[sædeValg - 1]);
                    i++;
                    goto SædeValg; // Gå tilbage til valg af sæder, hvis ikke alle er valgt
                }
                else
                {
                    Console.WriteLine("Ugyldigt valg eller sæde allerede valgt. Prøv igen.");
                    goto SædeValg;
                }
            }

            return valgteSæder;
        }

        private string GenererReservationsnummer()
        {
            return new Random().Next(100000000, 999999999).ToString("D9");
        }
    }
    //laver relevant klasse til en start menu
    class Program
    {
        static void Main(string[] args)
        {
            BestillingHandler handler = new BestillingHandler();

        StartValg:
            Console.WriteLine("1. Reservér billet\n2. Afbestil billet\n0. Afslut");
            string valg = Console.ReadLine();

            if (valg == "1")
                handler.Reserve();
            else if (valg == "2")
                handler.Afreserve();
            else if (valg == "0")
                return; // Afslut programmet
            else
            {
                Console.WriteLine("Ugyldigt valg. Prøv igen.");
            }

            goto StartValg; // Gå tilbage til startmenuen efter en handling
        }
    }
}
