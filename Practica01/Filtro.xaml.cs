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
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Filtro : Window
    {
        public List<string> generosFiltro { get; private set; } = new List<string>();
        public List<string> idiomasFiltro { get; private set; } = new List<string>();
        public Filtro()
        {
            InitializeComponent();
        }

        private void AplicarFiltro(object sender, RoutedEventArgs e)
        {
            if (accion.IsChecked == true) generosFiltro.Add("Acción");
            if (comedia.IsChecked == true) generosFiltro.Add("Comedia");
            if (suspenso.IsChecked == true) generosFiltro.Add("Suspenso");
            if (aventura.IsChecked == true) generosFiltro.Add("Aventura");
            if (ingles.IsChecked == true) idiomasFiltro.Add("Ingles");
            if (español.IsChecked == true) idiomasFiltro.Add("Español");

            this.DialogResult = true; 
            this.Close();
        }
    }
}
