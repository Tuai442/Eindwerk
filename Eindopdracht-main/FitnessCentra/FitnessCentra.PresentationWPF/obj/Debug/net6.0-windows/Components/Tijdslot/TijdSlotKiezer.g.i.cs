﻿#pragma checksum "..\..\..\..\..\Components\Tijdslot\TijdslotKiezer.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FBEC490FF1AFDE385257E8C1C4282DF5DA18BA81"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FitnessCentra.PresentationWPF.Components.Tijdslot;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace FitnessCentra.PresentationWPF.Components.Tijdslot {
    
    
    /// <summary>
    /// TijdslotKiezer
    /// </summary>
    public partial class TijdslotKiezer : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\..\..\Components\Tijdslot\TijdslotKiezer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FitnessCentra.PresentationWPF.Components.Tijdslot.TijdslotKiezer root;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\..\Components\Tijdslot\TijdslotKiezer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label titel;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\Components\Tijdslot\TijdslotKiezer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel mainGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FitnessCentra.PresentationWPF;V1.0.0.0;component/components/tijdslot/tijdslotkie" +
                    "zer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Components\Tijdslot\TijdslotKiezer.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.root = ((FitnessCentra.PresentationWPF.Components.Tijdslot.TijdslotKiezer)(target));
            return;
            case 2:
            this.titel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.mainGrid = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 4:
            
            #line 20 "..\..\..\..\..\Components\Tijdslot\TijdslotKiezer.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Rezerveer_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 21 "..\..\..\..\..\Components\Tijdslot\TijdslotKiezer.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Stop_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

