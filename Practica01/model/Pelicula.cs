using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.model
{
    public class Pelicula
    {
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
        private DateTime Horario { get; set; }
        public DateTime horario
        {
            get { return Horario; }
            set { Horario = value; }
        }
        private List<bool> Butacas { get; set; }
        public List<bool> butacas 
        {
            get { return Butacas; }
            set {  Butacas = value; }
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

        public Pelicula(string titulo,String idioma, List<String> genero, DateTime fecha_inicio, DateTime fecha_final,DateTime horario, int duracion, Sala sala)
        {
            this.Titulo = titulo;
            this.Idioma = Idioma;
            this.Genero = genero;
            this.Fecha_inicio = fecha_inicio;
            this.Fecha_final = fecha_final;
            this.Horario = horario;
            this.Duracion = duracion;
            this.Butacas = new List<bool>(new bool[9]);
            this.Sala = sala;
        }

        public bool reservarButaca(int n)
        {
            if (Butacas[n] == false) { butacas[n] = true; return true; }
            return false;
        }
    }
}
