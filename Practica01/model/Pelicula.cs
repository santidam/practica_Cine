using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.model
{
    public class Pelicula
    {
        private String nombre {  get; set; }
        private String[] genero {  get; set; }
        private DateTime fecha_inicio {  get; set; }
        private DateTime fecha_final { get; set; }
        private int duracion {  get; set; }

        private Sala sala { get; set; }

        public Pelicula(string nombre, string[] genero, DateTime fecha_inicio, DateTime fecha_final, int duracion, Sala sala)
        {
            this.nombre = nombre;
            this.genero = genero;
            this.fecha_inicio = fecha_inicio;
            this.fecha_final = fecha_final;
            this.duracion = duracion;
            this.sala = sala;
        }
    }
}
