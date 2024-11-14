using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Practica01.models
{
    public class Sala
    {
        private int Numero {  get; set; }
        private TimeSpan Hora;
        private DateTime Fecha;
        private int[] DisponibilidadButacas;
        private int Id_sala;
        private int Id_sesion;
        

        //Constructor incilizar butacas
        public Sala(int numero, TimeSpan hora, DateTime dia) { 
            this.Numero = numero;
            this.Fecha = dia;
            this.Hora = hora;
            this.DisponibilidadButacas = new int[]{0,0,0,0,0,0,0,0,0};
        }

        public Sala(int numero, int id_sesion, int[] disponibilidadButacas, DateTime fecha)
        {
            this.Numero = numero;
            this.Id_sesion = id_sesion;
            this.DisponibilidadButacas = disponibilidadButacas;
            this.Fecha = fecha;
        }
        public Sala(int numero, DateTime? fecha)
        {
            this.Numero = numero;
            this.Fecha = (DateTime)fecha;
            this.DisponibilidadButacas = new int []{ 0,0,0,0,0,0,0,0,0};
        }
        public Sala(int numero) 
        {
            this.Numero = numero; 
        }




       

        public string ObtenerHoraFormateada(TimeSpan hora)
        {
            return hora.ToString(@"hh\:mm");
        }

        public override bool Equals(object obj)
        {
            if (obj is Sala other)
            {
                return numero == other.numero && Hora == other.Hora && Fecha == other.fecha;
            }
            return false;
        }

        public override int GetHashCode()


        {
            int hashNumero = Numero != null ? Numero.GetHashCode() : 0;
            int hashHora = Hora.GetHashCode();
            int hashDia = fecha.GetHashCode();


            return hashNumero * 31 + hashHora + hashDia;
        }

        public int id_sesion
        {
            get { return Id_sesion; }
            set { Id_sesion = value; }

        }

        public int numero
        {
            get { return Numero; }
            set { Numero = value; }
        }
        public DateTime fecha
        {
            get { return Fecha; }
            set { Fecha = value; }
        }

        public TimeSpan hora
        {
            get { return Hora; }
            set { Hora = value; }
        }

     
        public int[] disponibilidadButacas
        {
            get { return DisponibilidadButacas; }
            set { DisponibilidadButacas = value; }
        }

    }
}
