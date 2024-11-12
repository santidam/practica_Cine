using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// <summary>
    /// Lógica de interacción para MostrarPeliculas.xaml
    /// </summary>
    public partial class MostrarPeliculas : Page, INotifyPropertyChanged


    {
        private string _textoPelicula;
        private Frame frame;
        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime? _fechaSeleccionada;

        public DateTime? FechaSeleccionada
        {
            get => _fechaSeleccionada;
            set
            {
                _fechaSeleccionada = value;
                OnPropertyChanged(nameof(FechaSeleccionada));
            }
        }





        public string TextoPelicula
        {
            get => _textoPelicula;
            set
            {
                _textoPelicula = value;
                OnPropertyChanged(nameof(TextoPelicula));
            }
        }

        public MostrarPeliculas(Frame frame)
        {
            InitializeComponent();
            this.frame = frame;
            DataContext = this;
        }
       

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextoPelicula = ((Button)sender).Content.ToString();
            frame.Navigate(new SeleccionarHorario(this, frame));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
