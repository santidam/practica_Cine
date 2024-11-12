using Practica01.controller;
using Practica01.DAO2;
using Practica01.models;
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

namespace Practica01.viewModels
{
    /// <summary>
    /// Lógica de interacción para Cargar_Peliculas.xaml
    /// </summary>
    public partial class Cargar_Peliculas : Page
    {
      
        public Pelicula Pelicula { get; set; }
        public Controlador Controlador;
        
            public Cargar_Peliculas()
        {
            InitializeComponent();
            this.Pelicula = new Pelicula();
            this.DataContext = Pelicula;
            this.Controlador = Controlador.Instance;
        }

        private void RemovePlaceholder(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox == txtHora && placeholderHora.Visibility == Visibility.Visible)
            {
                placeholderHora.Visibility = Visibility.Hidden;
                textBox.Text = "";
            }
            else if (textBox == txtDuracion && placeholderDuracion.Visibility == Visibility.Visible)
            {
                placeholderDuracion.Visibility = Visibility.Hidden;
                textBox.Text = "";
            }
        }
        private void ShowPlaceholder(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox == txtHora && string.IsNullOrWhiteSpace(textBox.Text))
            {
                placeholderHora.Visibility = Visibility.Visible;
                textBox.Text = "";
            }
            else if (textBox == txtDuracion && string.IsNullOrWhiteSpace(textBox.Text))
            {
                placeholderDuracion.Visibility = Visibility.Visible;
                textBox.Text = "";
            }
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string titulo = txtTitulo.Text;
                string idioma = ((ComboBoxItem)cbIdioma.SelectedItem)?.Content.ToString();
                List<string> generosSeleccionados = lbGeneros.SelectedItems.Cast<ListBoxItem>().Select(item => item.Content.ToString()).ToList();
                DateTime fechaInicio = dpFechaInicio.SelectedDate ?? DateTime.MinValue;
                DateTime fechaFinal = dpFechaFinal.SelectedDate ?? DateTime.MinValue;
                TimeSpan hora = TimeSpan.Parse(txtHora.Text);
                int duracion = int.Parse(txtDuracion.Text);
                int sala = int.Parse(((ComboBoxItem)cbSala.SelectedItem)?.Content.ToString());


                // Validaciones básicas y guardar usando PeliculaDAO
                if (generosSeleccionados.Count > 3 || generosSeleccionados.Count < 1)
                {
                    MessageBox.Show("Seleccione hasta 3 géneros y mínimo 1.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!string.IsNullOrEmpty(titulo) && fechaInicio != DateTime.MinValue && fechaFinal != DateTime.MinValue)
                {
                    // Lógica para guardar película

                    this.Pelicula.idioma = idioma;
                    this.Pelicula.generos = generosSeleccionados;
                    this.Pelicula.fechaInicio = fechaInicio;
                    this.Pelicula.fechaFin = fechaFinal;
                    this.Pelicula.horaInicio = hora;
                    this.Pelicula.duracion = duracion;
                    this.Pelicula.sala = new Sala(sala);


                    // peliculaDAO.InsertarPelicula(nuevaPelicula);
                    Controlador.InsertPelicula(this.Pelicula);
                    MessageBox.Show("Pelicula añadida correctamente", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new Cargar_Peliculas());
                }
                else
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show("Por favor, complete todos los campos en el formato correcto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void SubirArchivo_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                // Lógica para procesar el archivo subido pasarla al controlador despues de unificar

                Controlador.CargarPeliculasCSV(filePath);
                MessageBox.Show($"Archivo cargado: {filePath}", "Archivo Subido", MessageBoxButton.OK, MessageBoxImage.Information);

                //ANTES 
                //ObservableCollection<Pelicula> newPeliculas = Reader.FileRead(filePath);
                //foreach (Pelicula pelicula in newPeliculas)
                //{
                //    PeliculaDAO.InsertarPelicula(pelicula);
                //}
            }
        }

    }


}

