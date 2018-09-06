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
    public sealed partial class frmCRUDRelacionMaestroMateria : Page
    {
        Database db;
        SQLiteConnection conn;
        string nombreMaestro, apellidoMaestro, 
            usuarioMaestro, materia, nombreCompleroMaestro;
        int idRela, inMae, inMat;
        Boolean marcaDeBusqueda;

        public frmCRUDRelacionMaestroMateria()
        {
            this.InitializeComponent();
            db = new Database();
            conn = db.dbconn();
            loadData();
        }

        private async void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            var consultaRelaMaeMaest = conn.Table<RelaMasterSubject>();
            if (cmbMaestro.SelectedIndex == -1 || cmbMateria.SelectedIndex == -1)
            {
                var msg = new MessageDialog("Error, Complete los datos");
                await msg.ShowAsync();
            }
            else
            {

                buscarRepetido();
                if (marcaDeBusqueda == false)
                {
                    var msg = new MessageDialog("Error, La Relación ya existe");
                    await msg.ShowAsync();
                }
                else
                {
                    await addRelaMM();
                    loadData();
                }
                //foreach (RelaMasterSubject mm in consultaRelaMaeMaest)
                //{

                //    if (mm.Master.Equals(cmbMaestro.SelectedItem.ToString())
                //    && mm.Subject.Equals(cmbMateria.SelectedItem.ToString()))
                //    {
                //        var msg = new MessageDialog("Error, La Relación ya existe");
                //        await msg.ShowAsync();
                //        return;
                //    }
                //    else
                //    {
                //        await addRelaMM();
                //        loadData();
                //        return;
                //    }

                //}
            }

        }

        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbMaestro.SelectedIndex == -1 || cmbMateria.SelectedIndex == -1)
            {
                var msg = new MessageDialog("Error, Complete los datos");
                await msg.ShowAsync();
            }
            else
            {
                await modRelaMM();
                loadData();
            }
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbMaestro.SelectedIndex == -1 || cmbMateria.SelectedIndex == -1)
            {
                var msg = new MessageDialog("Error, Complete los datos");
                await msg.ShowAsync();
            }
            else
            {
                await delRelaMM();
                loadData();
            }
        }

        private void lsvMaestMater_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RelaMasterSubject selectedRel = (RelaMasterSubject)lsvMaestMater.SelectedItem;

            if (selectedRel != null)
            {
                idRela = selectedRel.IdRelaMastSubj;
                cmbMaestro.SelectedIndex = inMae;
                cmbMateria.SelectedIndex = inMat;
            }
        }

        private async System.Threading.Tasks.Task addRelaMM()
        {
            try
            {
                conn.Insert(new RelaMasterSubject()
                {
                    NameMaster = nombreMaestro,
                    LastNameMaster = apellidoMaestro,
                    UserMaster = usuarioMaestro,
                    CompleteName = nombreCompleroMaestro,
                    Subject = materia
                });

                
                cmbMaestro.SelectedIndex = -1;
                cmbMateria.SelectedIndex = -1;


                var msg = new MessageDialog("Relación Ingresada Exitosamente!!");
                await msg.ShowAsync();
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog("Error");
                await msg.ShowAsync();
            }
        }


        private async System.Threading.Tasks.Task modRelaMM()
        {

            try
            {
                conn.Update(new RelaMasterSubject()
                {
                    IdRelaMastSubj = idRela,
                    NameMaster = nombreMaestro,
                    LastNameMaster = apellidoMaestro,
                    UserMaster = usuarioMaestro,
                    CompleteName = nombreCompleroMaestro,
                    Subject = materia
                });


                cmbMaestro.SelectedIndex = -1;
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


        private async System.Threading.Tasks.Task delRelaMM()
        {

            try
            {
                conn.Delete(new RelaMasterSubject()
                {
                    IdRelaMastSubj = idRela
                });


                cmbMaestro.SelectedIndex = -1;
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

        private async void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            cmbMaestro.SelectedIndex = -1;
            cmbMateria.SelectedIndex = -1;

            var msg = new MessageDialog("Formulario Limpio");
            await msg.ShowAsync();
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

        private void cmbMaestro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var mae = (User)cmbMaestro.SelectedItem;

            if ((mae != null) && (mae.Type==1))
            {
                nombreMaestro = mae.FirstName;
                apellidoMaestro = mae.LastName;
                usuarioMaestro = mae.UserName;
                nombreCompleroMaestro = mae.FirstName + mae.LastName;
                inMae = cmbMaestro.SelectedIndex;
            }
        }

        private async void loadData()
        {
            var query = conn.Table<RelaMasterSubject>();

            lsvMaestMater.ItemsSource = query;
            

            var query2 = conn.Table<Subject>();
            cmbMateria.ItemsSource = query2;


            var filtroMaestro = conn.Table<User>().
                Where(f => f.Type==1);

            foreach (User maes in filtroMaestro)
            {
                if (maes.Type.Equals(1))
                {
                    cmbMaestro.ItemsSource = filtroMaestro;
                }
                else
                {
                    var msg = new MessageDialog("No hay Maestros Ingresados!!");
                    await msg.ShowAsync();
                }
            }
        }

        private void buscarRepetido()
        {
            var consultaRelaMaeMaest = conn.Table<RelaMasterSubject>();
            var consultaRelaMaeMaest1 = conn.Table<RelaMasterSubject>()
            .Count();
            //var consultaMateria = conn.Table<Subject>();
            //var consultaUsuario = conn.Table<User>();

            if (consultaRelaMaeMaest1 > 0)
            {
                foreach (RelaMasterSubject mm in consultaRelaMaeMaest)
            {
                if (mm.CompleteName.Equals(cmbMaestro.SelectedItem.ToString())
                    && mm.Subject.Equals(cmbMateria.SelectedItem.ToString()))
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
