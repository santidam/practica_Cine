﻿#pragma checksum "..\..\Menu_2.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "474CFF246F68D77D06F2150893E318137AE787ADDF99D7AB6D0FFF3D440EF706"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Practica01;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Practica01 {
    
    
    /// <summary>
    /// Menu_2
    /// </summary>
    public partial class Menu_2 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Menu_2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbInicio;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Menu_2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Menu_Inicio;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Menu_2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Cargar_Peliculas;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Menu_2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Filtrar;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Menu_2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Creadores;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Menu_2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Salir;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Menu_2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl ContentArea;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/2.02;component/menu_2.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Menu_2.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lbInicio = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Menu_Inicio = ((System.Windows.Controls.MenuItem)(target));
            
            #line 13 "..\..\Menu_2.xaml"
            this.Menu_Inicio.Click += new System.Windows.RoutedEventHandler(this.Menu_Inicio_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Cargar_Peliculas = ((System.Windows.Controls.MenuItem)(target));
            
            #line 14 "..\..\Menu_2.xaml"
            this.Cargar_Peliculas.Click += new System.Windows.RoutedEventHandler(this.Cargar_Peliculas_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Filtrar = ((System.Windows.Controls.MenuItem)(target));
            
            #line 15 "..\..\Menu_2.xaml"
            this.Filtrar.Click += new System.Windows.RoutedEventHandler(this.Filtrar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Creadores = ((System.Windows.Controls.MenuItem)(target));
            
            #line 16 "..\..\Menu_2.xaml"
            this.Creadores.Click += new System.Windows.RoutedEventHandler(this.Creadores_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Salir = ((System.Windows.Controls.MenuItem)(target));
            
            #line 17 "..\..\Menu_2.xaml"
            this.Salir.Click += new System.Windows.RoutedEventHandler(this.Salir_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ContentArea = ((System.Windows.Controls.ContentControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

