using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Projekt
{
    public class Biblioteka
    {
        public static int Wielkość_Księgozbioru = 0;
        public static int LiczbaCzytelników = 0;
        public static List<Książka>Książki = new List<Książka>();
        public static List<Czytelnik>Czytelnicy = new List<Czytelnik>();

       
        
        //Metody dotyczące książek
        //-------------------------------------------------------------------------------------------

        //metoda dodająca nowe książki do biblioteki
        public static void DodajKsiążkę()
        {
            Console.WriteLine("Podaj tytuł książki: ");
           string KT =  Console.ReadLine();
            Console.WriteLine("Podaj autora książki: ");
            string KA = Console.ReadLine();
            Console.WriteLine("Podaj rok wydania książki: ");
            int KRW = Convert.ToInt32(Console.ReadLine());
            Książka Księga = new Książka(KT,KA,KRW);
            Biblioteka.Książki.Add(Księga);
            Console.WriteLine("Pozycja dodana do biblioteki");
        }

        //metoda wyświetlająca wszystkie  książki w bibliotece
        public static void StanKsięgozbioru() {

            foreach (var x in Biblioteka.Książki)
            {
                Console.WriteLine($"{x.ID_Książki} , {x.Tytuł} , {x.Autor} , {x.RokWydania} , {x.Status}");

            }
        }

        //metoda usuwająca wybraną książkę z biblioteki 
        public static void UsuńKsiążkę()
        {
            Console.WriteLine("Podaj id książki, którą chcesz usunąć: ");
            int KDU_ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj tytuł książki, którą chcesz usunąć: ");
            string KDU_Tytuł = Console.ReadLine();
            if (Biblioteka.Książki.All(x => x.ID_Książki != KDU_ID) && Biblioteka.Książki.All(x => x.Tytuł != KDU_Tytuł))
            {
                Console.WriteLine("Tej pozycji nie ma w bibliotece");
                return;
            }
            else
            {
                foreach (var x in Biblioteka.Książki)
                {
                    if (x.ID_Książki == KDU_ID && x.Tytuł == KDU_Tytuł)
                    {
                        if (x.Status == "Wypożyczona")
                        {
                            Console.WriteLine("Książka musi zostać zwrócona , zanim będzie można ją usunąć");
                            break;
                        }
                        else
                        {
                            Biblioteka.Książki.Remove(x);
                            Console.WriteLine($" Wskazana pozycja : {x.ID_Książki} , {x.Tytuł} , {x.Autor} , {x.RokWydania} , {x.Status} została usunięta");
                            Biblioteka.Wielkość_Księgozbioru -= 1;
                            break;
                        }
                    
                    }

                }
                foreach (var y in Biblioteka.Książki)
                {
                    y.ID_Książki = Biblioteka.Książki.IndexOf(y) + 1;
                }
            }
        }

        //metoda aktualizująca wybraną książkę w bibliotece
        public static void ZakutalizujDaneKsiążki()
        {
            Console.WriteLine("Podaj id pozycji , którą chcesz zaktualizować: ");
            int ID_KDA = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Wybierz informację o książce , którą chcesz zaktualizować: ");
            Console.WriteLine("1: Tytuł ");
            Console.WriteLine("2: Autor ");
            Console.WriteLine("3: Rok Wydania ");
            int DaneDoZmiany = Convert.ToInt32(Console.ReadLine());
            switch (DaneDoZmiany) 
            {
                case 1:
                    if (Biblioteka.Książki.All(x => x.ID_Książki != ID_KDA) || Biblioteka.Książki.All(x => x.Status != "W bibliotece"))
                    {
                        Console.WriteLine("Tej pozycji nie ma w bibliotece lub została wypożyczona");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Podaj nowy tytuł: ");
                        string N_Tytuł = Console.ReadLine();
                        foreach (var x in Biblioteka.Książki)
                        {
                            if (x.ID_Książki == ID_KDA)
                            {
                                x.Tytuł = N_Tytuł;
                                break;
                            }
                        }
                        Console.WriteLine("Tytuł wskazanej pozycji został zaktualizowany");
                    }
                    break;

                case 2:
                    if (Biblioteka.Książki.All(x => x.ID_Książki != ID_KDA) || Biblioteka.Książki.All(x => x.Status != "W bibliotece"))
                    {
                        Console.WriteLine("Tej pozycji nie ma w bibliotece");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Podaj nowego autora: ");
                        string N_Autor = Console.ReadLine();
                        foreach (var x in Biblioteka.Książki)
                        {
                            if (x.ID_Książki == ID_KDA)
                            {
                                x.Autor = N_Autor;
                                break;
                            }
                        }
                        Console.WriteLine("Autor wskazanej pozycji został zaktualizowany");
                    }
                    break;

                case 3:
                    if (Biblioteka.Książki.All(x => x.ID_Książki != ID_KDA) || Biblioteka.Książki.All(x => x.Status != "W bibliotece"))
                    {
                        Console.WriteLine("Tej pozycji nie ma w bibliotece");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Podaj nowy rok wydania: ");
                        int N_RokWydania = Convert.ToInt32(Console.ReadLine());
                        foreach (var x in Biblioteka.Książki)
                        {
                            if (x.ID_Książki == ID_KDA)
                            {
                                x.RokWydania = N_RokWydania;
                                break;
                            }
                        }
                        Console.WriteLine("Rok wydania wskazanej pozycji został zaktualizowany");
                    }
                    break;

                default:
                    Console.WriteLine("Nieprawidłowa informacja");
                    break;
            }
        }

        //metoda wyświetlająca książki podanego autora
        public static void KsiążkiWedługAutora() {
            Console.WriteLine("Podaj autora , którego ksiażki Cię interesują ");
             string SzukanyAutor =  Console.ReadLine();
            if (Biblioteka.Książki.All(x => x.Autor != SzukanyAutor))
            {
                Console.WriteLine("W bibliotece nie ma książek tego autora");
                return;
            }
            else
            {
                Console.WriteLine($"Ksiązki autora {SzukanyAutor}");
                foreach (var x in Biblioteka.Książki)
                {
                    if (x.Autor == SzukanyAutor)
                    {
                        Console.WriteLine($"{x.ID_Książki} , {x.Tytuł} , {x.Autor} , {x.RokWydania}");
                    }
                }
     
            }

        }

        //-------------------------------------------------------------------------------------------

        //Metody dotyczące czytelników

    
        public static void DodajCzytelnika()
        {
            Console.WriteLine("Podaj imię nowego czytelnika: ");
            string CZI = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko nowego czytelnika: ");
            string CZN = Console.ReadLine();
            Console.WriteLine("Podaj PESEL nowego czytelnika: ");
            string CZP = Console.ReadLine();
            Czytelnik _Czytelnik = new Czytelnik(CZI,CZN,CZP);
            Biblioteka.Czytelnicy.Add(_Czytelnik);
            Console.WriteLine("Dodano nowego czytelnika");
        }
        public static void ListaCzytelników()
        {

            foreach (var x in Biblioteka.Czytelnicy)
            {
                Console.WriteLine($"{x.ID_Czytelnika} , {x.Imię} , {x.Nazwisko} , {x.Pesel}");
                x.WypożyczoneKsiążki();

            }
        }

        public static void UsuńCzytelnika()
        {
            Console.WriteLine("Podaj id czytelnika, którego chcesz usunąć: ");
            int CZDU_ID = Convert.ToInt32(Console.ReadLine());
            if (Biblioteka.Czytelnicy.All(x => x.ID_Czytelnika != CZDU_ID))
            {
                Console.WriteLine("Takiego czytelnika nie ma na liście czytelników");
            }
            else
            {
                foreach (var x in Biblioteka.Czytelnicy)
                {
                    if (x.ID_Czytelnika == CZDU_ID)
                    {
                        if (x.ListaWypożyczonychKsiążek != null && x.ListaWypożyczonychKsiążek.Count() > 0)
                        {
                            Console.WriteLine("Czytelnik musi zwrócić wszystkie wypożyczone książki , zanim będzie można go usunąć");
                            break;
                        }
                        else { 
                        Biblioteka.Czytelnicy.Remove(x);
                        Console.WriteLine($" Wskazany czytelnik : {x.ID_Czytelnika} , {x.Imię} , {x.Nazwisko} został usunięty");
                        Biblioteka.LiczbaCzytelników -= 1;

                        break;
                    }
                    }

                }
                foreach (var y in Biblioteka.Czytelnicy)
                {
                    y.ID_Czytelnika = Biblioteka.Czytelnicy.IndexOf(y) + 1;
                }
            }
        }

        public static void ZaktualizujDaneCzytelnika()
        {
            Console.WriteLine("Podaj id czytelnika , którego dane chcesz zaktualizować: ");
            int ID_CZDA = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Wybierz informację o czytelniku , którą chcesz zaktualizować: ");
            Console.WriteLine("1: Imię ");
            Console.WriteLine("2: Nazwisko ");
            Console.WriteLine("3: PESEL ");
            int DaneDoZmiany = Convert.ToInt32(Console.ReadLine());
            switch (DaneDoZmiany)
            {
                case 1:
                    if (Biblioteka.Czytelnicy.All(x => x.ID_Czytelnika != ID_CZDA))
                    {
                        Console.WriteLine("Takiego czytelnika nie ma na liście czytelników");
                    }
                    else
                    {
                        Console.WriteLine("Podaj nowe imię: ");
                        string N_Imię = Console.ReadLine();
                        foreach (var x in Biblioteka.Czytelnicy)
                        {
                            if (x.ID_Czytelnika == ID_CZDA)
                            {
                                x.Imię = N_Imię;
                                break;
                            }
                        }
                        Console.WriteLine("Imię wskazanego czytelnika zostało zaktualizowane");
                    }
                    break;

                case 2:
                    if (Biblioteka.Czytelnicy.All(x => x.ID_Czytelnika != ID_CZDA))
                    {
                        Console.WriteLine("Takiego czytelnika nie ma na liście czytelników");
                    }
                    else
                    {
                        Console.WriteLine("Podaj nowe nazwisko: ");
                        string N_Nazwisko = Console.ReadLine();
                        foreach (var x in Biblioteka.Czytelnicy)
                        {
                            if (x.ID_Czytelnika == ID_CZDA)
                            {
                                x.Nazwisko = N_Nazwisko;
                                break;
                            }
                        }
                        Console.WriteLine("Nazwisko wskazanego czytelnika zostało zaktualizowane");
                    }
                    break;

                case 3:
                    if (Biblioteka.Czytelnicy.All(x => x.ID_Czytelnika != ID_CZDA))
                    {
                        Console.WriteLine("Takiego czytelnika nie ma na liście czytelników");
                    }
                    else
                    {
                        Console.WriteLine("Podaj nowy PESEL: ");
                        string N_Pesel = Console.ReadLine();
                        foreach (var x in Biblioteka.Czytelnicy)
                        {
                            if (x.ID_Czytelnika == ID_CZDA)
                            {
                                x.Pesel = N_Pesel;
                                break;
                            }
                        }
                        Console.WriteLine("PESEL wskazanego czytelnika został zaktualizowany");
                    }
                    break;

                default:
                    Console.WriteLine("Nieprawidłowa informacja");
                    break;
            }
        }

        //-------------------------------------------------------------------------------------------
       
        //Metody dotyczące ruchem książek

        public static void Wypożycz() 
        {

            Console.WriteLine("Podaj id czytelnika");
            int W_ID_Czytelnika = Convert.ToInt32(Console.ReadLine());
            if (Biblioteka.Czytelnicy.All(x => x.ID_Czytelnika != W_ID_Czytelnika))
            {
                Console.WriteLine("Takiego czytelnika nie ma na liście czytelników");
                return;
            }
            Czytelnik Wypożyczający = Biblioteka.Czytelnicy.Find(x => x.ID_Czytelnika == W_ID_Czytelnika);

            Console.WriteLine("Podaj id ksiązki do wypożyczenia");
                int W_ID_Książki = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Podaj tytuł ksiązki do wypożyczenia");
                string W_Tytuł_Książki = Console.ReadLine();
            

            if (Biblioteka.Książki.All(x => x.ID_Książki != W_ID_Książki) && Biblioteka.Książki.All(x => x.Tytuł != W_Tytuł_Książki))
            {
                Console.WriteLine("Tej pozycji nie ma w bibliotece");
                return;
            }
            else
            {
                foreach (var x in Biblioteka.Książki)
                {
                    if (x.ID_Książki == W_ID_Książki && x.Tytuł == W_Tytuł_Książki)
                    {
                        if (x.Status == "Wypożyczona")
                        {
                            Console.WriteLine("Ta książka została już wypożyczona,  musi zostać zwrócona , zanim będzie można ją wypożyczyć innemu czytelnikowi");
                            break;
                        }
                        else
                        {
                            Wypożyczający.ListaWypożyczonychKsiążek.Add(x);
                            x.Status = "Wypożyczona";
                            Wypożyczający.WypożyczoneKsiążki();
                            Console.WriteLine($" Wskazana pozycja : {x.ID_Książki} , {x.Tytuł} , {x.Autor} , {x.RokWydania}  została wypożyczona czytelnikowi {Wypożyczający.ID_Czytelnika} , {Wypożyczający.Imię} , {Wypożyczający.Nazwisko}");
                            break;
                        }

                    }

                }

            }

        }

        public static void Zwróć() 
        {
            Console.WriteLine("Podaj id czytelnika");
            int Z_ID_Czytelnika = Convert.ToInt32(Console.ReadLine());
            if (Biblioteka.Czytelnicy.All(x => x.ID_Czytelnika != Z_ID_Czytelnika))
            {
                Console.WriteLine("Takiego czytelnika nie ma na liście czytelników");
                return;
            }
            Czytelnik Zwracający = Biblioteka.Czytelnicy.Find(x => x.ID_Czytelnika == Z_ID_Czytelnika);
            Console.WriteLine("Podaj id ksiązki do zwrotu");
            int W_ID_Książki = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj tytuł ksiązki do zwrotu");
            string W_Tytuł_Książki = Console.ReadLine();

            if (Biblioteka.Książki.All(x => x.ID_Książki != W_ID_Książki) && Biblioteka.Książki.All(x => x.Tytuł != W_Tytuł_Książki))
            {
                Console.WriteLine("Ta pozycji nie należy do księgozbioru ");
                return;
            }
            else
            {
                foreach (var x in Biblioteka.Książki)
                {
                    if (x.ID_Książki == W_ID_Książki && x.Tytuł == W_Tytuł_Książki)
                    {
                        if (!Zwracający.ListaWypożyczonychKsiążek.Contains(x))
                        {
                            Console.WriteLine("Ta książka została już wypożyczona,  musi zostać zwrócona , zanim będzie można ją wypożyczyć innemu czytelnikowi");
                            break;
                        }
                        else
                        {
                            Zwracający.ListaWypożyczonychKsiążek.Remove(x);
                            x.Status = "W bibliotece";
                            Console.WriteLine($" Wskazana pozycja : {x.ID_Książki} , {x.Tytuł} , {x.Autor} , {x.RokWydania}  została zwrócona przez czytelnika {Zwracający.ID_Czytelnika} , {Zwracający.Imię} , {Zwracający.Nazwisko}");
                            break;
                        }

                    }

                }

            }
        }
    }



}
