using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.model
{
    internal class Personajes
    {
        public String Nombre { get; set; }
        public String Clase { get; set; }
        public int Ataque { get; set; }
        public int Defensa { get; set; }
        public int Magia { get; set; }

        public Personajes(string nombre, string clase, int ataque, int defensa, int magia)
        {
            Nombre = nombre;
            Clase = clase;
            Ataque = ataque;
            Defensa = defensa;
            Magia = magia;
        }
        public override string ToString()
        {
            return Nombre + " - Clase: " + Clase + " - Ataque: " + Ataque + " - Defensa: " + Defensa + " - Magia: " + Magia;
        }
    }
}
