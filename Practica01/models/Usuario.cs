using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Practica01.models
{
    public class Usuario : IDataErrorInfo
    {
        private String Email { get; set; }
        public string[] erroresPosibles { get; set; }
        public string[] erroresReales { get; set; }
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
                if (columnName == "email")
                {
                    if (string.IsNullOrEmpty(Email))
                    {
                        result = erroresPosibles[0];
                        erroresReales[0] = erroresPosibles[0];
                    }
                    else 
                    {
                        erroresReales[0] = "";
                        if (!Regex.IsMatch(Email, @"^+[^@\s]+@+[^@\s]+\.+[^@\s]+$"))
                        {
                            result = erroresPosibles[1];
                            erroresReales[1] = erroresPosibles[1];
                        }
                        else
                        {
                            erroresReales[1] = "";
                        }
                    }
                }
                if (columnName == "password")
                {
                    if (string.IsNullOrEmpty(Password))
                    {
                        result = erroresPosibles[2];
                        erroresReales[2] = erroresPosibles[2];
                    }
                    else
                    {
                        erroresReales[2] = "";
                        if (Password.Length < 3)
                        {
                            result = erroresPosibles[3];
                            erroresReales[3] = erroresPosibles[3];
                        }
                        else
                        {
                            erroresReales[3] = "";
                        } 
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
            ResetErrors();
            this.Email = "";
            this.Password = "";
            
        }
        public void ResetErrors()
        {
            this.erroresPosibles = new string[4] {
                "El e-mail no puede estar vacío",
                "Formato de e-mail no válido. Debe ser: usuario@dominio.extensión",
                "La contraseña no puede estar vacía",
                "La contraseña debe tener 3 caracteres"
            };

            this.erroresReales = new string[4] {
                "El e-mail no puede estar vacío",
                "Formato de e-mail no válido. Debe ser: usuario@dominio.extensión",
                "La contraseña no puede estar vacía",
                "La contraseña debe tener 3 caracteres"
            };
        }

    }

}
