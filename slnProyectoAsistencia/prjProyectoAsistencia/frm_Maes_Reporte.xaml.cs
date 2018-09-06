using prjProyectoAsistencia.Common;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace prjProyectoAsistencia
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class frm_Maes_Reporte : Page
    {
        Database db;
        SQLiteConnection conn;
        public frm_Maes_Reporte()
        {
            this.InitializeComponent();
            db = new Database();
            conn = db.dbconn();
            loadData();

        }



        private void loadData()
        {
            var query = conn.Table<Atendance>();

            cmbMateria.ItemsSource = query;

            //var listaVenta = conn.Table<RelaStudentSubject>().
            //    Where(o => o.Subject.Equals(cmbMateria.SelectedItem));
            //lsvTomaAsistencia.ItemsSource = listaVenta;

            



        }

        private void dtpFecha_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            //dtpFecha.Date.ToString();
            //DateTime fechaActual = dtpFecha.Date.ToString();
            //DateTime fechaSelect = dtpFecha.SetValue() ;

            //if (dtpFecha.Equals(fechaActual) || DateTime.Compare(dtpFecha,fechaActual)>0)
            //{
            //    date = dtpFecha.ToString();
            //}
            //else
            //{
            //    var msg = new MessageDialog(" Fecha no Valida ");
            //    await msg.ShowAsync();
            //}
        }
    }
}
