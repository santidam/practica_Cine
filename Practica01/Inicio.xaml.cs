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
        public Inicio(Controlador controlador)
        {
            InitializeComponent();
            this.Controlador = controlador;
            this.DataContext = controlador;
        }

        private void ModificarUsuario_Click(object sender, RoutedEventArgs e)
        {
            int indice = dataGridPeliculas.SelectedIndex;
            if (indice == -1)
            {
                MessageBox.Show("Debes seleccionar un elemento", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else { 
                Usuario u = (Usuario)dataGridPeliculas.SelectedItem;
                ModificarUsuarios mf = new ModificarUsuarios(this.Controlador, u, indice);
                mf.ShowDialog();

            }
            
        }
    }
}
