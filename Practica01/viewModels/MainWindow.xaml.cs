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
using Practica01.controller;
using Practica01.models;


namespace Practica01.viewModels
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : VentanaBase
    {
        private Controlador Controlador;
        public MainWindow()
        {
            InitializeComponent();
            this.Controlador = new Controlador();
        }

 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (Controlador.validUser(tbCorreo.Text, tbPass.Password)) { Menu_2 menu_2 = new Menu_2(Controlador, this); menu_2.Show(); this.Hide(); };
               
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
