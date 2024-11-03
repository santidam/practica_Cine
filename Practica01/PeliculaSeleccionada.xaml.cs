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
using System.Windows.Shapes;

namespace Practica01
{
    /// <summary>
    /// Lógica de interacción para PeliculaSeleccionada.xaml
    /// </summary>
    public partial class PeliculaSeleccionada : VentanaBase
    {
        private ObservableCollection<Pelicula> listaPelis;
        private string tituloSeleccionado;

        public PeliculaSeleccionada(MostrarPeliculas mostrarPeliculas, String titulo)
        {
            InitializeComponent();
            DataContext = mostrarPeliculas;
            PelisList pelisList = new PelisList();
            this.listaPelis = pelisList.OrdenarPeliculasPorHoraInicio();
            this.tituloSeleccionado = titulo;

            
            horarios_Botones();
        }

        private void horarios_Botones()
        {
            HorariosStackPanel.Children.Clear();
            MessageBox.Show($"El título actual es: {tituloSeleccionado}");
            foreach (Pelicula p in listaPelis)
            {
                if(p.titulo == Titulo.Text)
                {
                    Button btn = new Button();
                    btn.Content = ObtenerHoraFormateada(p.horaInicio) +"\nSala "+ p.sala;
                    btn.Margin = new Thickness(20);
                    btn.Width = 100;
                    btn.Height = 70;
                    HorariosStackPanel.Children.Add(btn);
                }
                
            }
        }

        public string ObtenerHoraFormateada(TimeSpan hora)
        {
            return hora.ToString(@"hh\:mm");
        }
    }
}
