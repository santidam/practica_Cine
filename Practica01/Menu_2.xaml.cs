using Practica01.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Practica01
{
    /// <summary>
    /// Lógica de interacción para Menu_2.xaml
    /// </summary>
    public partial class Menu_2 : Window
    {
        private Controlador Controlador;
        private MainWindow MainWindow;
        public ObservableCollection<Pelicula> peliculas { get; set; }

        public Menu_2(Controlador controlador, MainWindow mainWindow)
        {
            InitializeComponent();
            this.Controlador = controlador;
            this.MainWindow = mainWindow;
            peliculas = Controlador.getPeliculas();
            DataContext = this;
            Controlador.getPeliculas();
        }

        private void Menu_Inicio_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cargar_Peliculas_Click(object sender, RoutedEventArgs e)
        {
            //ContentArea.Navigate(new Cargar_Peliculas());
        }

        
        private void Creadores_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Show();
            this.Close();
        }

        private void Filtro_Click(object sender, RoutedEventArgs e)
        {
            Filtro filtrar = new Filtro();
            if (filtrar.ShowDialog() == true) {
                var peliculasFiltradas = Controlador.listaPeliculas()
            .Where(pelicula =>
                (filtrar.generosFiltro.Count == 0 || pelicula.genero.Any(g => filtrar.generosFiltro.Contains(g))) &&
                (filtrar.idiomasFiltro.Count == 0 || filtrar.idiomasFiltro.Contains(pelicula.idioma))
            )
            .ToList();
                peliculas.Clear();
                foreach (var pelicula in peliculasFiltradas)
                {
                    peliculas.Add(pelicula);
                }
            }
        }
        
    }
}
