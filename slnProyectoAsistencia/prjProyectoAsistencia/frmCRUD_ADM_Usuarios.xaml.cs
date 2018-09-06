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
    public sealed partial class frmCRUDUsuarios : Page
    {
        Database db;
        SQLiteConnection conn;
        int rol;
        Boolean marcaDeBusqueda;
        public frmCRUDUsuarios()
        {
            this.InitializeComponent();
            db = new Database();
            conn = db.dbconn();
            loadData();
        }

        private async void btnIngresar_Click(object sender, RoutedEventArgs e)
        {

            var consultaUsuario = conn.Table<User>();

            if (txtNombre.Text == "" || txtApellido.Text == "" || txtMail.Text == "" || txtUsuario.Text == "" ||
                        txtClave.Text == "" || txtTitulo.Text == "")
            {

                var msg = new MessageDialog("Error, Complete los datos");
                await msg.ShowAsync();

            }
            else
            {
                buscarRepetido();
                if (marcaDeBusqueda == false)
                {
                    var msg = new MessageDialog("Error, El Usuario ya existe!!");
                    await msg.ShowAsync();
                }
                else
                {
                    await addUser();
                    loadData();
                }
                //foreach (User user in consultaUsuario)
                //{

                //    if (user.UserName.Equals(txtUsuario.Text))
                //    {
                //        var msg = new MessageDialog("Error, El Usuario ya existe!!");
                //        await msg.ShowAsync();
                //        break;
                //    }
                //    else
                //    {
                //        await addUser();
                //        loadData();
                //        break;
                //    }
                //}
            }
        }

        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            var consultaUsuario = conn.Table<User>();
            if (txtNombre.Text == "" || txtApellido.Text == "" || txtMail.Text == "" || txtUsuario.Text == "" ||
                        txtClave.Text == "" || txtTitulo.Text == "")
            {

                var msg = new MessageDialog("Error, Complete los datos");
                await msg.ShowAsync();

            }
            else
            {
                        await modUser();
                        loadData();
                        return;
            }
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

            if (txtNombre.Text == "" || txtApellido.Text == "" || txtMail.Text == "" || txtUsuario.Text =="" ||
                txtClave.Text == "" || txtTitulo.Text == "" )
            {
                var msg = new MessageDialog("Error, Complete los datos");
                await msg.ShowAsync();
                return;
            }
            else
            {
                await delUser();
                loadData();
                return;
            }
            
        }

        private async System.Threading.Tasks.Task addUser()
        {
            string nombre,apellido,mail,
                usuario,contrasena,titulo;
            try
            {
                nombre = txtNombre.Text;
                apellido = txtApellido.Text;
                mail = txtMail.Text;
                usuario = txtUsuario.Text;
                contrasena = txtClave.Text;
                titulo = txtTitulo.Text;

                conn.Insert(new User()
                {
                    FirstName = nombre,
                    LastName = apellido,
                    Email = mail,
                    UserName = usuario,
                    Password = contrasena,
                    Type = rol,
                    Title = titulo
                });
                
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtMail.Text = "";
                txtUsuario.Text = "";
                txtClave.Text = "";
                cmbTipo.SelectedIndex= -1;
                txtTitulo.Text = "";
                txtBuscar.Text = "";

                var msg = new MessageDialog("Usuario Ingresado Exitosamente!!");
                await msg.ShowAsync();
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog("Error");
                await msg.ShowAsync();
            }
        }

        private async System.Threading.Tasks.Task modUser()
        {
            string nombre, apellido, mail,
                usuario, contrasena, titulo;
            try
            {
                nombre = txtNombre.Text;
                apellido = txtApellido.Text;
                mail = txtMail.Text;
                usuario = txtUsuario.Text;
                contrasena = txtClave.Text;
                titulo = txtTitulo.Text;

                conn.Update(new User()
                {
                    FirstName = nombre,
                    LastName = apellido,
                    Email = mail,
                    UserName = usuario,
                    Password = contrasena,
                    Type = rol,
                    Title = titulo

                });

                txtNombre.Text = "";
                txtApellido.Text = "";
                txtMail.Text = "";
                txtUsuario.Text = "";
                txtClave.Text = "";
                cmbTipo.SelectedIndex = -1;
                txtTitulo.Text = "";
                txtBuscar.Text = "";

                var msg = new MessageDialog("Usuario Modificado Exitosamente!!");
                await msg.ShowAsync();
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog("Error");
                await msg.ShowAsync();
            }
        }

        private async System.Threading.Tasks.Task delUser()
        {
            string usuario;
            try
            {
                usuario = txtUsuario.Text;

                conn.Delete(new User()
                {
                    UserName = usuario
                    
                });

                txtNombre.Text = "";
                txtApellido.Text = "";
                txtMail.Text = "";
                txtUsuario.Text = "";
                txtClave.Text = "";
                cmbTipo.SelectedIndex = -1;
                txtTitulo.Text = "";
                txtBuscar.Text = "";

                var msg = new MessageDialog("Usuario Eliminado Exitosamente!!");
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
            var query = conn.Table<User>();


            lsvUsuarios.ItemsSource = query;

            txtNombre.Text = "";
            txtApellido.Text = "";
            txtMail.Text = "";
            txtUsuario.Text = "";
            txtClave.Text = "";
            cmbTipo.SelectedIndex = -1;
            txtTitulo.Text = "";
            txtBuscar.Text = "";
        }

        private void buscarRepetido()
        {
            var consultaUsuario = conn.Table<User>();

            foreach (User user in consultaUsuario)
            {
                if (user.UserName.Equals(txtUsuario.Text))
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

        private void cmbTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //var tipo = (User)cmbTipo.SelectedItem;

            //if (tipo != null)
            //{
            //    rol = tipo.Type;
            //}
            

            if (cmbTipo.SelectedIndex == 0)
            {
                txtTitulo.IsEnabled = false;
                txtTitulo.Text = "";
                txtTitulo.Text = "Administrador";
                rol = 0;
            }
            else
            {
                if (cmbTipo.SelectedIndex == 1)
                {
                    txtTitulo.IsEnabled = true;
                    txtTitulo.Text = "";
                    rol = 1;
                }
                else
                {
                    if (cmbTipo.SelectedIndex == 2)
                    {
                        txtTitulo.IsEnabled = false;
                        txtTitulo.Text = "";
                        txtTitulo.Text = "Alumno";
                        rol = 2;
                    }
                }
            }
        }

        private void lsvUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedUser = (User)lsvUsuarios.SelectedItem;

            if (selectedUser != null)
            {
                txtNombre.Text = selectedUser.FirstName;
                txtApellido.Text = selectedUser.LastName;
                txtMail.Text = selectedUser.Email;
                txtUsuario.Text = selectedUser.UserName;
                txtClave.Text = selectedUser.Password;
                cmbTipo.SelectedIndex = selectedUser.Type;
                txtTitulo.Text = selectedUser.Title;
                
            }
        }

        private async void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            var consultaUsuario = conn.Table<User>();
            
            foreach (User user in consultaUsuario)
            {
                if (user.UserName.Equals(txtBuscar.Text))
                {
                    txtNombre.Text = user.FirstName;
                    txtApellido.Text = user.LastName;
                    txtMail.Text = user.Email;
                    txtUsuario.Text = user.UserName;
                    txtClave.Text = user.Password;
                    cmbTipo.SelectedIndex = user.Type;
                    txtTitulo.Text = user.Title;
                    marcaDeBusqueda = false;
                    
                    return;
                }
                else
                {
                    marcaDeBusqueda = true;
                }
                    
            }

            if (marcaDeBusqueda == false)
            {
                var msg = new MessageDialog("Usuario encontrado !!");
                await msg.ShowAsync();
            }
            else
            {
                var msg = new MessageDialog("Usuario NO encontrado !!");
                await msg.ShowAsync();
            }
        }

        private async void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtMail.Text = "";
            txtUsuario.Text = "";
            txtClave.Text = "";
            cmbTipo.SelectedIndex = -1;
            txtTitulo.Text = "";
            txtBuscar.Text = "";

            var msg = new MessageDialog("Formulario Limpio");
            await msg.ShowAsync();
        }
    }
}
