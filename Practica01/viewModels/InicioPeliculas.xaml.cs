using Practica01.controller;
using Practica01.DAO2;
using Practica01.models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practica01.viewModels
{
    /// <summary>
    /// Lógica de interacción para InicioPeliculas.xaml
    /// </summary>
    public partial class InicioPeliculas : Page

    {
        private Controlador Controlador;
        public List<Pelicula> peliculas { get; set; }
        public List<Pelicula> pelisFiltradas { get; set; }
        public string FechaActual { get; set; }
        private PeliculaDAO peliculaDAO;
        public InicioPeliculas()
        {
            InitializeComponent();
            Controlador = Controlador.Instance;
            peliculas = Controlador.GetPeliculasToday();
            
            peliculaDAO = new PeliculaDAO();
            CargarPeliculasHoy();
        }
        private void CargarPeliculasHoy()
        {
            pelisFiltradas = peliculaDAO.ObtenerPeliculasToday();
            FechaActual = DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy", new CultureInfo("es-ES"));
            DataContext = this;
        }
        internal void ShowDialog()
        {
            throw new NotImplementedException();
        }

        private void Filtro_Click(object sender, RoutedEventArgs e)
        {
            Filtro filtrar = new Filtro();
            if (filtrar.ShowDialog() == true)
            {

                var generosFiltro = filtrar.generosFiltro;
                var idiomasFiltro = filtrar.idiomasFiltro;
                var fechaFiltro = filtrar.FechaFiltro;

                pelisFiltradas = peliculaDAO.ObtenerPeliculasFiltradas(generosFiltro, idiomasFiltro, fechaFiltro);

                if (fechaFiltro.HasValue)
                {
                    FechaActual = fechaFiltro.Value.ToString("dd 'de' MMMM 'de' yyyy", new CultureInfo("es-ES"));
                }

                DataContext = null;
                DataContext = this;
            }
        }
    }
}
