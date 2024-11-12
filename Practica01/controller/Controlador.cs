using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Practica01.DAO2;
using Practica01.models;
using Practica01.viewModels;


namespace Practica01.controller

{
    public class Controlador
    {

        private static Controlador _instance;

        
        private static readonly object _lock = new object();

        //private List<Pelicula> Peliculas {  get; set; }

        private PeliculaDAO PeliculaDAO;

        private UsuarioDAO UsuarioDAO;

        private FileReader FileReader;
        private List<Usuario> Usuarios { get; set; }
        private Usuario Usuario {  get; set; }
        public HashSet<Sala> Salas {  get; set; }

        public ObservableCollection<Pelicula> pl; //de pruebas No tiene hace falta que sea un ObservableCollection
        
        private PelisList pelis;



        public Controlador ()
        {
            this.PeliculaDAO = new PeliculaDAO();
            this.UsuarioDAO = new UsuarioDAO();
            this.FileReader = new FileReader();
            this.pelis = new PelisList(); //de pruebas
            //this.pl = pelis.OrdenarPeliculasPorHoraInicio();  // de pruebas

            this.pl = new ObservableCollection<Pelicula> ();
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
            var salasOrdenadas = Salas.OrderBy(s => s.hora).ToList();
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
                if(s.numero == num && s.hora == hora && s.fecha == dia)
                {
                    return s;
                }
            }
            return null;
               
        }
        public List<Pelicula> getPeliculaByName(String nombre)
        {
            //foreach (var p in pl) { if(p.titulo.Equals(nombre)) return p; }
            //return null;
            return PeliculaDAO.ObtenerPeliculasByName(new Pelicula(nombre));
        }

        public Pelicula getPeliculaBy_TituloHoraSala(String titulo, TimeSpan hora, int numSala)
        {
            foreach(Pelicula p in pl) { if (p.titulo.Equals(titulo) && p.horaInicio == hora && p.sala.numero == numSala) return p; };
            return null;
        }

        //Añadiendo DAO GUI JORDI

        public List<Pelicula> getPeliculasBy_TituloFecha(String titulo, DateTime fecha)
        {
            return PeliculaDAO.ObtenerPeliculasByName(new Pelicula(titulo,new Sala(0,fecha)));
        }
        public Pelicula getSesion(Pelicula p) 
        {
            Pelicula pelicula = PeliculaDAO.GetPeliculaInSesion(p);
            if (pelicula == null) pelicula = p;
            return pelicula;
        }
        public void AddSesion(Pelicula p) { PeliculaDAO.addSesion(p); }
        public void UpdateSesion(Pelicula p ) { PeliculaDAO.ActualizarPelicula(p); }


        // Cargando datos GUI SANTI
        public void InsertPelicula(Pelicula p) 
        {
            PeliculaDAO.InsertarPelicula(p);
        }

        public void CargarPeliculasCSV(String file) 
        {
            ObservableCollection<Pelicula> peliculas = FileReader.FileRead(file);
            foreach(Pelicula p in peliculas)
            {
                InsertPelicula (p);
            }
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
            Usuario u = UsuarioDAO.findUser(correo);
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
