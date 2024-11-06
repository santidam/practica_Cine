using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.models
{
    public class Usuario
    {
        private String Email {  get; set; }
        public String email 
        {
            get {return Email;}
            set {Email = value;}
        }
        private String Nombre { get; set; }
        public String nombre 
        {
            get {  return Nombre;}
            set {Nombre = value;}
        }
        private String Password { get; set; }
        public String password 
        {
            get {return Password;}
            set {Password = value;}
        }
        private bool Admin {  get; set; }
        public bool admin 
        {
            get {  return Admin;}
            set {Admin = value;}
        }

        public Usuario(String correo, String nombre, String password, Boolean admin)
        {
            this.Email = correo;
            this.Nombre = nombre;
            this.Password = password;
            this.Admin = admin;
        }

       

    }

}
