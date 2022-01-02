using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Net.Http;
using System.Net;
using HCH___UWP_v1.Classes;
using Newtonsoft.Json;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace HCH___UWP_v1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CategoriaPantalla : Page
    { 

         public static string CATEGORIAUrl = "https://localhost:44399/api/categoria";
    
        public CategoriaPantalla()
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

        //private void CategoriaFO_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(CategoriaPantalla));
        //}

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
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(CATEGORIAUrl);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string API1 = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<CATEGORIA>>(API1);
                ListaCategoria.ItemsSource = resultado;
            }
        }
    }
}
