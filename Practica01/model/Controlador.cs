using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Practica01.model
{
    public class Controlador
    {
        public List<Pelicula> Peliculas { get; set; } 
        private List<Usuario> Usuarios { get; set; }
        private Usuario Usuario {  get; set; }
        private List<Sala> Salas {  get; set; }


        public Controlador ()
        {
            this.Salas = new List<Sala> ();
            this.Usuarios = new List<Usuario> ();
            this.Usuario = null;
            for(int i = 1; i < 4; i++) {Salas.Add (new Sala (i));}
            Usuarios.Add(new Usuario("email@prueba.com", "admin", "1234"));

            this.Peliculas = getPeliculas();


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
        public bool reservarButaca(Pelicula pelicula, int n)
        {
            return pelicula.reservarButaca(n);
        }

        //valentina
        public List<Pelicula> getPeliculas()
        {

            return new List<Pelicula>
            {
               new Pelicula(
                    "La aventura épica",
                    "Español",
                    new List<string> { "Aventura", "Acción" },
                    new DateTime(2024, 11, 1),
                    new DateTime(2024, 11, 30),
                    new DateTime(2024, 11, 2, 19, 0, 0),
                    120,
                    Salas[0]
                ),
                new Pelicula(
                    "El misterio de la noche",
                    "Inglés",
                    new List<string> { "Misterio", "Suspenso" },
                    new DateTime(2024, 11, 5),
                    new DateTime(2024, 11, 20),
                    new DateTime(2024, 11, 2, 21, 0, 0),
                    90,
                    Salas[0]
                ),
                new Pelicula(
                    "Comedia familiar",
                    "Español",
                    new List<string> { "Comedia", "Familiar" },
                    new DateTime(2024, 11, 10),
                    new DateTime(2024, 11, 25),
                    new DateTime(2024, 11, 2, 17, 30, 0),
                    105,
                    Salas[0]
                ),
                new Pelicula(
                    "Titanic",
                    "Español",
                    new List<string> { "Comedia", "Familiar" },
                    new DateTime(2024, 11, 10),
                    new DateTime(2024, 11, 25),
                    new DateTime(2024, 11, 2, 17, 30, 0),
                    105,
                    Salas[0]
                ),
                new Pelicula(
                    "Up",
                    "Español",
                    new List<string> { "Comedia", "Familiar" },
                    new DateTime(2024, 11, 10),
                    new DateTime(2024, 11, 25),
                    new DateTime(2024, 11, 2, 17, 30, 0),
                    105,
                    Salas[0]
                ),
                new Pelicula(
                    "Pelicula 2",
                    "Español",
                    new List<string> { "Comedia", "Familiar" },
                    new DateTime(2024, 11, 10),
                    new DateTime(2024, 11, 25),
                    new DateTime(2024, 11, 2, 17, 30, 0),
                    105,
                    Salas[0]
                ),
                new Pelicula(
                    "Pelicula 3",
                    "Español",
                    new List<string> { "Comedia", "Familiar" },
                    new DateTime(2024, 11, 10),
                    new DateTime(2024, 11, 25),
                    new DateTime(2024, 11, 2, 17, 30, 0),
                    105,
                    Salas[0]
                ),
                new Pelicula(
                    "Pelicula 3",
                    "Español",
                    new List<string> { "Comedia", "Familiar" },
                    new DateTime(2024, 11, 10),
                    new DateTime(2024, 11, 25),
                    new DateTime(2024, 11, 2, 17, 30, 0),
                    105,
                    Salas[0]
                ),
                new Pelicula(
                    "Pelicula 3",
                    "Español",
                    new List<string> { "Comedia", "Familiar" },
                    new DateTime(2024, 11, 10),
                    new DateTime(2024, 11, 25),
                    new DateTime(2024, 11, 2, 17, 30, 0),
                    105,
                    Salas[0]
                ),
                new Pelicula(
                    "Pelicula 3",
                    "Español",
                    new List<string> { "Comedia", "Familiar" },
                    new DateTime(2024, 11, 10),
                    new DateTime(2024, 11, 25),
                    new DateTime(2024, 11, 2, 17, 30, 0),
                    105,
                    Salas[0]
                ),new Pelicula(
                    "Pelicula 3",
                    "Español",
                    new List<string> { "Comedia", "Familiar" },
                    new DateTime(2024, 11, 10),
                    new DateTime(2024, 11, 25),
                    new DateTime(2024, 11, 2, 17, 30, 0),
                    105,
                    Salas[0]
                )
            };

        }
    }
}
