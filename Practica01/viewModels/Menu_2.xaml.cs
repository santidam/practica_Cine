using System;
using System.Collections.Generic;
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
using Practica01.models;
using Practica01.controller;

namespace Practica01.viewModels
{
    /// <summary>
    /// Lógica de interacción para Menu_2.xaml
    /// </summary>
    public partial class Menu_2 : VentanaBase, INotifyPropertyChanged
    {
        private Controlador Controlador;
        private MainWindow MainWindow;
        private InicioPeliculas mostrarPeliculas;
        private Creditos creditos;
        private Cargar_Peliculas cargarPeliculas;
        private Visibility _cargarPeliculasVisibility;
        
        public event PropertyChangedEventHandler PropertyChanged;

       
       

        

        public Menu_2(Controlador controlador, MainWindow mainWindow)
        {
            InitializeComponent();
            this.Controlador = controlador;
            this.MainWindow = mainWindow;
            this.DataContext = this;

            // Instancias iniciales de las páginas
            this.mostrarPeliculas = new InicioPeliculas(ContentArea);
            this.creditos = new Creditos();
            this.cargarPeliculas = new Cargar_Peliculas();

            // Página inicial
            ContentArea.Navigate(MostrarPeliculas);

            SetUserPermissions(Controlador.isAdmin());
        }

      

        private void Creadores_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Navigate(Creditos);
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Cargar_Peliculas_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Navigate(CargarPeliculas); 

        }

        private void Menu_Inicio_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Navigate(new InicioPeliculas(ContentArea));
        }
        

        public Visibility CargarPeliculasVisibility
        {
            get { return _cargarPeliculasVisibility; }
            set
            {
                _cargarPeliculasVisibility = value;
                OnPropertyChanged(nameof(CargarPeliculasVisibility));
            }
        }

        public void SetUserPermissions(bool isAdmin)
        {
            CargarPeliculasVisibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public InicioPeliculas MostrarPeliculas
        {
            get => mostrarPeliculas;
            set
            {
                mostrarPeliculas = value;
                OnPropertyChanged(nameof(MostrarPeliculas));
            }
        }

        public Creditos Creditos
        {
            get => creditos;
            set
            {
                creditos = value;
                OnPropertyChanged(nameof(Creditos));
            }
        }

        public Cargar_Peliculas CargarPeliculas
        {
            get => cargarPeliculas;
            set
            {
                cargarPeliculas = value;
                OnPropertyChanged(nameof(CargarPeliculas));
            }
        }


    }
}
