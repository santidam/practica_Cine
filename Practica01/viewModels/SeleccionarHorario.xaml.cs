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
using Practica01.models;
using Practica01.controller;

namespace Practica01.viewModels
{
   
    public partial class SeleccionarHorario : Page
    {
        
        private string tituloSeleccionado;
        private Frame frame;
        private readonly ObservableCollection<Pelicula> listaPelis;
        private String titulo;
        

        public SeleccionarHorario(MostrarPeliculas mostrarPeliculas, Frame frame)
        {
            InitializeComponent();
            DataContext = mostrarPeliculas;
            this.frame = frame;
            
            Titulo.TargetUpdated += Titulo_TargetUpdated;

        }

        private void horarios_Botones()
        {
            
            HorariosStackPanel.Children.Clear();
            var mostrarPeliculasViewModel = DataContext as MostrarPeliculas;
            if (mostrarPeliculasViewModel != null)
            {
                DateTime? fechaSeleccionada = mostrarPeliculasViewModel.FechaSeleccionada;
               
                {
                    foreach (Sala s in Controlador.Instance.Salas)
                    {
                        Pelicula p = Controlador.Instance.getPeliculaBy_TituloHoraSala(s.TituloPelicula, s.Hora, s.Numero);



                        if (s.Dia == fechaSeleccionada && fechaSeleccionada >= p.fechaInicio && fechaSeleccionada <= p.fechaFin && string.Equals(s.TituloPelicula.Trim(), Titulo.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            
                            Button btn = new Button();
                            btn.Content = ObtenerHoraFormateada(s.Hora) + "\nSala " + s.Numero;
                            btn.Margin = new Thickness(20);
                            btn.Width = 100;
                            btn.Height = 70;
                            btn.Tag = s;
                            btn.Click += new RoutedEventHandler(Boton_Click);
                            HorariosStackPanel.Children.Add(btn);
                        }

                    }
                }
            }

        }
        private void Titulo_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            addSalas();
            horarios_Botones();
            
        }

        private void Boton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {   
                
               Sala s = (Sala)clickedButton.Tag;
               frame.Navigate(new ReservarButaca(this, frame, s));

            }
        }

            public string ObtenerHoraFormateada(TimeSpan hora)
        {
            return hora.ToString(@"hh\:mm");
        }

        public void addSalas()
        {
            var mostrarPeliculasViewModel = DataContext as MostrarPeliculas;
            if (mostrarPeliculasViewModel != null)
            {
                DateTime? fechaSeleccionada = mostrarPeliculasViewModel.FechaSeleccionada;

                {
                    foreach (Pelicula p in Controlador.Instance.pl)
                    {
                        Sala s = new Sala(p.sala, p.horaInicio, fechaSeleccionada, p.titulo);
                        Controlador.Instance.addSala(s);
                    }
                }
            }
        }
    }
}
