using prjProyectoAsistencia.Common;
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
    public sealed partial class frmLogin : Page
    {

        Database db;
        public frmLogin()
        {
           
            this.InitializeComponent();
            db = new Database();
            db.Register(new Common.User()
            {
                UserName = "adm",
                Password = "000",
                Email = "adm@email.com",
                FirstName="adm",
                LastName="adm",
                Title="Administrador",
                Type = 0
                
            });
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (db.Login(txtUser.Text, txtPassword.Password)==0)
            {
                var message = new MessageDialog("Sesión iniciada correctamente, como Administrador");
                await message.ShowAsync();
                
                
                Frame.Navigate(typeof(MainPage));
            }
            else
            {
                if (db.Login(txtUser.Text, txtPassword.Password) == 1)
                {
                    var message = new MessageDialog("Sesión iniciada correctamente, como Maestro");
                    await message.ShowAsync();

                    Frame.Navigate(typeof(frmHamburgerMaestro));
                }
                else
                {
                    if (db.Login(txtUser.Text, txtPassword.Password) == 2)
                    {
                        var message = new MessageDialog("Sesión iniciada correctamente, como Alumno");
                        await message.ShowAsync();

                        Frame.Navigate(typeof(frmHamburgerAlumno));
                    }
                    else
                    {
                        var message = new MessageDialog("Fallo en el inicio de sesión");
                        await message.ShowAsync();
                    }
                }
                
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
