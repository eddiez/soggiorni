﻿#pragma checksum "..\..\..\AddEditServizioWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "729EBBC3A9EBB7DE8DC886EBCEC8C991"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
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
    /// AddEditServizioWindow
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class AddEditServizioWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\AddEditServizioWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxTipo;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\AddEditServizioWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtboxTotale;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\AddEditServizioWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtboxDescr;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\AddEditServizioWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtDescr;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\AddEditServizioWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTotale;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\AddEditServizioWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTipo;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\AddEditServizioWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnInsert;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\AddEditServizioWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAnnulla;
        
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
            System.Uri resourceLocater = new System.Uri("/Soggiorni;component/addeditserviziowindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddEditServizioWindow.xaml"
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
            this.cbxTipo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.txtboxTotale = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtboxDescr = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtDescr = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.txtTotale = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.txtTipo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.btnInsert = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\AddEditServizioWindow.xaml"
            this.btnInsert.Click += new System.Windows.RoutedEventHandler(this.btnInsert_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnAnnulla = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\AddEditServizioWindow.xaml"
            this.btnAnnulla.Click += new System.Windows.RoutedEventHandler(this.btnAnnulla_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

