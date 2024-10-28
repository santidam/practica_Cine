using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.model
{
    public class Sala
    {
        private int Numero {  get; set; }
        public int numero 
        {
            get {  return Numero; }
            set { Numero = value; }
        }

        public Sala(int numero) { this.Numero = numero; }
    }
}
