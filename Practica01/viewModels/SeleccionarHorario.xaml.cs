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
using Microsoft.SqlServer.Server;
using System.Globalization;

namespace Practica01.viewModels
{
   
    public partial class SeleccionarHorario : Page
    {
        
        private Frame frame;
        

        public SeleccionarHorario(InicioPeliculas mostrarPeliculas, Frame frame)
        {
            InitializeComponent();
            DataContext = mostrarPeliculas;
            this.frame = frame;
            
            Titulo.TargetUpdated += Titulo_TargetUpdated;

        }

        private void horarios_Botones()
        {
            
            HorariosStackPanel.Children.Clear();
            var mostrarPeliculasViewModel = DataContext as InicioPeliculas;
            //if (mostrarPeliculasViewModel != null)

            //{
                DateTime? fechaSeleccionada = mostrarPeliculasViewModel.FechaActual;
                if (!fechaSeleccionada.HasValue) { fechaSeleccionada = DateTime.Today; }
               
                {
                    foreach (Pelicula p in Controlador.Instance.getPeliculasBy_TituloFecha(Titulo.Text,(DateTime)fechaSeleccionada))
                    {
                        
                            
                            Button btn = new Button();
                            btn.Content = ObtenerHoraFormateada(p.horaInicio) + "\nSala " + p.sala.numero+"\n"+p.idioma;
                            btn.Margin = new Thickness(20);
                            btn.Width = 100;
                            btn.Height = 70;
                            btn.Tag = p;
                            btn.Click += new RoutedEventHandler(Boton_Click);
                            btn.Background = Brushes.AliceBlue;
                            HorariosStackPanel.Children.Add(btn);
                       
                    }
                }
            //}

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
                
               Pelicula p = Controlador.Instance.getSesion((Pelicula)clickedButton.Tag);
               frame.Navigate(new ReservarButaca(this, frame, p));

            }
        }

            public string ObtenerHoraFormateada(TimeSpan hora)
        {
            return hora.ToString(@"hh\:mm");
        }

        
    }
}
