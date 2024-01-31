using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Książka
    {
       
        public int ID_Książki ;
        public string Tytuł;
        public string Autor;
        public int RokWydania;

        public string Status;


        public Książka( string tytuł, string autor, int rokWydania, string status = "W bibliotece")
        {
            ID_Książki =  ++Biblioteka.Wielkość_Księgozbioru;
            Tytuł = tytuł;
            Autor = autor;
            RokWydania = rokWydania;
            Status = status;
            
        }   
    }

   
}
