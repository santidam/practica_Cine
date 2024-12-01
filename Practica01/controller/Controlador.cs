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


        private PeliculaDAO PeliculaDAO;

        private UsuarioDAO UsuarioDAO;

        private FileReader FileReader;
        
        private Usuario Usuario {  get; set; }

        



        public Controlador ()
        {
            this.PeliculaDAO = new PeliculaDAO();
            this.UsuarioDAO = new UsuarioDAO();
            this.FileReader = new FileReader();

            
            this.Usuario = null;
            


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

        
  

        public bool isAdmin()
        {
            return Usuario.admin;
        }


  

        //ADD



        //GET BY        
   
        public List<Pelicula> getPeliculaByName(String nombre)
        {
        
            return PeliculaDAO.ObtenerPeliculasByName(new Pelicula(nombre));
        }

      
        //Añadiendo GUI Valentina

        public List<Pelicula> GetPeliculasToday()
        {
            //Este metodo te daria las peliculas del dia

            return PeliculaDAO.ObtenerPeliculasToday();
        }
        public List<Pelicula> GetPeliculasFiltradas(List<String> generos, List<String> idiomas, DateTime? fecha)
        {
            //Este metodo puede ajustarse, devuelve todas las pelis que cumplan el criterio pero podria
            //devolver solo un peli con el nombre sin repetir ajustando la query dependiendo de lo que necesites
            // -Hay 3 metodos de filtrado en el DAO, los otros estan comentados, si quieres solo 1 titulo por pelicula usa el
            //metodo 3 !! solo tienes que comentar el de filtrado que descomentar el otro, se llaman igual : "ObtenerPeliculasFiltradas"

            return PeliculaDAO.ObtenerPeliculasFiltradas(generos, idiomas, fecha);
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
      
            Usuario u = UsuarioDAO.findUser(correo);
            if (u == null) throw new ArgumentException("El usuario no existe");

            if (u.email == correo && u.password == password) { this.Usuario = u; return true; } else { throw new ArgumentException("Credenciales incorrectas"); };


        }

    
     
    }
}
