﻿#pragma checksum "..\..\EditSP.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EF349E98F8353EEBA917025DDB6390F614069F3E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DA_LTUD;
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


namespace DA_LTUD {
    
    
    /// <summary>
    /// EditSP
    /// </summary>
    public partial class EditSP : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\EditSP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btapply;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\EditSP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btedit;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\EditSP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btdelete;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\EditSP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stpShow;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\EditSP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblnameprd;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\EditSP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblGiaprd;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\EditSP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stpEdit;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\EditSP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbnameprd;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\EditSP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbgiaprd;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\EditSP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btchoosefile;
        
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
            System.Uri resourceLocater = new System.Uri("/DA_LTUD;component/editsp.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditSP.xaml"
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
            
            #line 8 "..\..\EditSP.xaml"
            ((DA_LTUD.EditSP)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btapply = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\EditSP.xaml"
            this.btapply.Click += new System.Windows.RoutedEventHandler(this.btapply_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btedit = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\EditSP.xaml"
            this.btedit.Click += new System.Windows.RoutedEventHandler(this.btedit_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btdelete = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\EditSP.xaml"
            this.btdelete.Click += new System.Windows.RoutedEventHandler(this.btdelete_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.stpShow = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.tblnameprd = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.tblGiaprd = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.stpEdit = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 9:
            this.tbnameprd = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.tbgiaprd = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.btchoosefile = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\EditSP.xaml"
            this.btchoosefile.Click += new System.Windows.RoutedEventHandler(this.btchoosefile_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

