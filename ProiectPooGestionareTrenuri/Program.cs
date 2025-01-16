using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ProiectPooGestionareTrenuri
{
    public class Program
    {
        static Utilizator utilizatorCurent = null;
        static List<Utilizator> utilizatori;
        static List<Ruta> rute;

        static void Main(string[] args)
        {
            utilizatori = SistemFisiere.IncarcaUtilizatori();
            rute = SistemFisiere.IncarcaRute();

            bool contInchis = false;
            while (!contInchis)
            {
                Console.Clear();
                Console.WriteLine("1. Logare");
                Console.WriteLine("2. Creare cont nou");
                Console.WriteLine("3. Iesire");
                Console.Write("Alegeti o optiune: ");
                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        Logare();
                        break;
                    case "2":
                        CreareCont();
                        break;
                    case "3":
                        contInchis = true;
                        break;
                    default:
                        Console.WriteLine("Optiune invalida. Incercati din nou.");
                        break;
                }
            }

            SistemFisiere.SalveazaUtilizatori(utilizatori);
            SistemFisiere.SalveazaRute(rute);
        }

        static void Logare()
        {
            Console.Clear();
            Console.Write("Introduceti email-ul: ");
            string email = Console.ReadLine();
            utilizatorCurent = utilizatori.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (utilizatorCurent != null)
            {
                Console.WriteLine($"Bine ai venit, {utilizatorCurent.Nume}!");
                if (utilizatorCurent.Tip == TipUtilizator.Pasager)
                {
                    MeniuPasager();
                }
                else
                {
                    MeniuAdministrator();
                }
            }
            else
            {
                Console.WriteLine("Utilizatorul nu exista. Te rugam să te inregistrezi.");
                Console.ReadKey();
            }
        }

        static void CreareCont()
        {
            Console.Clear();
            Console.Write("Introduceti numele complet: ");
            string nume = Console.ReadLine();
            Console.Write("Introduceti email-ul: ");
            string email = Console.ReadLine();

            if (utilizatori.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Email-ul este deja folosit. Va rugam sa alegeti altul.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Alegeți tipul de utilizator:");
            Console.WriteLine("1. Administrator");
            Console.WriteLine("2. Pasager");
            Console.Write("Alegeti optiunea (1/2): ");
            string tipOp = Console.ReadLine();
            TipUtilizator tipUtilizator = tipOp == "1" ? TipUtilizator.Administrator : TipUtilizator.Pasager;

            string id = Guid.NewGuid().ToString();
            Utilizator nouUtilizator = new Utilizator(id, nume, email, tipUtilizator);
            utilizatori.Add(nouUtilizator);

            Console.WriteLine("Contul a fost creat cu succes!");
            Console.ReadKey();
        }

        static void MeniuPasager()
        {
            bool iesirePasager = false;
            while (!iesirePasager)
            {
                Console.Clear();
                Console.WriteLine("Meniu Pasager:");
                Console.WriteLine("1. Cautare rute disponibile");
                Console.WriteLine("2. Rezervare bilet");
                Console.WriteLine("3. Anulare rezervare");
                Console.WriteLine("4. Vizualizare istoric calatorii");
                Console.WriteLine("5. Iesire");
                Console.Write("Alegeti o optiune: ");
                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        CautareRuteDisponibile();
                        break;
                    case "2":
                        RezervareBilet();
                        break;
                    case "3":
                        AnuleazaRezervare();
                        break;
                    case "4":
                        VizualizareIstoricCalatorii();
                        break;
                    case "5":
                        iesirePasager = true;
                        break;
                    default:
                        Console.WriteLine("Optiune invalida.");
                        break;
                }
            }
        }

        static void MeniuAdministrator()
        {
            bool iesireAdministrator = false;
            while (!iesireAdministrator)
            {
                Console.Clear();
                Console.WriteLine("Meniu Administrator:");
                Console.WriteLine("1. Adaugare ruta noua");
                Console.WriteLine("2. Iesire");
                Console.Write("Alegeti o optiune: ");
                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        AdaugareRuta();
                        break;
                    case "2":
                        iesireAdministrator = true;
                        break;
                    default:
                        Console.WriteLine("Optiune invalida.");
                        break;
                }
            }
        }

        static void AdaugareRuta()
        {
            Console.Clear();
            Console.Write("Introduceti ID-ul rutei: ");
            string idRuta = Console.ReadLine();
            Console.Write("Introduceti numele rutei: ");
            string numeRuta = Console.ReadLine();

            Console.Write("Introduceti numarul trenului: ");
            int numarTren = int.Parse(Console.ReadLine());

            Console.WriteLine("Selectati tipul trenului:");
            Console.WriteLine("1. Regio");
            Console.WriteLine("2. InterRegio");
            Console.WriteLine("3. Express");
            TipTren tipTren = (TipTren)(int.Parse(Console.ReadLine()) - 1);

            Console.Write("Introduceti capacitatea trenului: ");
            int capacitate = int.Parse(Console.ReadLine());

            Tren tren = new Tren(Guid.NewGuid().ToString(), numarTren, tipTren, capacitate);

            Ruta rutaNoua = new Ruta(idRuta, numeRuta, tren);
            rute.Add(rutaNoua);

            Console.WriteLine("Ruta a fost adăugata cu succes!");
            Console.ReadKey();
        }

        static void CautareRuteDisponibile()
        {
            Console.Clear();
            Console.WriteLine("Introduceti statia de plecare: ");
            string plecare = Console.ReadLine();
            Console.WriteLine("Introduceti statia de destinatie: ");
            string destinatie = Console.ReadLine();

            var ruteGasite = rute.Where(r => r.Statii.Any(s => s.NumeStatie.Equals(plecare, StringComparison.OrdinalIgnoreCase)) &&
                                             r.Statii.Any(s => s.NumeStatie.Equals(destinatie, StringComparison.OrdinalIgnoreCase)))
                                  .ToList();

            Console.WriteLine($"Rute disponibile intre {plecare} si {destinatie}:");

            if (ruteGasite.Any())
            {
                foreach (var ruta in ruteGasite)
                {
                    Console.WriteLine($"- {ruta.NumeRuta} (Durata: {ruta.DurataTotala}, Pret Clasa 1: {ruta.PretClasa1} lei)");
                }
            }
            else
            {
                Console.WriteLine("Nu exista rute disponibile.");
            }

            Console.ReadKey();
        }

        static void RezervareBilet()
        {
            Console.Clear();
            Console.WriteLine("Rezervare bilet nu a fost implementata complet.");
            Console.ReadKey();
        }

        static void AnuleazaRezervare()
        {
            if (utilizatorCurent.IstoricCalatorii.Count == 0)
            {
                Console.WriteLine("Nu aveti rezervari in istoric.");
                return;
            }

            Console.WriteLine("Rezervarile dvs.:");
            for (int i = 0; i < utilizatorCurent.IstoricCalatorii.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {utilizatorCurent.IstoricCalatorii[i]}");
            }

            Console.Write("Alegeti numarul rezervarii pe care doriti să o anulati: ");
            if (!int.TryParse(Console.ReadLine(), out int indexRezervare) || indexRezervare < 1 || indexRezervare > utilizatorCurent.IstoricCalatorii.Count)
            {
                Console.WriteLine("Selectie invalida.");
                return;
            }

            Calatorie rezervare = utilizatorCurent.IstoricCalatorii[indexRezervare - 1];
            utilizatorCurent.IstoricCalatorii.RemoveAt(indexRezervare - 1);

            Console.WriteLine($"Rezervarea \"{rezervare}\" a fost anulata cu succes.");
            SistemFisiere.SalveazaRute(rute);
        }



        static void VizualizareIstoricCalatorii()
        {
            Console.Clear();
            Console.WriteLine("Istoric calatorii:");

            if (utilizatorCurent.IstoricCalatorii.Any())
            {
                foreach (var calatorie in utilizatorCurent.IstoricCalatorii)
                {
                    string statusCalatorie = calatorie.Anulata ? "Anulata" : "Confirmata";
                    Console.WriteLine($"- {calatorie.Ruta.NumeRuta} ({calatorie.LocuriRezervate} locuri rezervate, {statusCalatorie})");
                }
            }
            else
            {
                Console.WriteLine("Nu aveti calatorii in istaoric.");
            }

            Console.ReadKey();
        }
    }

    

   
}
