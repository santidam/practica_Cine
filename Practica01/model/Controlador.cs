using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Practica01.DAO;

namespace Practica01.model
{
    public class Controlador
    {
        private List<Pelicula> Peliculas {  get; set; }
        private ObservableCollection<Usuario> Usuarios { get; set; }
        public ObservableCollection<Usuario> Usuarios2
        {
            get {  return Usuarios; }
            set { Usuarios = value; }
        }
        private Usuario Usuario {  get; set; }
        private List<Sala> Salas {  get; set; }
        private UsuarioDAO UsuarioDAO { get; set; }


        public Controlador ()
        {
            this.UsuarioDAO = new UsuarioDAO();
            this.Peliculas = new List<Pelicula> ();
            this.Salas = new List<Sala> ();
            this.Usuarios = UsuarioDAO.ObtenerUsuarios();
            this.Usuario = null;
            for(int i = 1; i < 4; i++) {Salas.Add (new Sala (i));}
            //UsuarioDAO.InsertarUsuario(new Usuario("email@prueba.com", "admin", "1234", true));
            //UsuarioDAO.InsertarUsuario(new Usuario("email2@prueba.com", "admin", "1234"));
            //Usuarios.Add(new Usuario("email@prueba.com", "admin", "1234", true));
            //Usuarios.Add(new Usuario("email2@prueba.com", "admin", "1234"));
            

          
        }
        public Boolean validUser(String correo, String password) 
        {
            valMail(correo);
            valPassword(password);
            Usuario u = findUser (correo);
            if (u == null) throw new ArgumentException("El usuario no existe");
            
            if( u.email == correo && u.password == password) { this.Usuario = u; return true; } else { throw new ArgumentException("Credenciales incorrectas"); };
            
          
        }
        public bool isAdmin()
        {
            return Usuario.admin;
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

        public void ModUserByIndex(Usuario u, int indice)
        {
            Usuarios[indice] = u;
        }
    }
}
