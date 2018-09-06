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

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace prjProyectoAsistencia
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(frmCRUDUsuarios));
            GoUsuarios.IsChecked = true;
        }

        private void GoUsuarios_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(frmCRUDUsuarios));
            GoUsuarios.IsChecked = true;
        }

        private void GoMaterias_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(frmCRUDMateria));
            GoMaterias.IsChecked = true;
        }

        private void GoRelacionMaestroMateria_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(frmCRUDRelacionMaestroMateria));
            GoRelacionMaestroMateria.IsChecked = true;
        }

        private void GoRelacionAlumnoMateria_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(frmCRUDRelacionAlumnoMateria));
            GoRelacionAlumnoMateria.IsChecked = true;
        }

        private void GoHorario_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(frmCRUD_ADM_HorarioMaestro));
            GoHorario.IsChecked = true;
        }

        private void GoReporte_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(frm_AMD_Reporte));
            GoReporte.IsChecked = true;
        }

        private void GoAsistencia_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(frm_ADM_Asistencia));
            GoReporte.IsChecked = true;
        }

        private void Atras_Click(object sender, RoutedEventArgs e)
        {
            if (ContentFrame.CanGoBack)
            {
                ContentFrame.GoBack();
            }
            Atras.IsChecked = true;
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

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(frmLogin));
        }
    }
}
