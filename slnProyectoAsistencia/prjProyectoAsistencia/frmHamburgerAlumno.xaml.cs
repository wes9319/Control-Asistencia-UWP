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
    public sealed partial class frmHamburgerAlumno : Page
    {
        public frmHamburgerAlumno()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(frm_Alum_Consulta));
            GoConsulta.IsChecked = true;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            if (Split.IsPaneOpen)
            {
                Split.IsPaneOpen = false;
            }
            else
            {
                Split.IsPaneOpen = true;
            }
            HamburgerButton.IsChecked = false;
        }

        private void Atras_Click(object sender, RoutedEventArgs e)
        {
            if (ContentFrame.CanGoBack)
            {
                ContentFrame.GoBack();
            }
            Atras.IsChecked = true;
        }

        private void GoConsulta_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(frm_Alum_Consulta));
            GoConsulta.IsChecked = true;
        }

        private void GoAsistencia_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(frm_Alum_Asistencia));
            GoAsistencia.IsChecked = true;
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(frmLogin));
        }
    }
}
