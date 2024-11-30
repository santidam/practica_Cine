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
        private Usuario Usuario;
        private Controlador Controlador;
        private int numErrors;
        private int ErrorsClose;
        public MainWindow()
        {
            InitializeComponent();
            this.Usuario = new Usuario();
            this.DataContext = this.Usuario;
            this.Controlador = new Controlador();
        }
        public void DisplayErrorsValidation()
        {
            string msg = "";
            foreach (string st in Usuario.erroresReales)
            {
                if (!string.IsNullOrEmpty(st))
                {
                    msg += st + Environment.NewLine;
                }
                
            }
            labelValidationErrors.Content = msg;
        }

 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (Controlador.validUser(tbCorreo.Text, tbPass.Text)) { Menu_2 menu_2 = new Menu_2(Controlador, this); menu_2.Show(); this.Close(); };
               
            }
            catch (ArgumentException ex)
            {
                ErrorsClose++;
                var intentos = 3 - ErrorsClose;
                MessageBox.Show(ex.Message+". INTENTOS RESTANTES: "+intentos, "ERROR NÚMERO "+ErrorsClose, MessageBoxButton.OK, MessageBoxImage.Error);
                if(ErrorsClose==3)this.Close();
            }

        }
        public void FunctionValidationError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                numErrors++;
            } else
            {
                numErrors--;
            }
            if (numErrors == 0)
            {
                btnEntrar.IsEnabled = true;
                DisplayErrorsValidation();
            } else
            {
                btnEntrar.IsEnabled = false;
                DisplayErrorsValidation();

            }
        }
    } 
}
