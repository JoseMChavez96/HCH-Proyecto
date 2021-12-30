
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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace HCH___UWP_v1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductoPantalla : Page
    {
        public ProductoPantalla()
        {
            this.InitializeComponent();
        }

        

        private void MainPageFO_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void CarritoFO_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof( -- PANTALLA DE ITEM -- ));
        }

        private void CategoriaFO_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof( -- PANTALLA DE ITEM -- ));
        }

        private void CompraFO_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof( -- PANTALLA DE ITEM -- ));
        }

        private void DetalleCompraFO_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof( -- PANTALLA DE ITEM -- ));
        }

        private void MarcaFO_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof( -- PANTALLA DE ITEM -- ));
        }

         private void UsuarioFO_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof( -- PANTALLA DE ITEM -- ));
        }
    }
}
