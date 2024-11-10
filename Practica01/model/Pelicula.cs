using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.model
{
    public class Pelicula
    {
        private int Id;
        public int id
        {
            get { return Id; }
            set { Id = value; }
        }
        private String Titulo;
        public String titulo
        {
            get { return Titulo; }
            set { Titulo = value; } }

        private String Idioma { get; set; }
        public String idioma
        {
            get { return Idioma; }
            set { Idioma = value; }
        }

        private List<String> Genero { get; set; }
        public List<String> genero
        {
            get { return Genero; }
            set { Genero = value; }
        }

        private DateTime Fecha_inicio { get; set; }
        public DateTime fecha_inicio
        {
            get { return Fecha_inicio; }
            set { Fecha_inicio = value; } }
    
        private DateTime Fecha_final { get; set; }
        public DateTime fecha_final
        {
            get { return Fecha_final; }
            set {  Fecha_final = value; }
        }
        private TimeSpan Horario { get; set; }
        public TimeSpan horario
        {
            get { return Horario; }
            set { Horario = value; }
        }
      

        private int Duracion {  get; set; }
        public int duracion 
        {
            get { return Duracion; }
            set { Duracion = value; }
        }

        private Sala Sala { get; set; }
        public Sala sala 
        {
            get { return Sala; }
            set { Sala = value; }
        }

        public Pelicula(string titulo,String idioma, List<String> genero, DateTime fecha_inicio, DateTime fecha_final,TimeSpan horario, int duracion, Sala sala)
        {
            this.Titulo = titulo;
            this.Idioma = idioma;
            this.Genero = genero;
            this.Fecha_inicio = fecha_inicio;
            this.Fecha_final = fecha_final;
            this.Horario = horario;
            this.Duracion = duracion;
            this.Sala = sala;
        }

        public Pelicula(int id, String titulo, String idioma, TimeSpan horario, Sala sala) 
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Idioma = idioma;
            this.Horario = horario;
            this.Sala = sala;
        }
        public Pelicula(String titulo) 
        {
            this.Titulo = titulo;
        }
        public Pelicula()
        {
            
        }

      
    }
}
