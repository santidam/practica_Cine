using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Practica01
{
    public class Controlador
    {
        private List<Pelicula> Peliculas {  get; set; }
        private List<Usuario> Usuarios { get; set; }
        private Usuario Usuario {  get; set; }
        private List<Sala> Salas {  get; set; }


        public Controlador ()
        {
            this.Peliculas = new List<Pelicula> ();
            this.Salas = new List<Sala> ();
            this.Usuarios = new List<Usuario> ();
            this.Usuario = null;
            for(int i = 1; i < 4; i++) {Salas.Add (new Sala (i));}
            Usuarios.Add(new Usuario("admin@admin.com", "admin", "1234", true));
            Usuarios.Add(new Usuario("user@user.com", "user", "1234", false));


        }
        public Boolean validUser(String correo, String password) 
        {
            valMail(correo);
            valPassword(password);
            Usuario u = findUser (correo);
            if (u == null) throw new ArgumentException("El usuario no existe");
            
            if( u.email == correo && u.password == password) { this.Usuario = u; return true; } else { throw new ArgumentException("Credenciales incorrectas"); };
            
          
        }
        public Boolean valMail(String corroe)
        {
            return true;
        }
        public Boolean valPassword(String password)
        {
            Boolean aux = true;
            if (password.Length < 4)
            {
                aux = false;
            }
            return aux;
        }

        public Usuario findUser(String email) {
            foreach (var i in Usuarios )
            {
                if (i.email.Equals(email)) return i;
            }
            return null;
        }
        
        public void addPelicula(Pelicula pelicula) { Peliculas.Add (pelicula);}
        public Pelicula getPelicula(String nombre)
        {
            foreach (var i in Peliculas) { if(i.titulo.Equals(nombre)) return i; }
            return null;
        }
        //public List<Pelicula> getPeliculasDia()
        //{
        //    List<Pelicula> listaPeliculas = new List<Pelicula>();
        //    foreach (var i in Peliculas) { if(i.horario.Day.CompareTo(DateTime.Today)true) }
        public List<Pelicula> listaPeliculas() { return Peliculas; }

        public bool isAdmin()
        {
            return Usuario.admin;
        }

    }
}
