﻿#pragma checksum "..\..\..\..\..\Components\Panelen\BeheerdersPaneel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6CBD2B0E62A427E1117C90BFFA1B162CEB249161"
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
using FitnessCentra.PresentationWPF.Components.Labels;
using FitnessCentra.PresentationWPF.Components.Optiebox;
using FitnessCentra.PresentationWPF.Components.Panelen;
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
    /// BeheerdersPaneel
    /// </summary>
    public partial class BeheerdersPaneel : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\..\Components\Panelen\BeheerdersPaneel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FitnessCentra.PresentationWPF.Components.Panelen.BeheerdersPaneel root;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\Components\Panelen\BeheerdersPaneel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel menuPaneel;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\Components\Panelen\BeheerdersPaneel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel hoofding;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\Components\Panelen\BeheerdersPaneel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border verwijderBtn;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\..\..\Components\Panelen\BeheerdersPaneel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel content;
        
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
            System.Uri resourceLocater = new System.Uri("/FitnessCentra.PresentationWPF;V1.0.0.0;component/components/panelen/beheerderspa" +
                    "neel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Components\Panelen\BeheerdersPaneel.xaml"
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
            this.root = ((FitnessCentra.PresentationWPF.Components.Panelen.BeheerdersPaneel)(target));
            return;
            case 2:
            this.menuPaneel = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 3:
            this.hoofding = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.verwijderBtn = ((System.Windows.Controls.Border)(target));
            return;
            case 5:
            
            #line 55 "..\..\..\..\..\Components\Panelen\BeheerdersPaneel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.verwijderBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 71 "..\..\..\..\..\Components\Panelen\BeheerdersPaneel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnderhoudToestel_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 87 "..\..\..\..\..\Components\Panelen\BeheerdersPaneel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.VoegNiewToestelToe_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.content = ((System.Windows.Controls.WrapPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

