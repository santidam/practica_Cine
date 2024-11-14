using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.models
{
    public class Pelicula
    {
        private int Id;
        private String Titulo;
        private Sala Sala;
        private String Idioma;
        private DateTime FechaInicio;
        private DateTime FechaFin;
        private int Duracion;
        private TimeSpan HoraInicio; 
        private List<String> Generos;

        public Pelicula(string titulo, String idioma, List<String> generos, DateTime fecha_inicio, DateTime fecha_final, TimeSpan horario, int duracion, Sala sala)
        {
            this.Titulo = titulo;
            this.Sala = sala;
            this.Idioma = idioma;
            this.FechaFin = fecha_final;
            this.FechaInicio = fecha_inicio;
            this.Duracion = duracion;
            this.HoraInicio = horario;
            this.Generos = generos;
            //this.id = id
        }
        public Pelicula(int id,string titulo, String idioma, TimeSpan horario, Sala sala)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Sala = sala;
            this.Idioma = idioma;
            this.HoraInicio = horario;
            //this.id = id
        }
        public Pelicula(String titulo, Sala sala)
        {
            this.Titulo = titulo;
            this.Sala= sala;
        }
        public Pelicula(String titulo)
        {
            this.Titulo = titulo;
        }
        public Pelicula() { }
        
        public int id 
        {
            get { return Id; }
            set { Id = value; }
        }


        public String titulo
        {
            get { return Titulo; }
            set { Titulo = value; }
        }
        public Sala sala
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
        public int duracion
        {
            get { return Duracion; }
            set { Duracion = value; }
        }
        public TimeSpan horaInicio
        {
            get { return HoraInicio; }
            set { HoraInicio = value; }
        }
        public List<String> generos
        {
            get { return Generos; }
            set { Generos = value; }
        }
        public override string ToString()
        {
            return $"Sala {sala.numero}\nDia: {sala.fecha}\nHora: {sala.ObtenerHoraFormateada(horaInicio)}\nTitulo: {titulo}\t";
        }

    }
}
