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
using Practica01.models;
using Practica01.controller;
using System.Windows.Media.Animation;
using System.Diagnostics;

namespace Practica01
{
    /// <summary>
    /// Lógica de interacción para Creditos.xaml
    /// </summary>
    public partial class Creditos : Page
    {
        public Creditos()
        {
            InitializeComponent();
            VideoFazgorn.Source = new Uri("C:/Users/admin/source/repos/Practica01/Practica01/images/FazgornCines - copia.avi");

            this.Loaded += Creditos_Loaded; // Agregar el evento Loaded
            VideoFazgorn.MediaFailed += (s, args) =>
            {
                MessageBox.Show("Error al cargar el video. Verifica la ruta y el formato.");
            };

        }
        private void Creditos_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                VideoFazgorn.Play(); // Inicia la reproducción del video
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reproducir el video: {ex.Message}");
            }
        }
        public void DetenerVideo()
        {
            if (VideoFazgorn != null)
            {
                VideoFazgorn.Stop();
            }
        }
        private void Creditos_Unloaded(object sender, RoutedEventArgs e)
        {
            DetenerVideo();
        }



        private void ChangeImage_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el botón clicado
            Button clickedButton = sender as Button;

            // Obtener la ruta de la imagen desde el Tag del botón
            string newImageSource = clickedButton?.Tag?.ToString();

            if (!string.IsNullOrEmpty(newImageSource))
            {
                //MessageBox.Show($"Ruta de la imagen: {newImageSource}");

                // Asignar la nueva imagen al control Image
                imageDisplay.Source = new BitmapImage(new Uri($"pack://application:,,,/{newImageSource}"));

                // Iniciar animación de deslizamiento
                AnimateImage();
                AnimateOpacity();
            }
        }
        private void AnimateOpacity()
        {
            DoubleAnimation fadeAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };

            imageDisplay.BeginAnimation(UIElement.OpacityProperty, fadeAnimation);
        }

        private void AnimateImage()
        {
            // Crear Storyboard
            Storyboard storyboard = new Storyboard();

            // Animación de deslizamiento
            DoubleAnimation slideAnimation = new DoubleAnimation
            {
                From = -200, // Empieza más arriba
                To = 0,     // Regresa a la posición original
                Duration = new Duration(TimeSpan.FromSeconds(1)), // Duración de 0.5 segundos
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };

            // Aplicar la animación al TranslateTransform de la imagen
            Storyboard.SetTarget(slideAnimation, imageTransform);
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath(TranslateTransform.YProperty));

            // Ejecutar la animación
            storyboard.Children.Add(slideAnimation);
            storyboard.Begin();
        }

        private void imageDisplay_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (imageDisplay.Source is BitmapImage currentImage)
            {
                string imageUri = currentImage.UriSource.ToString();

                // Compara la ruta de la imagen para decidir la URL
                if (imageUri.EndsWith("san.png"))
                {
                    OpenUrl("https://github.com/santidam");
                }
                else if (imageUri.EndsWith("val.png"))
                {
                    OpenUrl("https://github.com/valentinagbf");
                }
                else if (imageUri.EndsWith("jor.png"))
                {
                    OpenUrl("https://github.com/Jodrix15");
                }
            }
        }
        // Método para abrir la URL en el navegador predeterminado
        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir la URL: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
