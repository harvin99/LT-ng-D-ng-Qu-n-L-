﻿#pragma checksum "..\..\NhapHD.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "281D533862DAB58141B8480A39CDED1884C51666"
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
    /// NhapHD
    /// </summary>
    public partial class NhapHD : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 12 "..\..\NhapHD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btadd;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\NhapHD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btcancel;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\NhapHD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbtenkh;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\NhapHD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbdiachi;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\NhapHD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbsdt;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\NhapHD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tblngaydat;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\NhapHD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbltinhtrang;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\NhapHD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbfilterproduct;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\NhapHD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagridsp;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\NhapHD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbltongtienhoadon;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\NhapHD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagridgihang;
        
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
            System.Uri resourceLocater = new System.Uri("/DA_LTUD;component/nhaphd.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NhapHD.xaml"
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
            
            #line 8 "..\..\NhapHD.xaml"
            ((DA_LTUD.NhapHD)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btadd = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\NhapHD.xaml"
            this.btadd.Click += new System.Windows.RoutedEventHandler(this.btadd_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btcancel = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\NhapHD.xaml"
            this.btcancel.Click += new System.Windows.RoutedEventHandler(this.btcancel_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbtenkh = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbdiachi = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tbsdt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.tblngaydat = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.tbltinhtrang = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.tbfilterproduct = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\NhapHD.xaml"
            this.tbfilterproduct.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbfilterproduct_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.datagridsp = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 12:
            this.tbltongtienhoadon = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            this.datagridgihang = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 11:
            
            #line 47 "..\..\NhapHD.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.add_Click);
            
            #line default
            #line hidden
            break;
            case 14:
            
            #line 69 "..\..\NhapHD.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbSL_TextChanged);
            
            #line default
            #line hidden
            break;
            case 15:
            
            #line 77 "..\..\NhapHD.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btndeleteCT_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

