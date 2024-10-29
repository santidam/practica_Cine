using Practica01.model;
using System;
using System.Collections.Generic;
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
        public Menu_2(Controlador controlador, MainWindow mainWindow)
        {
            InitializeComponent();
            this.Controlador = controlador;
            this.MainWindow = mainWindow;
        }

        private void Menu_Inicio_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new Inicio(Controlador));
        }

        private void Cargar_Peliculas_Click(object sender, RoutedEventArgs e)
        {
            if (Controlador.isAdmin()) { Frame.Navigate(new Cargar_Peliculas()); } else { MessageBox.Show("No tienes los permisos necesarios para acceder", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error); }
            
        }

        private void Filtrar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Creadores_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Show();
            this.Close();
        }
    }
}
