﻿#pragma checksum "C:\Users\Wesley\Documents\Visual Studio 2015\Projects\slnProyectoAsistencia\prjProyectoAsistencia\frm_AMD_Reporte.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DF58D5179C2B95F2A9A1733A449D9102"
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
    partial class frm_AMD_Reporte : 
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
                    this.btnGenerar = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 28 "..\..\..\frm_AMD_Reporte.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnGenerar).Click += this.btnGenerar_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.lsvUsuarios = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 4:
                {
                    this.lsvMateria = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 5:
                {
                    this.lsvMaestroMateria = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 6:
                {
                    this.txbUsuarios = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.txbMaterias = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    this.txbRelaMaesMat = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9:
                {
                    this.lsvAlumnoMateria = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 10:
                {
                    this.lsvHorarioMaestro = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 11:
                {
                    this.txbRelaAlumMater = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12:
                {
                    this.txbHorario = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

