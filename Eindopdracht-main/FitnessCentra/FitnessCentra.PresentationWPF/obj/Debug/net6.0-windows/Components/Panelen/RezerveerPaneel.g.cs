﻿#pragma checksum "..\..\..\..\..\Components\Panelen\RezerveerPaneel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E8CA66A0D2E2FD4062CD492D8DEF57B039479D05"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FitnessCentra.PresentationWPF.Components;
using FitnessCentra.PresentationWPF.Components.Optiebox;
using FitnessCentra.PresentationWPF.Components.Panelen;
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


namespace FitnessCentra.PresentationWPF.Components.Panelen {
    
    
    /// <summary>
    /// RezerveerPaneel
    /// </summary>
    public partial class RezerveerPaneel : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\..\Components\Panelen\RezerveerPaneel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FitnessCentra.PresentationWPF.Components.Callender callender;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\Components\Panelen\RezerveerPaneel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel overzicht;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\Components\Panelen\RezerveerPaneel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label dagNr;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\..\Components\Panelen\RezerveerPaneel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label maand;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\..\Components\Panelen\RezerveerPaneel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label dag;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\..\Components\Panelen\RezerveerPaneel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel rezerveerOverzicht;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\..\Components\Panelen\RezerveerPaneel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border tijdslotKiezerPanel;
        
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
            System.Uri resourceLocater = new System.Uri("/FitnessCentra.PresentationWPF;component/components/panelen/rezerveerpaneel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Components\Panelen\RezerveerPaneel.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.callender = ((FitnessCentra.PresentationWPF.Components.Callender)(target));
            return;
            case 2:
            this.overzicht = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.dagNr = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.maand = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.dag = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.rezerveerOverzicht = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.tijdslotKiezerPanel = ((System.Windows.Controls.Border)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

