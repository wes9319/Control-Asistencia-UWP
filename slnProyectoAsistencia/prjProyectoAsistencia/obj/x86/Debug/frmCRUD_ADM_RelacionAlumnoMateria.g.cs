﻿#pragma checksum "C:\Users\Wesley\Documents\Visual Studio 2015\Projects\slnProyectoAsistencia\prjProyectoAsistencia\frmCRUD_ADM_RelacionAlumnoMateria.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "91BF33C0255207547210C7DD9BE4BDDC"
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
    partial class frmCRUDRelacionAlumnoMateria : 
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
                    this.txbAlumno = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.txbMateria = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4:
                {
                    this.cmbAlumno = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    #line 31 "..\..\..\frmCRUD_ADM_RelacionAlumnoMateria.xaml"
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.cmbAlumno).SelectionChanged += this.cmbAlumno_SelectionChanged;
                    #line default
                }
                break;
            case 5:
                {
                    this.cmbMateria = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    #line 41 "..\..\..\frmCRUD_ADM_RelacionAlumnoMateria.xaml"
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.cmbMateria).SelectionChanged += this.cmbMateria_SelectionChanged;
                    #line default
                }
                break;
            case 6:
                {
                    this.btnIngresar = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 48 "..\..\..\frmCRUD_ADM_RelacionAlumnoMateria.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnIngresar).Click += this.btnIngresar_Click;
                    #line default
                }
                break;
            case 7:
                {
                    this.btnModificar = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 49 "..\..\..\frmCRUD_ADM_RelacionAlumnoMateria.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnModificar).Click += this.btnModificar_Click;
                    #line default
                }
                break;
            case 8:
                {
                    this.btnEliminar = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 50 "..\..\..\frmCRUD_ADM_RelacionAlumnoMateria.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnEliminar).Click += this.btnEliminar_Click;
                    #line default
                }
                break;
            case 9:
                {
                    this.lsvRelaAluMat = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 51 "..\..\..\frmCRUD_ADM_RelacionAlumnoMateria.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.lsvRelaAluMat).SelectionChanged += this.lsvRelaAluMat_SelectionChanged;
                    #line default
                }
                break;
            case 10:
                {
                    this.btnLimpiar = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 63 "..\..\..\frmCRUD_ADM_RelacionAlumnoMateria.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnLimpiar).Click += this.btnLimpiar_Click;
                    #line default
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

