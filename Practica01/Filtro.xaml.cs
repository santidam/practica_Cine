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
        public DateTime? FechaFiltro
        {
            get { return fechaPicker.SelectedDate; }
        }
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
            if (doc.IsChecked == true) generosFiltro.Add("Documental");
            if (drama.IsChecked == true) generosFiltro.Add("Drama");
            if (fantasia.IsChecked == true) generosFiltro.Add("Fantasía");
            if (musical.IsChecked == true) generosFiltro.Add("Musical");
            if (terror.IsChecked == true) generosFiltro.Add("Terror");
            if (cf.IsChecked == true) generosFiltro.Add("Ciencia Ficción");

            if (original.IsChecked == true) idiomasFiltro.Add("Version Original");
            if (cast.IsChecked == true) idiomasFiltro.Add("Castellano");

            this.DialogResult = true; 
            this.Close();
        }
    }
}
