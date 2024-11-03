using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01
{
    public class Pelicula
    {
        private String Titulo;
        private int Sala;
        private String Idioma;
        private String FechaInicio;
        private String FechaFin;
        private double Duracion;
        private TimeSpan HoraInicio;
        private String[] Generos;

        public Pelicula(String Titulo, int Sala, String Idioma, String FechaInicio, String FechaFin, double Duracion, String HoraInicio, String[] Generos)
        {
            this.Titulo = Titulo;
            this.Sala = Sala;
            this.Idioma = Idioma;
            this.FechaFin = FechaFin;
            this.FechaInicio = FechaInicio;
            this.Duracion = Duracion;
            this.HoraInicio = TimeSpan.Parse(HoraInicio);


            this.Generos = Generos;
        }

       


        public String titulo
        {
            get { return Titulo; }
            set { Titulo = value; }
        }
        public int sala
        {
            get { return Sala; }
            set {Sala = value; }
        }
        public String idioma
        {
            get { return Idioma; }
            set { Idioma = value; }
        }
        public String fechaInicio
        {
            get { return FechaInicio; }
            set { FechaInicio = value; }
        }
        public String fechaFin
        {
            get { return FechaFin; }
            set { FechaFin = value; }
        }
        public double duracion
        {
            get { return Duracion; }
            set { Duracion = value; }
        }
        public TimeSpan horaInicio
        {
            get { return HoraInicio; }
            set { HoraInicio = value; }
        }
        public String[] generos
        {
            get { return Generos; }
            set { Generos = value; }
        }

        
    }
}
