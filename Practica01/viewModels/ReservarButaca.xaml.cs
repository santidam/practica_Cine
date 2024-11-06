using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Practica01.models;
using Practica01.controller;


namespace Practica01.viewModels
{
    /// <summary>
    /// Lógica de interacción para ReservarButaca.xaml
    /// </summary>
    public partial class ReservarButaca : Page


    {
        private Frame frame;
        private Sala sala;
        private ObservableCollection<int> butacasDisponibles;
        private bool toggleButtonEnabled;
        public event PropertyChangedEventHandler PropertyChanged;

        public ReservarButaca(SeleccionarHorario seleccionarHorario, Frame frame, Sala sala)
        {
            InitializeComponent();
            DataContext = seleccionarHorario;
            this.frame = frame;
            this.sala = sala;
            this.butacasDisponibles = sala.DisponibilidadButacas;
            EstadoSala();
        }

        private void Volver_Atras(object sender, RoutedEventArgs e)
        {
            frame.Navigate(DataContext);
        }

        private void Btn_Comprar(object sender, RoutedEventArgs e)
        {
            if (ComprobarCheckedToggleButton() == 0)
            {
                MessageBox.Show("No has seleccionado ningún asiento", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                MessageBoxResult res = MostrarConfirmacion(); 
                frame.Navigate(new MostrarPeliculas(frame));
            }

        }

        public MessageBoxResult MostrarConfirmacion()
        {
            // Mostrar el mensaje de confirmación con botones Yes y No
            MessageBoxResult resultado = MessageBox.Show("Resumen de Compra:\n\n" + this.sala.ToString(),
                                                         "Confirmación de compra",
                                                         MessageBoxButton.YesNo,
                                                         MessageBoxImage.Information);

            return resultado;
        }

        public int ComprobarCheckedToggleButton()
        {
            int contador = 0;
            foreach (UIElement child in toggleButtonWrapPanel.Children)
            {
                if (child is ToggleButton toggleButton && toggleButton.IsChecked == true)
                {
                    contador++;
                    
                    String butaca = toggleButton.Content.ToString();
                    String[] fila_butaca = butaca.Split(' ');
                    char fila = fila_butaca[0][fila_butaca[0].Length -1];
                    int filaNum = int.Parse(fila.ToString()) - 1;
                    char butacaCh = fila_butaca[1][fila_butaca[1].Length - 1];
                    int butacaNum = int.Parse(butacaCh.ToString()) -1;
                    ReservarAsiento(filaNum, butacaNum);
                    

                }
                
            }
            return contador;
        }

        public void ReservarAsiento(int fila, int butaca)
        {
            int index = 3 * fila + butaca; 
            this.butacasDisponibles[index] = 1;
        }

        public void EstadoSala()
        {
            int index = 0;
            foreach (UIElement child in toggleButtonWrapPanel.Children)
            {
                if (child is ToggleButton toggleButton)
                {
                   
               
                if (butacasDisponibles[index] == 1)
                    {
                        toggleButton.IsEnabled = false;
                        toggleButton.Background = new SolidColorBrush(Colors.Red); 
                    }
                    else
                    {
                        toggleButton.IsEnabled = true; 
                       
                    }
                }
                index++;
            }
        }

        
    }
}
