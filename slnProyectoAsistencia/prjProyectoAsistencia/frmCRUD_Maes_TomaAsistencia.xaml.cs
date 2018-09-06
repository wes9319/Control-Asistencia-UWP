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
    public sealed partial class frmCRUD_Maes_TomaAsistencia : Page
    {

        Database db;
        SQLiteConnection conn;
        string maestro, materia, NombreAlumno, 
            ApellidoAlumno, NombreMaestro, 
            ApellidoMaestro;
        Boolean asistencia;
        int idRela, inMae, inMat;
        TimeSpan time, timeEnd;
        //string date;


        public frmCRUD_Maes_TomaAsistencia()
        {
            this.InitializeComponent();
            db = new Database();
            conn = db.dbconn();
            loadData();
            

        }

        private async void btnIngreso_Click(object sender, RoutedEventArgs e)
        {
            await addAtend();

            loadData();
        }

        private void chkAsistencia_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private async System.Threading.Tasks.Task addAtend()
        {

            try
            {
                conn.Insert(new Atendance()
                {
                    Date = DateTime.Now,
                    Time = time,
                    EndTime = timeEnd,
                    Subject = materia,
                    FirstNameStudent = NombreAlumno,
                    LastNameStudent = ApellidoAlumno,
                    FistNameMaster = NombreMaestro,
                    LastNameMaster = ApellidoMaestro,
                    Asist = true
                    
                });


                //cmbRelaMM.SelectedIndex = 0;


                var msg = new MessageDialog(" Ingresado Exitosamente!!");
                await msg.ShowAsync();
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog("Error");
                await msg.ShowAsync();
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private  void dtpFecha_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            //if (dtpFecha.Equals(fechaActual))
            //{
            //    date = dtpFecha.ToString();
            //}
            //else
            //{
            //    var msg = new MessageDialog(" Fecha no Valida ");
            //    await msg.ShowAsync();
            //}
        }

        private void tpHora_TimeChanged(object sender, TimePickerValueChangedEventArgs e)
        {
            TimeSpan span = new TimeSpan(1, 0, 0);
            time = tpHora.Time;
            timeEnd = time.Add(span);
        }

        private async void cmbMateria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var mat = (Subject)cmbMateria.SelectedItem;

           

            if (mat != null)
            {
                materia = mat.Name;
                inMat = cmbMateria.SelectedIndex;
            }

            var filtroAlumno = conn.Table<RelaStudentSubject>().
            Where(o => o.Subject.Equals(materia));

            var filtroMaestro = conn.Table<RelaMasterSubject>().
            Where(o => o.Subject.Equals(materia));

            foreach (RelaStudentSubject al in filtroAlumno)
            {
                if (al.Subject.Equals(materia))
                {
                    foreach (RelaMasterSubject mae in filtroMaestro)
                    {
                        if (mae.Subject.Equals(materia))
                        {
                            NombreAlumno = al.NameStudent;
                            ApellidoAlumno = al.LastNameStudent;
                            NombreMaestro = mae.NameMaster;
                            ApellidoMaestro = mae.LastNameMaster;

                        }
                    }
                }

            }

            


            try
            {

                lsvTomaAsistencia.ItemsSource = filtroAlumno;
                
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog("No hay alumnos inscritos en la Materia!!");
                await msg.ShowAsync();
            }


            //foreach (RelaStudentSubject maes in filtroMaestro)
            //{
            //    if (maes.Subject.Equals(cmbMateria.SelectedItem))
            //    {
            //        var msg = new MessageDialog("Entro!!");
            //        await msg.ShowAsync();
            //        
            //    }
            //    else
            //    {
            //        var msg = new MessageDialog("No hay alumnos inscritos!!");
            //        await msg.ShowAsync();
            //    }

            //}

            //var listaAsistencia = conn.Table<RelaStudentSubject>().
            //    Where(a => a.Subject.Equals(cmbMateria.SelectedItem));
            //lsvTomaAsistencia.ItemsSource = listaAsistencia;


            //var query2 = conn.Table<RelaStudentSubject>().
            //    Where(f => f.Subject.Equals(cmbMateria.SelectedItem));

            ////var filtroAlumno = conn.Table<RelaStudentSubject>().
            //    //;

            //lsvTomaAsistencia.ItemsSource = query2;

            //foreach (RelaStudentSubject alu in filtroAlumno)
            //{
            //    if (alu.Subject.Equals(cmbMateria.SelectedItem))
            //    {
            //        
            //    }
            //    else
            //    {
            //        var msg = new MessageDialog("No hay Alumnos Registrados en la Materia!!");

            //        await msg.ShowAsync();
            //    }

            //}


        }

        private void lsvTomaAsistencia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }


        private void loadData()
        {
            var query = conn.Table<Atendance>();

            lsvTomaAsistencia.ItemsSource = query;

            //var listaVenta = conn.Table<RelaStudentSubject>().
            //    Where(o => o.Subject.Equals(cmbMateria.SelectedItem));
            //lsvTomaAsistencia.ItemsSource = listaVenta;

            var query2 = conn.Table<Subject>();
            cmbMateria.ItemsSource = query2;

            

        }
    }
}
