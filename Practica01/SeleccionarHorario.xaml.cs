using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
   
    public partial class SeleccionarHorario : Page
    {
        
        private string tituloSeleccionado;
        private Frame frame;
        private readonly ObservableCollection<Pelicula> listaPelis;
        private HashSet<Sala> salas;
        private String titulo;
        

        public SeleccionarHorario(MostrarPeliculas mostrarPeliculas, Frame frame)
        {
            InitializeComponent();
            DataContext = mostrarPeliculas;
            this.listaPelis = Controlador.Instance.listaPeliculas();
            this.frame = frame;
            Titulo.TargetUpdated += Titulo_TargetUpdated;

            
        }

        private void horarios_Botones()
        {
            
            HorariosStackPanel.Children.Clear();          
            {
                foreach (Pelicula p in this.listaPelis)
                {
                    if (string.Equals(p.titulo.Trim(), Titulo.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        Button btn = new Button();
                        btn.Content = ObtenerHoraFormateada(p.horaInicio) + "\nSala " + p.sala;
                        btn.Margin = new Thickness(20);
                        btn.Width = 100;
                        btn.Height = 70;
                        btn.Tag = p;
                        btn.Click += new RoutedEventHandler(Boton_Click);
                        HorariosStackPanel.Children.Add(btn);
                    }
                }
            }

        }
        private void Titulo_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            horarios_Botones();
        }

        private void Boton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {   
                
                Pelicula p = (Pelicula)clickedButton.Tag;
                Sala sala = Controlador.Instance.getSalaBy_NumHoraDia(p.sala, p.horaInicio, "24/11/2024");
               
                frame.Navigate(new ReservarButaca(this, frame, sala));


            }
        }

            public string ObtenerHoraFormateada(TimeSpan hora)
        {
            return hora.ToString(@"hh\:mm");
        }
    }
}
