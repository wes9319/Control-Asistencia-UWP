using prjProyectoAsistencia.Common;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class frm_Alum_Consulta : Page
    {
        Database db;
        SQLiteConnection conn;

        public frm_Alum_Consulta()
        {
            this.InitializeComponent();
            db = new Database();
            conn = db.dbconn();
        }


        private void loadData()
        {
            var query = conn.Table<Atendance>();

            lsvSeleccionar.ItemsSource = query;

            var query2 = conn.Table<Atendance>();

            lsvFaltas.ItemsSource = query2;




        }
    }
}
