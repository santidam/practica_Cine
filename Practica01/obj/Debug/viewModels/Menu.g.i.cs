﻿#pragma checksum "..\..\..\viewModels\Menu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A386E9D647B27C61A8EC9A7C293E7D48EBCBDDE95B9A73BD6F9F541E4CDC9082"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Practica01.models;
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


namespace Practica01.viewModels {
    
    
    /// <summary>
    /// Menu_2
    /// </summary>
    public partial class Menu_2 : Practica01.models.VentanaBase, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\viewModels\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Menu_Inicio;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\viewModels\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Cargar_Peliculas;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\viewModels\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Creadores;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\viewModels\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Salir;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\viewModels\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame ContentArea;
        
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
            System.Uri resourceLocater = new System.Uri("/2.02;component/viewmodels/menu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\viewModels\Menu.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.Menu_Inicio = ((System.Windows.Controls.MenuItem)(target));
            
            #line 25 "..\..\..\viewModels\Menu.xaml"
            this.Menu_Inicio.Click += new System.Windows.RoutedEventHandler(this.Menu_Inicio_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Cargar_Peliculas = ((System.Windows.Controls.MenuItem)(target));
            
            #line 26 "..\..\..\viewModels\Menu.xaml"
            this.Cargar_Peliculas.Click += new System.Windows.RoutedEventHandler(this.Cargar_Peliculas_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Creadores = ((System.Windows.Controls.MenuItem)(target));
            
            #line 27 "..\..\..\viewModels\Menu.xaml"
            this.Creadores.Click += new System.Windows.RoutedEventHandler(this.Creadores_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Salir = ((System.Windows.Controls.MenuItem)(target));
            
            #line 28 "..\..\..\viewModels\Menu.xaml"
            this.Salir.Click += new System.Windows.RoutedEventHandler(this.Salir_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ContentArea = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
