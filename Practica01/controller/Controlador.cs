using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Practica01.models;
using Practica01.viewModels;


namespace Practica01.controller

{
    public class Controlador
    {

        private static Controlador _instance;

        
        private static readonly object _lock = new object();

        //private List<Pelicula> Peliculas {  get; set; }
        private List<Usuario> Usuarios { get; set; }
        private Usuario Usuario {  get; set; }
        public HashSet<Sala> Salas {  get; set; }
        public ObservableCollection<Pelicula> pl; //de pruebas No tiene hace falta que sea un ObservableCollection
        private PelisList pelis;


        public Controlador ()
        {
            
            this.pelis = new PelisList(); //de pruebas
            this.pl = pelis.OrdenarPeliculasPorHoraInicio();  // de pruebas

            //this.Peliculas = new List<Pelicula> ();
            this.Salas = new HashSet<Sala>();
            this.Usuarios = new List<Usuario> ();
            this.Usuario = null;
            Usuarios.Add(new Usuario("admin@admin.com", "admin", "1234", true));
            Usuarios.Add(new Usuario("user@user.com", "user", "1234", false));


        }

        //Singletón
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

        
        public Usuario findUser(String email) {
            foreach (var i in Usuarios )
            {
                if (i.email.Equals(email)) return i;
            }
            return null;
        }

        public bool isAdmin()
        {
            return Usuario.admin;
        }


        public void OrdenarSalaPorHora()
        {
            // Ordenar las peliculas por Duracion
            var salasOrdenadas = Salas.OrderBy(s => s.Hora).ToList();
            Salas.Clear();
            foreach (Sala s in salasOrdenadas)
            {
                Salas.Add(s);
            }

        }

        //ADD

        //public void addPelicula(Pelicula pelicula) { Peliculas.Add (pelicula);}

        public void addSala(Sala sala) {Salas.Add (sala);}

        //GET BY        
        public Sala getSalaBy_NumHoraDia(int num, TimeSpan hora, DateTime? dia)
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
        public Pelicula getPeliculaByName(String nombre)
        {
            foreach (var p in pl) { if(p.titulo.Equals(nombre)) return p; }
            return null;
        }

        public Pelicula getPeliculaBy_TituloHoraSala(String titulo, TimeSpan hora, int numSala)
        {
            foreach(Pelicula p in pl) { if (p.titulo.Equals(titulo) && p.horaInicio == hora && p.sala == numSala) return p; };
            return null;
        }

        //public List<Pelicula> getPeliculasDia()
        //{
        //    List<Pelicula> listaPeliculas = new List<Pelicula>();
        //    foreach (var i in Peliculas) { if(i.horario.Day.CompareTo(DateTime.Today)true) }


        

        //VALIDACIONES

        public Boolean validUser(String correo, String password)
        {
            valMail(correo);
            valPassword(password);
            Usuario u = findUser(correo);
            if (u == null) throw new ArgumentException("El usuario no existe");

            if (u.email == correo && u.password == password) { this.Usuario = u; return true; } else { throw new ArgumentException("Credenciales incorrectas"); };
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
    }
}
