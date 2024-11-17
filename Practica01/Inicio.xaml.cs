using Practica01.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Practica01
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Page
    {
        private Controlador Controlador;
        public List<Pelicula> peliculas { get; set; }
        public List<Pelicula> pelisFiltradas { get; set; }
        public string FechaActual { get; set; }


        public Inicio(Controlador controlador)
        {
            InitializeComponent();
            Controlador = controlador;
            peliculas = Controlador.getPeliculas();
            pelisFiltradas = new List<Pelicula>(peliculas);
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
                var peliculasFiltradas = Controlador.listaPeliculas()
                    .Where(pelicula =>
                        (filtrar.generosFiltro.Count == 0 || pelicula.genero.Any(g => filtrar.generosFiltro.Contains(g))) &&
                        (filtrar.idiomasFiltro.Count == 0 || filtrar.idiomasFiltro.Contains(pelicula.idioma)) &&
                        (!filtrar.FechaFiltro.HasValue ||
                        (pelicula.fecha_inicio <= filtrar.FechaFiltro.Value && pelicula.fecha_final >= filtrar.FechaFiltro.Value))
                    )
                    .ToList();

                pelisFiltradas = peliculasFiltradas;
                if (filtrar.FechaFiltro.HasValue)
                {
                    FechaActual = filtrar.FechaFiltro.Value.ToString("dd 'de' MMMM 'de' yyyy", new CultureInfo("es-ES"));
                }
                DataContext = null;
                DataContext = this;
            }
        }

       
    }
}
