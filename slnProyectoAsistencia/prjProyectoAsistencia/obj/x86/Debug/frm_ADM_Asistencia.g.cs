﻿#pragma checksum "C:\Users\Wesley\Documents\Visual Studio 2015\Projects\slnProyectoAsistencia\prjProyectoAsistencia\frm_ADM_Asistencia.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F7BA229FCCFF1E79563A18E7A7240957"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace prjProyectoAsistencia
{
    partial class frm_ADM_Asistencia : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.txbTitulo = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 2:
                {
                    this.txbMateria = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.cmbMateria = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 4:
                {
                    this.lsvAsistencia = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 28 "..\..\..\frm_ADM_Asistencia.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.lsvAsistencia).SelectionChanged += this.lsvAsistencia_SelectionChanged;
                    #line default
                }
                break;
            case 5:
                {
                    this.txbRecuperacion = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

