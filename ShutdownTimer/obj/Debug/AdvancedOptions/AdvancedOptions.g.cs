﻿#pragma checksum "..\..\..\AdvancedOptions\AdvancedOptions.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EA438F229FFCDEDD2A14984BFDA133DD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ShutdownTimer;
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


namespace ShutdownTimer {
    
    
    /// <summary>
    /// AdvancedOptions
    /// </summary>
    public partial class AdvancedOptions : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\AdvancedOptions\AdvancedOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox operationBox;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\AdvancedOptions\AdvancedOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox timespanBox;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\AdvancedOptions\AdvancedOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker startDate;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\AdvancedOptions\AdvancedOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker endDate;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\AdvancedOptions\AdvancedOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ExecutionTime;
        
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
            System.Uri resourceLocater = new System.Uri("/ShutdownTimer;component/advancedoptions/advancedoptions.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AdvancedOptions\AdvancedOptions.xaml"
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
            this.operationBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 38 "..\..\..\AdvancedOptions\AdvancedOptions.xaml"
            this.operationBox.Loaded += new System.Windows.RoutedEventHandler(this.Operation_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.timespanBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 62 "..\..\..\AdvancedOptions\AdvancedOptions.xaml"
            this.timespanBox.Loaded += new System.Windows.RoutedEventHandler(this.RunEvery_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.startDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.endDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.ExecutionTime = ((System.Windows.Controls.ComboBox)(target));
            
            #line 135 "..\..\..\AdvancedOptions\AdvancedOptions.xaml"
            this.ExecutionTime.Loaded += new System.Windows.RoutedEventHandler(this.ExecutionTime_Loaded);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 149 "..\..\..\AdvancedOptions\AdvancedOptions.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

