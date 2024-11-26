using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Practica01.models
{
    public class Usuario : IDataErrorInfo
    {
        private String Email { get; set; }
        public String email
        {
            get { return Email; }
            set { Email = value; }
        }
        private String Nombre { get; set; }
        public String nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
        private String Password { get; set; }
        public String password
        {
            get { return Password; }
            set { Password = value; }
        }
        private bool Admin { get; set; }
        public bool admin
        {
            get { return Admin; }
            set { Admin = value; }
        }

        public String Error
        {
            get { return ""; }
        }

        public string this[string columnName]
        {
            get
            {
                string result = "";
                if (columnName == Email)
                {
                    if (string.IsNullOrEmpty(Email))
                    {
                        result = "El email no puede estar vacio";
                    }
                }
                if (columnName == Password)
                {
                    if (string.IsNullOrEmpty(Password))
                    {
                        result = "La constraseña no puede estar vacio";
                    }
                }
                return result;
            }
        }

        public Usuario(String correo, String nombre, String password, Boolean admin)
        {
            this.Email = correo;
            this.Nombre = nombre;
            this.Password = password;
            this.Admin = admin;
        }
        public Usuario()
        {
            this.Email = "";
            this.Password = "";
        }


    }

}
