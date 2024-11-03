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
    /// Lógica de interacción para ReservarButaca.xaml
    /// </summary>
    public partial class ReservarButaca : Page


    {
        private Frame frame;
        public ReservarButaca(SeleccionarHorario seleccionarHorario, Frame frame)
        {
            InitializeComponent();
            DataContext = seleccionarHorario;
            this.frame = frame;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
