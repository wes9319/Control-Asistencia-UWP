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
    public sealed partial class frmCRUD_ADM_HorarioMaestro : Page
    {

        Database db;
        SQLiteConnection conn;
        string maestro, materia, nombreMaestro, apellidoMaestro, 
            usuarioMaestro, nombreCompletoMaestro;
        int idRela, inMae, inMat;
        TimeSpan time,timeEnd;
        Boolean marcaDeBusqueda;

        public frmCRUD_ADM_HorarioMaestro()
        {
            this.InitializeComponent();
            db = new Database();
            conn = db.dbconn();
            loadData();
        }

        private async void btnIngresar_Click(object sender, RoutedEventArgs e)
        {

            TimeSpan span = new TimeSpan(1, 0, 0);
            time = tpHora.Time;
            timeEnd = time.Add(span);

            var consultaHorario = conn.Table<Hours>();
            if (cmbRelaMM.SelectedIndex == -1)
            {
                var msg = new MessageDialog("Error, Complete los datos");
                await msg.ShowAsync();
            }
            else
            {
                buscarRepetido();
                if (marcaDeBusqueda ==false)
                {
                    var msg = new MessageDialog("Horario ya ingresado!!");
                    await msg.ShowAsync();
                }
                else
                {
                    await addHour();
                    loadData();
                }
                //foreach (Hours hour in consultaHorario)
                //{

                //    if (hour.Master.Equals(cmbRelaMM.SelectedItem.ToString()) && hour.Hour.Equals(tpHora.Time)
                //        && hour.EndHour.Equals(timeEnd))
                //    {
                //        var msg = new MessageDialog("Horario ya ingresado!!");
                //        await msg.ShowAsync();
                //        return;
                //    }
                //    else
                //    {
                //        await addHour();
                //        loadData();
                //        return;
                //    }
                //}
            }
        }

        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            

            var consultaHorario = conn.Table<Hours>();
            if (cmbRelaMM.SelectedIndex == -1)
            {
                var msg = new MessageDialog("Error, Complete los datos");
                await msg.ShowAsync();
            }
            else
            {
                
                        await modHour();
                        loadData();
                        
                    
                
            }
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbRelaMM.SelectedIndex == -1)
            {
                var msg = new MessageDialog("Error, Complete los datos");
                await msg.ShowAsync();
            }
            else
            {

                await delHour();

                loadData();
            }
            
        }

        private void lsvHorario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Hours selectedHour = (Hours)lsvHorario.SelectedItem;

            if (selectedHour != null)
            {
                idRela = selectedHour.IdHour;
                cmbRelaMM.SelectedIndex = inMae;

            }

        }

        private void cmbRelaMM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var rel = (RelaMasterSubject)cmbRelaMM.SelectedItem;

            if (rel != null)
            {
                
                nombreMaestro = rel.NameMaster;
                apellidoMaestro = rel.LastNameMaster;
                nombreCompletoMaestro = rel.CompleteName;
                usuarioMaestro = rel.UserMaster;
                materia = rel.Subject;
                inMae = cmbRelaMM.SelectedIndex;
            }
        }

        private void tpHora_TimeChanged(object sender, TimePickerValueChangedEventArgs e)
        {
            TimeSpan span = new TimeSpan(1,0,0);
            time = tpHora.Time;
            timeEnd = time.Add(span);

        }

        private async void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            cmbRelaMM.SelectedIndex = -1;

            var msg = new MessageDialog("Formulario Limpio");
            await msg.ShowAsync();
        }

        private async System.Threading.Tasks.Task addHour()
        {

            try
            {
                conn.Insert(new Hours()
                {
                    NameMaster = nombreMaestro,
                    LastNameMaster = apellidoMaestro,
                    CompleteNameMaster = nombreCompletoMaestro,
                    UserMaster = usuarioMaestro,
                    Subject = materia,
                    Hour = time,
                    EndHour = timeEnd
                   
                });


                cmbRelaMM.SelectedIndex = 0;


                var msg = new MessageDialog("Horario Ingresado Exitosamente!!");
                await msg.ShowAsync();
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog("Error");
                await msg.ShowAsync();
            }
        }

        private async System.Threading.Tasks.Task modHour()
        {

            try
            {
                conn.Update(new Hours()
                {
                    IdHour=idRela,
                    NameMaster = nombreMaestro,
                    LastNameMaster = apellidoMaestro,
                    CompleteNameMaster = nombreCompletoMaestro,
                    UserMaster = usuarioMaestro,
                    Subject = materia,
                    Hour = time,
                    EndHour = timeEnd
                });


                cmbRelaMM.SelectedIndex = 0;


                var msg = new MessageDialog("Horario Modificado Exitosamente!!");
                await msg.ShowAsync();
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog("Error");
                await msg.ShowAsync();
            }
        }



        private async System.Threading.Tasks.Task delHour()
        {

            try
            {
                conn.Delete(new Hours()
                {
                    IdHour = idRela
                });


                cmbRelaMM.SelectedIndex = 0;


                var msg = new MessageDialog("Horario Eliminado Exitosamente!!");
                await msg.ShowAsync();
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog("Error");
                await msg.ShowAsync();
            }
        }


        private void loadData()
        {
            var query = conn.Table<Hours>();

            lsvHorario.ItemsSource = query;


            var query2 = conn.Table<RelaMasterSubject>();
            cmbRelaMM.ItemsSource = query2;

        }

        private void buscarRepetido()
        {
            TimeSpan span = new TimeSpan(1, 0, 0);
            time = tpHora.Time;
            timeEnd = time.Add(span);

            var consultaHorario = conn.Table<Hours>();

            var consultaHorario1 = conn.Table<Hours>()
            .Count();
            //var consultaRelaAlMat = conn.Table<RelaStudentSubject>();
            //var consultaRelaMaeMaest = conn.Table<RelaMasterSubject>();
            //var consultaMateria = conn.Table<Subject>();
            //var consultaUsuario = conn.Table<User>();

            if (consultaHorario1>0)
            {
                foreach (Hours hour in consultaHorario)
            {
                if (hour.CompleteNameMaster.Equals(cmbRelaMM.SelectedItem.ToString()) && hour.Hour.Equals(tpHora.Time)
                        && hour.EndHour.Equals(timeEnd))
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
