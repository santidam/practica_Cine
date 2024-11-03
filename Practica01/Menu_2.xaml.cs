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

namespace Practica01
{
    /// <summary>
    /// Lógica de interacción para Menu_2.xaml
    /// </summary>
    public partial class Menu_2 : VentanaBase, INotifyPropertyChanged
    {
        private Controlador Controlador;
        private MainWindow MainWindow;
        private MostrarPeliculas MostrarPeliculas;
        private Visibility _cargarPeliculasVisibility;
        


        public event PropertyChangedEventHandler PropertyChanged;

        public Menu_2(Controlador controlador, MainWindow mainWindow)
        {
            InitializeComponent();
            this.MostrarPeliculas = new MostrarPeliculas(ContentArea);
            ContentArea.Navigate(MostrarPeliculas); //La pantalla inicial será MostrarPeliculas
            this.Controlador = controlador;
            this.MainWindow = mainWindow;
            this.DataContext =this;
            bool isAdmin = CheckUserIsAdmin();
            SetUserPermissions(isAdmin);
        }

      

        private void Creadores_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Show();
            this.Close();
        }

        private void Cargar_Peliculas_Click(object sender, RoutedEventArgs e)
        {
            if (Controlador.isAdmin()) { ContentArea.Navigate(new CargarPeliculas()); };

        }

        private void Menu_Inicio_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Navigate(new MostrarPeliculas(ContentArea));
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        private bool CheckUserIsAdmin()
        {
            return Controlador.isAdmin(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button.Tag is string currentTag && bool.TryParse(currentTag, out bool isToggled))
            {
                button.Tag = (!isToggled).ToString(); // Alterna entre "true" y "false"
            }
        }
    }
}
