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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HCH___UWP_v1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        
        private void CarritoFO_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CarritoPantalla));
        }

        private void CategoriaFO_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CategoriaPantalla));
        }

        private void CompraFO_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CompraPantalla));
        }

        private void DetalleCompraFO_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DetalleCompraPantalla));
        }

        private void MarcaFO_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MarcaPantalla));
        }

        private void ProductoFO_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ProductoPantalla));
        }

        private void UsuarioFO_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UsuarioPantalla));
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
