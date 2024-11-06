using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Practica01.models
{
    public class VentanaBase : Window
    {
        public VentanaBase()
        {
            // Configura las propiedades de la ventana base
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            this.Width = 800;
            this.Height = 700;


            // Crear una instancia del UserControl
          
        }      
    }
}
