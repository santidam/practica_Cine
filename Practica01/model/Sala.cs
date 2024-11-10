using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.model
{
    public class Sala
    {
        private int Id_sala;
        public int id_sala
        {
            get { return Id_sala; }
            set { Id_sala = value; }
        }
        private int Id_sesion;
        public int id_sesion
        {
            get { return Id_sesion; }
            set { Id_sesion = value; }

        }
        private int Numero { get; set; }
        private int[] DisponibilidadButacas;
        public int[] disponibilidadButacas
        {
            get { return DisponibilidadButacas; }
            set { DisponibilidadButacas = value; }
        }
        private DateTime Fecha;
        public DateTime fecha 
        {
            get { return Fecha; }
            set { Fecha = value; }
        }

        public int numero 
        {
            get {  return Numero; }
            set { Numero = value; }
        }

        public Sala(int numero) { this.Numero = numero; }
        public Sala(int numero, DateTime fecha) { 
            this.Numero = numero; 
            this.Fecha = fecha;
        }
        public Sala(int id_sala, int id_sesion, int[] disponibilidadButacas, DateTime fecha)
        {
            this.id_sala = id_sala;
            this.id_sesion = id_sesion;
            this.disponibilidadButacas = disponibilidadButacas;
            this.fecha = fecha; 
        }
        
    }
}
