using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Practica01
{
    public class Controlador
    {

        private static Controlador _instance;

        
        private static readonly object _lock = new object();

        //private List<Pelicula> Peliculas {  get; set; }
        private ObservableCollection<Pelicula> Peliculas; //de pruebas
        private List<Usuario> Usuarios { get; set; }
        private Usuario Usuario {  get; set; }
        public HashSet<Sala> Salas {  get; set; }
        private PelisList pl = new PelisList(); //de pruebas


        public Controlador ()
        {
            //this.Peliculas = new List<Pelicula> ();

            this.Peliculas = pl.Peliculas; // de pruebas
            this.Salas = new HashSet<Sala>();
            addSalas();//de pruebas
            this.Usuarios = new List<Usuario> ();
            this.Usuario = null;
            Usuarios.Add(new Usuario("admin@admin.com", "admin", "1234", true));
            Usuarios.Add(new Usuario("user@user.com", "user", "1234", false));


        }
        public static Controlador Instance
        {
            get
            {
                // Verifica si la instancia ya fue creada
                if (_instance == null)
                {
                    // Bloqueo para asegurar que solo un hilo puede crear la instancia
                    lock (_lock)
                    {
                        // Verifica nuevamente, en caso de que otro hilo haya creado la instancia
                        if (_instance == null)
                        {
                            _instance = new Controlador();
                        }
                    }
                }

                return _instance;
            }
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

        //public void addSala(Sala sala) {Salas.Add (sala);}
        public void addSalas()
        {
            foreach(Pelicula p in Peliculas)
            {
                Salas.Add(new Sala(p.sala, p.horaInicio, p.titulo, "24/11/2024"));
            }

        }
        public Sala getSalaBy_NumHoraDia(int num, TimeSpan hora, String dia)
        {
            foreach (Sala s in Salas)
            {
                if(s.Numero == num && s.Hora == hora && s.Dia == dia)
                {
                    return s;
                }
            }
            return null;
               
        }
        public Pelicula getPelicula(String nombre)
        {
            foreach (var i in Peliculas) { if(i.titulo.Equals(nombre)) return i; }
            return null;
        }
        //public List<Pelicula> getPeliculasDia()
        //{
        //    List<Pelicula> listaPeliculas = new List<Pelicula>();
        //    foreach (var i in Peliculas) { if(i.horario.Day.CompareTo(DateTime.Today)true) }
        public ObservableCollection<Pelicula> listaPeliculas() { return OrdenarPeliculasPorHoraInicio(); }

        public bool isAdmin()
        {
            return Usuario.admin;
        }

        public ObservableCollection<Pelicula> OrdenarPeliculasPorHoraInicio()
        {
            // Ordenar las peliculas por Duracion
            var peliculasOrdenadas = Peliculas.OrderBy(p => p.horaInicio).ToList();
            Peliculas.Clear();
            foreach (var pelicula in peliculasOrdenadas)
            {
                Peliculas.Add(pelicula);
            }
            return Peliculas;
        }

    }
}
