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
    public sealed partial class frm_Alum_Asistencia : Page
    {

        Database db;
        SQLiteConnection conn;
        string materia;
        Boolean marcaAsist;
        int countFaltas, recuperacion;

        public frm_Alum_Asistencia()
        {
            this.InitializeComponent();
            db = new Database();
            conn = db.dbconn();
        }

        private void txbTitulo_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }


        private void loadData()
        {
            //var query = conn.Table<Hours>();

            //lsvHorario.ItemsSource = query;


            var query2 = conn.Table<Atendance>();
            cmbMateria.ItemsSource = query2;

        }

        private void cmbMateria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var query2 = conn.Table<Subject>();
            cmbMateria.ItemsSource = query2;
        }

        private void lsvAsistencia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedAsis = (Subject)lsvAsistencia.SelectedItem;

            if (selectedAsis != null)
            {
                materia = selectedAsis.Name;
            }

            var asistencia = conn.Table<Atendance>();

            var asistencia1 = conn.Table<Atendance>()
                .Where(o => o.Subject.Equals(materia))
                .Count();

            foreach (Atendance at in asistencia)
            {
                if (at.Subject.Equals(materia))
                {
                    marcaAsist = at.Asist;
                    if (marcaAsist == false)
                    {
                        countFaltas++;
                    }
                }
            }

            recuperacion = ((countFaltas * 100) / asistencia1);

            if (recuperacion >= 80)
            {
                txbRecuperacion.Text = "Si puede dar examen de recuperación";
            }
            else
            {
                txbRecuperacion.Text = "No puede dar examen de recuperación";
            }
        }
    }
}
