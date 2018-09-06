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
    public sealed partial class frmCRUDRelacionAlumnoMateria : Page
    {

        Database db;
        SQLiteConnection conn;
        string alumno, materia, nombreAlumno, 
            apellidoAlumno, nombreCompletoAlumno, usuarioAlumno;
        int idRela, inAlu, inMat;
        Boolean marcaDeBusqueda;

        public frmCRUDRelacionAlumnoMateria()
        {
            this.InitializeComponent();
            db = new Database();
            conn = db.dbconn();
            loadData();
        }

        private async void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            var consultaRelaAlMat = conn.Table<RelaStudentSubject>();
            if (cmbMateria.SelectedIndex == -1 || cmbAlumno.SelectedIndex == -1)
            {
                var msg = new MessageDialog("Error, Complete los datos");
                await msg.ShowAsync();
            }
            else
            {
                buscarRepetido();
                if (marcaDeBusqueda==false)
                {
                    var msg = new MessageDialog("Error, La Relación ya existe");
                    await msg.ShowAsync();
                }
                else
                {
                    await addRelaAM();
                    loadData();
                }
                //foreach (RelaStudentSubject am in consultaRelaAlMat)
                //{

                //    if (am.Student.Equals(cmbAlumno.SelectedItem.ToString()) &&
                //    am.Subject.Equals(cmbMateria.SelectedItem.ToString()))
                //    {
                //        
                //        return;
                //    }
                //    else
                //    {
                //        await addRelaAM();
                //        loadData();
                //        return;
                //    }
                //}
            }
        }

        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            var consultaRelaAlMat = conn.Table<RelaStudentSubject>();
            if (cmbMateria.SelectedIndex == -1 || cmbAlumno.SelectedIndex == -1)
            {
                var msg = new MessageDialog("Error, Complete los datos");
                await msg.ShowAsync();
            }
            else
            {
                await modRelaAM();
                loadData();
                        
            }
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbMateria.SelectedIndex == -1 || cmbAlumno.SelectedIndex == -1)
            {
                var msg = new MessageDialog("Error, Complete los datos");
                await msg.ShowAsync();
            }
            else
            {
                await delRelaAM();
                loadData();
            }
        }

        private void lsvRelaAluMat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RelaStudentSubject selectedRel = (RelaStudentSubject)lsvRelaAluMat.SelectedItem;

            if (selectedRel != null)
            {
                idRela = selectedRel.IdRelaAlumSubj;
                cmbAlumno.SelectedIndex = inAlu;
                cmbMateria.SelectedIndex = inMat;

            }
        }

        private void cmbAlumno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var alu = (User)cmbAlumno.SelectedItem;

            if ((alu != null) && (alu.Type == 2))
            {
                nombreCompletoAlumno = alu.FirstName + alu.LastName;
                nombreAlumno = alu.FirstName;
                apellidoAlumno = alu.LastName;
                usuarioAlumno = alu.UserName;

                inAlu = cmbAlumno.SelectedIndex;
            }
        }

        private void cmbMateria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var mat = (Subject)cmbMateria.SelectedItem;

            if (mat != null)
            {
                materia = mat.Name;
                inMat = cmbMateria.SelectedIndex;
            }
        }


        private async void loadData()
        {
            var query = conn.Table<RelaStudentSubject>();

            lsvRelaAluMat.ItemsSource = query;


            var query2 = conn.Table<Subject>();
            cmbMateria.ItemsSource = query2;


            var filtroAlumno = conn.Table<User>().
                Where(f => f.Type == 2);

            foreach (User alu in filtroAlumno)
            {
                if (alu.Type.Equals(2))
                {
                    cmbAlumno.ItemsSource = filtroAlumno;
                }
                else
                {
                    var msg = new MessageDialog("No hay Alumnos Ingresados!!");
                    await msg.ShowAsync();
                }

            }
        }

        private async void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            cmbAlumno.SelectedIndex = -1;
            cmbMateria.SelectedIndex = -1;

            var msg = new MessageDialog("Formulario Limpio");
            await msg.ShowAsync();
        }

        private async System.Threading.Tasks.Task addRelaAM()
        {

            try
            {
                conn.Insert(new RelaStudentSubject()
                {
                    NameStudent = nombreAlumno,
                    LastNameStudent = apellidoAlumno,
                    UserStudent = usuarioAlumno,
                    CompleteNameStudent = nombreCompletoAlumno,
                    Subject = materia,
                    Atend = true
                });


                cmbAlumno.SelectedIndex = 0;
                cmbMateria.SelectedIndex = 0;


                var msg = new MessageDialog("Relación Ingresada Exitosamente!!");
                await msg.ShowAsync();
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog("Error");
                await msg.ShowAsync();
            }
        }


        private async System.Threading.Tasks.Task modRelaAM()
        {

            try
            {
                conn.Update(new RelaStudentSubject()
                {
                    IdRelaAlumSubj = idRela,
                    NameStudent = nombreAlumno,
                    LastNameStudent = apellidoAlumno,
                    UserStudent = usuarioAlumno,
                    CompleteNameStudent = nombreCompletoAlumno,
                    Subject = materia,
                    Atend = true
                });


                cmbAlumno.SelectedIndex = -1;
                cmbMateria.SelectedIndex = -1;


                var msg = new MessageDialog("Relación Modificada Exitosamente!!");
                await msg.ShowAsync();
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog("Error");
                await msg.ShowAsync();
            }
        }


        private async System.Threading.Tasks.Task delRelaAM()
        {

            try
            {
                conn.Delete(new RelaStudentSubject()
                {
                    IdRelaAlumSubj = idRela
                });


                cmbAlumno.SelectedIndex = -1;
                cmbMateria.SelectedIndex = -1;


                var msg = new MessageDialog("Relación Eliminada Exitosamente!!");
                await msg.ShowAsync();
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog("Error");
                await msg.ShowAsync();
            }
        }


        private void buscarRepetido()
        {
            var consultaRelaAlMat = conn.Table<RelaStudentSubject>();

            var consultaRelaAlMat1 = conn.Table<RelaStudentSubject>()
            .Count();
            //var consultaRelaMaeMaest = conn.Table<RelaMasterSubject>();
            //var consultaMateria = conn.Table<Subject>();
            //var consultaUsuario = conn.Table<User>();


            if (consultaRelaAlMat1>0)
            {
                foreach (RelaStudentSubject am in consultaRelaAlMat)
            {
                if (am.CompleteNameStudent.Equals(cmbAlumno.SelectedItem.ToString()) &&
                    am.Subject.Equals(cmbMateria.SelectedItem.ToString()))
                {
                    marcaDeBusqueda = false;
                    return;

                }
                else
                {
                    marcaDeBusqueda = true;
                }

            }
            }
            else
            {
                marcaDeBusqueda = true;
            }

            
        }

    }
}
