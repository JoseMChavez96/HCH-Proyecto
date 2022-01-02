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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HCH___UWP_v1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UsuarioPantalla : Page
    {
        public static string USUARIOUrl = "https://localhost:44399/api/Usuario";
        public UsuarioPantalla()
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

        private void ProductoFO_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ProductoPantalla));
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(USUARIOUrl);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string API1 = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<USUARIO>>(API1);
                ListaUsuario.ItemsSource = resultado;
            }
        }

        //private void UsuarioFO_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(UsuarioPantalla));
        //}
    }
}
