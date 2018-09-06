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
    public sealed partial class frmCRUDMateria : Page
    {
        Database db;
        SQLiteConnection conn;
        Boolean marcaDeBusqueda;
        int IdMat;
        public frmCRUDMateria()
        {
            this.InitializeComponent();
            db = new Database();
            conn = db.dbconn();
            loadData();
        }

        private async void btnIngreso_Click(object sender, RoutedEventArgs e)
        {
            //var consultaMateria = conn.Table<Subject>();
            if (txtNombre.Text == "" || txtSigla.Text == "" || txtClase.Text == "")
            {
                var msg = new MessageDialog("Error, Complete los datos");
                await msg.ShowAsync();

            }
            else
            {
                buscarRepetido();

                if (marcaDeBusqueda == false)
                {
                    var msg = new MessageDialog("Error, La Materia ya existe");
                    await msg.ShowAsync();
                }
                else
                {
                    await addSubj();
                    loadData();
                }
                //foreach (Subject sub in consultaMateria)
                //{

                //    if (sub.Name.Equals(txtNombre.Text) && sub.Code.Equals(txtSigla.Text)
                //    && sub.Room.Equals(txtClase.Text))
                //    {
                //        var msg = new MessageDialog("Error, La Materia ya existe");
                //        await msg.ShowAsync();
                //        return;
                //    }
                //    else
                //    {
                //        await addSubj();
                //        loadData();
                //        return;
                //    }
                //}
            }
        }

        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            
            var consultaMateria = conn.Table<Subject>();
            if (txtNombre.Text == "" || txtSigla.Text == "" || txtClase.Text == "")
            {
                var msg = new MessageDialog("Error, Complete los datos");
                await msg.ShowAsync();

            }
            else
            {
                await modSubj();
                loadData();
                return;
            }
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == "" || txtSigla.Text == "" || txtClase.Text == "")
            {
                var msg = new MessageDialog("Error, Complete los datos");
                await msg.ShowAsync();
                return;
            }
            else
            {
                await delSubj();
                loadData();
                return;
            }
        }


        private async System.Threading.Tasks.Task addSubj()
        {
            string nombre,sigla,clase;
            try
            {
                nombre = txtNombre.Text;
                sigla = txtSigla.Text;
                clase = txtClase.Text;

                conn.Insert(new Subject()
                {
                    Name = nombre,
                    Code = sigla,
                    Room = clase
                });

                txtNombre.Text = "";
                txtSigla.Text = "";
                txtClase.Text = "";
                txtBuscar.Text = "";


                var msg = new MessageDialog("Materia Ingresada Exitosamente!!");
                await msg.ShowAsync();
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog("Error");
                await msg.ShowAsync();
            }
        }

        private async System.Threading.Tasks.Task modSubj()
        {
            string nombre, sigla, clase;
            try
            {
                nombre = txtNombre.Text;
                sigla = txtSigla.Text;
                clase = txtClase.Text;

                conn.Update(new Subject()
                {
                    IdSubject = IdMat,
                    Name = nombre,
                    Code = sigla,
                    Room = clase
                });

                txtNombre.Text = "";
                txtSigla.Text = "";
                txtClase.Text = "";
                txtBuscar.Text = "";

                var msg = new MessageDialog("Materia Modificada Exitosamente!!");
                await msg.ShowAsync();
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog("Error");
                await msg.ShowAsync();
            }
        }
        
        private async System.Threading.Tasks.Task delSubj()
        {
            //string sigla;
            try
            {
                
                //sigla = txtSigla.Text;
               

                conn.Delete(new Subject()
                {
                    IdSubject = IdMat
                    //Code = sigla
                    
                });

                txtNombre.Text = "";
                txtSigla.Text = "";
                txtClase.Text = "";
                txtBuscar.Text = "";

                var msg = new MessageDialog("Materia Eliminada Exitosamente!!");
                await msg.ShowAsync();
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog("Error");
                await msg.ShowAsync();
            }
        }

        private async void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            var consultaMateria = conn.Table<Subject>();

            foreach (Subject sub in consultaMateria)
            {
                if (sub.Code.Equals(txtBuscar.Text))
                {
                    txtNombre.Text = sub.Name;
                    txtSigla.Text = sub.Code;
                    txtClase.Text = sub.Room;

                    marcaDeBusqueda = false;
                }
                else
                {
                    marcaDeBusqueda = true;
                }

            }

            if ( marcaDeBusqueda== false)
            {
                var msg = new MessageDialog("Materia encontrada !!");
                await msg.ShowAsync();
            }
            else
            {
                var msg = new MessageDialog("Materia NO encontrada !!");
                await msg.ShowAsync();
            }

        }

        private void loadData()
        {
            var query = conn.Table<Subject>();


            lsvMateria.ItemsSource = query;

            txtNombre.Text = "";
            txtSigla.Text = "";
            txtClase.Text = "";
            txtBuscar.Text = "";
        }

        private void lsvMateria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedSubj = (Subject)lsvMateria.SelectedItem;

            if (selectedSubj != null)
            {
                IdMat = selectedSubj.IdSubject;
                txtNombre.Text = selectedSubj.Name;
                txtSigla.Text = selectedSubj.Code;
                txtClase.Text = selectedSubj.Room;
            }
        }

        private async void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = "";
            txtSigla.Text = "";
            txtClase.Text = "";
            txtBuscar.Text = "";

            var msg = new MessageDialog("Formulario Limpio");
            await msg.ShowAsync();
        }


        private  void buscarRepetido()
        {
            var consultaMateria1 = conn.Table<Subject>()
                .Count();

            var consultaMateria = conn.Table<Subject>();
            //.Sum(o => o.Price * o.Quantity); ;
            //var consultaUsuario = conn.Table<User>();
            //var Subj = (Subject);

            if (consultaMateria1 > 0)
            {
                foreach (Subject sub in consultaMateria)
            {
                
                    if (sub.Name.Equals(txtNombre.Text) && sub.Code.Equals(txtSigla.Text)
                    && sub.Room.Equals(txtClase.Text))
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
