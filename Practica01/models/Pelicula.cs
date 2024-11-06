using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.models
{
    public class Pelicula
    {
        private String Titulo;
        private int Sala;
        private String Idioma;
        private DateTime FechaInicio;
        private DateTime FechaFin;
        private double Duracion;
        private TimeSpan HoraInicio;
        private String[] Generos;

        public Pelicula(String Titulo, int Sala, String Idioma, DateTime FechaInicio, DateTime FechaFin, double Duracion, String HoraInicio, String[] Generos)
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
        public DateTime fechaInicio
        {
            get { return FechaInicio; }
            set { FechaInicio = value; }
        }
        public DateTime fechaFin
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
