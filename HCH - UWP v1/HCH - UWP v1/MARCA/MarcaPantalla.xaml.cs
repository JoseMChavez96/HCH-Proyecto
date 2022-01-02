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
    public sealed partial class MarcaPantalla : Page
    {

        public static string MARCAUrl = "https://localhost:44399/api/Marca";
        public MarcaPantalla()
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

        //private void MarcaFO_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(MarcaPantalla));
        //}

        private void ProductoFO_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ProductoPantalla));
        }

        private void UsuarioFO_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UsuarioPantalla));
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            HttpClient client = new HttpClient();
            var JsonReponse = await client.GetStringAsync("https://localhost:44399/api/Marca");
            var MARCAResult = JsonConvert.DeserializeObject<List<MARCA>>(JsonReponse);
            ListaMarca.ItemsSource = MARCAResult;
        }

        // private async void Button_Click_1(object sender, RoutedEventArgs e)
        // {
        //   var httpHandler = new HttpClientHandler();
        //   var request = new HttpRequestMessage();
        //   request.RequestUri = new Uri(MARCAUrl);
        //   request.Method = HttpMethod.Get;
        //  request.Headers.Add("Accept", "application/json");
        //  var client = new HttpClient(httpHandler);

        //   HttpResponseMessage response = await client.SendAsync(request);
        //   if (response.StatusCode == HttpStatusCode.OK)
        //   {
        //      string API1 = await response.Content.ReadAsStringAsync();
        //       var resultado = JsonConvert.DeserializeObject<List<MARCA>>(API1);
        //       ListaMarca.ItemsSource = resultado;
        //    }

        //  HttpClient client = new HttpClient();
        //  var JsonReponse = await client.GetStringAsync("https://localhost:44399/api/Marca");
        //   var MARCAResult = JsonConvert.DeserializeObject<List<MARCA>>(JsonReponse);
        //  ListaMarca.ItemsSource = MARCAResult;

        // }
        protected void AppBarButton_Click(object  sender,  RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddMarca));
        }

        private void ListaMarca_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var marca = ListaMarca.SelectedItem as MARCA;
            Frame.Navigate(typeof(EditarMarca), marca);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
