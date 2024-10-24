using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.model
{
    public class Usuario
    {
        private String correo {  get; set; }
        private String nombre { get; set; }
        private String password { get; set; }

        public Usuario(String correo, String nombre, String password)
        {
            this.correo = correo;
            this.nombre = nombre;
            this.password = password;
        }

    }

}
