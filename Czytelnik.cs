using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Czytelnik
    {
        public int ID_Czytelnika;
        public string Imię;
        public string Nazwisko;
        public string Pesel;
        public List<Książka> ListaWypożyczonychKsiążek = new List<Książka>();

        public Czytelnik(string imie , string nazwisko,string pesel) 
        {
            ID_Czytelnika = ++Biblioteka.LiczbaCzytelników;
            Imię = imie;
            Nazwisko = nazwisko;
            Pesel = pesel;
            ListaWypożyczonychKsiążek = new List<Książka> ();
    }

        public void WypożyczoneKsiążki() 
        {
            Console.WriteLine("Wypożyczone ksiązki: ");
            foreach (var k in ListaWypożyczonychKsiążek)
            {
                Console.WriteLine($"  {k.ID_Książki} , {k.Tytuł} , {k.Autor} , {k.RokWydania} , {k.Status}");
            }
        }
    }
}
