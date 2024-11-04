using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Practica01
{
    public class Sala
    {
        private int numero {  get; set; }
        
        private TimeSpan hora;
        private String dia;
        private String tituloPelicula;
        private ObservableCollection<int> disponibilidadAButacas;
        
        public Sala(int numero, TimeSpan hora, String tituloPelicula, String dia) { 
            this.Numero = numero;
            this.dia = dia;
            this.hora = hora;
            this.tituloPelicula = tituloPelicula;

            this.disponibilidadAButacas = new ObservableCollection<int>{0,0,0,0,0,0,0,0,0};
        }

       

        public override string ToString()
        {
            // Formato: "Título - Director (Duración)"
            return $"Sala {Numero}\nDia: {Dia}\nHora: {ObtenerHoraFormateada(Hora)}\nTitulo: {TituloPelicula}";
        }

        public string ObtenerHoraFormateada(TimeSpan hora)
        {
            return hora.ToString(@"hh\:mm");
        }

        public override bool Equals(object obj)
        {
            if (obj is Sala other)
            {
                return numero == other.Numero && hora == other.Hora;
            }
            return false;
        }

        // GetHashCode combina Titulo y Director para crear un código hash único
        public override int GetHashCode()


        {
            int hashNumero = Numero != null ? Numero.GetHashCode() : 0;
            int hashHora = Hora.GetHashCode();

            return hashNumero * 31 + hashHora;
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public String Dia
        {
            get { return dia; }
            set { dia = value; }
        }

        public TimeSpan Hora
        {
            get { return hora; }
            set { hora = value; }
        }

        public String TituloPelicula
        {
            get { return tituloPelicula; }
            set { tituloPelicula = value; }
        }
        public ObservableCollection<int> DisponibilidadButacas
        {
            get { return disponibilidadAButacas; }
        }

    }
}
