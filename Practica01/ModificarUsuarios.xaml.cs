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
    /// Lógica de interacción para ModificarUsuarios.xaml
    /// </summary>
    public partial class ModificarUsuarios : Window
    {

        private Controlador Controlador;
        private Usuario  Usuario;
        private int Indice;
        public ModificarUsuarios(Controlador controlador, Usuario usuario, int indice)
        {
            InitializeComponent();
            this.Controlador = controlador;
            this.Usuario = usuario;
            this.DataContext = this.Usuario;
            this.Indice = indice;
        }

        private void GuardarCambios_Click(object sender, RoutedEventArgs e)
        {
            Controlador.ModUserByIndex((Usuario)Usuario.Clone(), Indice);
            this.Close();
        }
    }
}
