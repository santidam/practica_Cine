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
    /// <summary>
    /// Lógica de interacción para SeleccionarHorario.xaml
    /// </summary>
    public partial class SeleccionarHorario : Page
    {
        private ObservableCollection<Pelicula> listaPelis;
        private string tituloSeleccionado;
        private Frame frame;

        public SeleccionarHorario(MostrarPeliculas mostrarPeliculas, String titulo, Frame frame)
        {
            InitializeComponent();
            DataContext = mostrarPeliculas;
            PelisList pelisList = new PelisList();
            this.listaPelis = pelisList.OrdenarPeliculasPorHoraInicio();
            this.tituloSeleccionado = titulo;
            this.frame = frame;


            horarios_Botones();
        }

        private void horarios_Botones()
        {
            HorariosStackPanel.Children.Clear();
            MessageBox.Show($"El título actual es: {tituloSeleccionado}");
            foreach (Pelicula p in listaPelis)
            {
                if (p.titulo == Titulo.Text)
                {
                    Button btn = new Button();
                    btn.Content = ObtenerHoraFormateada(p.horaInicio) + "\nSala " + p.sala;
                    btn.Margin = new Thickness(20);
                    btn.Width = 100;
                    btn.Height = 70;
                    btn.Click += new RoutedEventHandler(Boton_Click);
                    HorariosStackPanel.Children.Add(btn);
                }

            }
        }
        private void Boton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {

               frame.Navigate(new ReservarButaca(this, frame));


            }
        }

            public string ObtenerHoraFormateada(TimeSpan hora)
        {
            return hora.ToString(@"hh\:mm");
        }
    }
}
