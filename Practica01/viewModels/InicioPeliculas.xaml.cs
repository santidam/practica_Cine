using Practica01.controller;
using Practica01.DAO2;
using Practica01.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class InicioPeliculas : Page, INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _textoPelicula;


        private Controlador Controlador;
        public List<Pelicula> peliculas { get; set; }
        public List<Pelicula> pelisFiltradas { get; set; }
        public DateTime FechaActual { get; set; }
        private PeliculaDAO peliculaDAO;
        private Frame Frame;
        public InicioPeliculas(Frame frame)
        {
            this.Frame = frame;
            InitializeComponent();
            Controlador = Controlador.Instance;
            peliculas = Controlador.GetPeliculasToday();
            
            peliculaDAO = new PeliculaDAO();
            CargarPeliculasHoy();
        }
        private void CargarPeliculasHoy()
        {
            pelisFiltradas = peliculaDAO.ObtenerPeliculasToday();
            FechaActual = DateTime.Today;
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

               

                if (fechaFiltro.HasValue)
                {
                    FechaActual = fechaFiltro.Value;
                }
                pelisFiltradas = peliculaDAO.ObtenerPeliculasFiltradas(generosFiltro, idiomasFiltro, FechaActual);

                DataContext = null;
                DataContext = this;
            }
        }

        public string TextoPelicula
        {
            get => _textoPelicula;
            set
            {
                _textoPelicula = value;
                OnPropertyChanged(nameof(TextoPelicula));
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


       
        private void btnPeli_Click(object sender, RoutedEventArgs e)
        {
            TextoPelicula = ((Button)sender).Content.ToString();

            NavigationService.Navigate(new SeleccionarHorario(this, Frame));

        }
    }
}
