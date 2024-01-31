using Projekt;

public class Program
{
    
    private static void Main(string[] args)
    {
        Console.Title  = "Biblioteka";
        Książka książka1 = new Książka("To", "Stephen King", 1986, "W bibliotece");
        Książka książka2 = new Książka("Sklepik z marzeniami", "Stephen King", 1988, "Wypożyczona");

        Książka książka3 = new Książka("Jądro ciemności", "Joseph Conrad", 1902);
        książka3.Autor = "Józef Conrad";
        Console.WriteLine($"{książka3.ID_Książki} , {książka3.Tytuł} , {książka3.Autor} , {książka3.RokWydania} , {książka3.Status}");
        Console.Clear();    
        Książka książka4 = new Książka("Mit Syzyfa", "Albert Camus", 1942);
        książka4.Tytuł = "Obcy";
        Console.WriteLine($"{książka4.ID_Książki} , {książka4.Tytuł} , {książka4.Autor} , {książka4.RokWydania} , {książka4.Status}");
        Console.Clear();
        Książka książka5 = new Książka("Folwark zwierzęcy", "George Orwell", 1940);
        książka5.RokWydania = 1945;
        Console.WriteLine($"{książka4.ID_Książki} , {książka4.Tytuł} , {książka4.Autor} , {książka4.RokWydania} , {książka4.Status}");
        Console.Clear();

        Biblioteka.Książki.Add(książka1);
        Biblioteka.Książki.Add(książka2);
        Biblioteka.Książki.Add(książka3);
        Biblioteka.Książki.Add(książka4);
        Biblioteka.Książki.Add(książka5);
        Biblioteka.Książki.Remove(książka3);
        Biblioteka.Wielkość_Księgozbioru -= 1;
        Biblioteka.Książki.Remove(książka4);
        Biblioteka.Wielkość_Księgozbioru -= 1;
        Biblioteka.Książki.Remove(książka5);
        Biblioteka.Wielkość_Księgozbioru -= 1;
        Czytelnik czytelnik1 = new Czytelnik("Janusz", "Nosacz", "013126054981");
        Czytelnik czytelnik2 = new Czytelnik("Ferdynand","Kiepski","016576321102");

        Biblioteka.Czytelnicy.Add(czytelnik1);
        Biblioteka.Czytelnicy.Add(czytelnik2);

        bool czyProgramDziała = true;
        while (czyProgramDziała)
        {
            Console.WriteLine("Biblioteka");
            Console.WriteLine("Co chcesz zrobić? ");
            Console.WriteLine("1: Dodać książkę do biblioteki");
            Console.WriteLine("2: Usunąć książkę z biblioteki");
            Console.WriteLine("3: Zakutalizować książkę w bibliotece");
            Console.WriteLine("4: Sprawdzić stan księgozbioru");
            Console.WriteLine("5: Sprawdzić książki wybranego autora");
            Console.WriteLine("6: Dodać nowego czytelnika");
            Console.WriteLine("7: Sprawdzić listę czytelników ");
            Console.WriteLine("8: Usunąć czytelnika ");
            Console.WriteLine("9: Zaktualizować dane czytelnika ");
            Console.WriteLine("10: Wypożyczyć książkę ");
            Console.WriteLine("11: Zwrócić książkę ");
            Console.WriteLine("100: Wyjść z biblioteki");

            
            int Opcja = Convert.ToInt32(Console.ReadLine());
            switch (Opcja)
            {
                case 1:
                    Biblioteka.DodajKsiążkę();
                    Console.WriteLine();
                    break;
                case 2:
                    Biblioteka.UsuńKsiążkę();
                    Console.WriteLine();
                    break;

                case 3:
                    Biblioteka.ZakutalizujDaneKsiążki();
                    Console.WriteLine();
                    break;

                case 4:
                    Biblioteka.StanKsięgozbioru();
                    Console.WriteLine();
                    break;

                case 5:
                    Biblioteka.KsiążkiWedługAutora();
                    Console.WriteLine();
                    break;

                case 6:
                    Biblioteka.DodajCzytelnika();
                    Console.WriteLine();
                    break;

                case 7:
                    Biblioteka.ListaCzytelników();
                    Console.WriteLine();
                    break;

                case 8:
                    Biblioteka.UsuńCzytelnika();
                    Console.WriteLine();
                    break;

                case 9:
                    Biblioteka.ZaktualizujDaneCzytelnika();
                    Console.WriteLine();
                    break;

                case 10:
                    Biblioteka.Wypożycz();
                    Console.WriteLine();
                    break;

                case 11:
                    Biblioteka.Zwróć();
                    Console.WriteLine();
                    break;

                case 100:
                    czyProgramDziała = false;
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine("Zła opcja");
                    break;
            }
            Console.WriteLine();
        }
    }
}