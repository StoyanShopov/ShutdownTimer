﻿#pragma checksum "..\..\..\Settings\ScheduleTask.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FF6AC4FBE9346A84B13F39D12E724D3A063FCC9E"
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
    /// ScheduleTask
    /// </summary>
    public partial class ScheduleTask : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\Settings\ScheduleTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox operationBox;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Settings\ScheduleTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox timespanBox;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Settings\ScheduleTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker startDate;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\Settings\ScheduleTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker endDate;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\Settings\ScheduleTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ExecutionTime;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\Settings\ScheduleTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox taskName;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\Settings\ScheduleTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button;
        
        #line default
        #line hidden
        
        
        #line 195 "..\..\..\Settings\ScheduleTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbFiles;
        
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
            System.Uri resourceLocater = new System.Uri("/ShutdownTimer;component/settings/scheduletask.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Settings\ScheduleTask.xaml"
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
            
            #line 38 "..\..\..\Settings\ScheduleTask.xaml"
            this.operationBox.Loaded += new System.Windows.RoutedEventHandler(this.Operation_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.timespanBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 62 "..\..\..\Settings\ScheduleTask.xaml"
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
            
            #line 135 "..\..\..\Settings\ScheduleTask.xaml"
            this.ExecutionTime.Loaded += new System.Windows.RoutedEventHandler(this.ExecutionTime_Loaded);
            
            #line default
            #line hidden
            return;
            case 6:
            this.taskName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.button = ((System.Windows.Controls.Button)(target));
            
            #line 169 "..\..\..\Settings\ScheduleTask.xaml"
            this.button.Click += new System.Windows.RoutedEventHandler(this.Button_Create);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 181 "..\..\..\Settings\ScheduleTask.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Back);
            
            #line default
            #line hidden
            return;
            case 9:
            this.lbFiles = ((System.Windows.Controls.ListBox)(target));
            return;
            case 10:
            
            #line 213 "..\..\..\Settings\ScheduleTask.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Delete);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
