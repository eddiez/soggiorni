﻿#pragma checksum "..\..\..\CheckinSoggiornoWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AC4AA89E3EFCE215C8D440E76E26FD4E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Soggiorni {
    
    
    /// <summary>
    /// CheckinSoggiornoWindow
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class CheckinSoggiornoWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\CheckinSoggiornoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtSchede;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\CheckinSoggiornoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridSchede;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\CheckinSoggiornoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddScheda;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\CheckinSoggiornoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteScheda;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\CheckinSoggiornoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAnnulla;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\CheckinSoggiornoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSalva;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\CheckinSoggiornoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPrint;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\CheckinSoggiornoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPrestampato;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\CheckinSoggiornoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNewCliente;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Soggiorni;component/checkinsoggiornowindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CheckinSoggiornoWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtSchede = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.dataGridSchede = ((System.Windows.Controls.DataGrid)(target));
            
            #line 7 "..\..\..\CheckinSoggiornoWindow.xaml"
            this.dataGridSchede.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dataGridSchede_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnAddScheda = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\CheckinSoggiornoWindow.xaml"
            this.btnAddScheda.Click += new System.Windows.RoutedEventHandler(this.btnAddScheda_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnDeleteScheda = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\CheckinSoggiornoWindow.xaml"
            this.btnDeleteScheda.Click += new System.Windows.RoutedEventHandler(this.btnDeleteScheda_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnAnnulla = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\CheckinSoggiornoWindow.xaml"
            this.btnAnnulla.Click += new System.Windows.RoutedEventHandler(this.btnAnnulla_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnSalva = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\CheckinSoggiornoWindow.xaml"
            this.btnSalva.Click += new System.Windows.RoutedEventHandler(this.btnSalva_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnPrint = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\CheckinSoggiornoWindow.xaml"
            this.btnPrint.Click += new System.Windows.RoutedEventHandler(this.btnPrint_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnPrestampato = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\CheckinSoggiornoWindow.xaml"
            this.btnPrestampato.Click += new System.Windows.RoutedEventHandler(this.btnPrestampato_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnNewCliente = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\CheckinSoggiornoWindow.xaml"
            this.btnNewCliente.Click += new System.Windows.RoutedEventHandler(this.btnNewCliente_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

