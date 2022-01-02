
using HCH___UWP_v1.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
           public static string PRODUCTOUrl = "https://localhost:44399/api/producto";
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

        private void UsuarioFO_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UsuarioPantalla));

        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            HttpClient client = new HttpClient();
            var JsonReponse = await client.GetStringAsync("https://localhost:44399/api/producto");
            var PRODUCTOResult = JsonConvert.DeserializeObject<List<PRODUCTO>>(JsonReponse);
            ListaProducto.ItemsSource = PRODUCTOResult;
        }


    }
    }

