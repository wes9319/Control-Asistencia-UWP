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
    public sealed partial class frm_AMD_Reporte : Page
    {

        Database db;
        SQLiteConnection conn;

        public frm_AMD_Reporte()
        {
            this.InitializeComponent();
            db = new Database();
            conn = db.dbconn();
        }

        private void btnGenerar_Click(object sender, RoutedEventArgs e)
        {
            var usuarios = conn.Table<User>();
            lsvUsuarios.ItemsSource = usuarios;

            var materias = conn.Table<Subject>();
            lsvMateria.ItemsSource = materias;

            var maestroMateria = conn.Table<RelaMasterSubject>();
            lsvMaestroMateria.ItemsSource = maestroMateria;

            var alumnoMateria = conn.Table<RelaStudentSubject>();
            lsvAlumnoMateria.ItemsSource = alumnoMateria;

            var horario = conn.Table<Hours>();
            lsvHorarioMaestro.ItemsSource = horario;

        }
    }
}
