using HCH___UWP_v1.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace HCH___UWP_v1
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class EditarProducto : Page
    {
        private PRODUCTO producto;
        private PRODUCTO nombre;
        private PRODUCTO precio;
        public EditarProducto()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            producto = e.Parameter as PRODUCTO;
            nombre = e.Parameter as PRODUCTO;
            precio = e.Parameter as PRODUCTO;

            IDDescripcionTB.Text = producto.Descripcion;
            IDNombreTB.Text = nombre.Nombre;
            Double.Parse(IDPrecioTB.Text)  = precio.Precio;

        }
        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            await client.DeleteAsync("https://localhost:44399/api/Producto/" + producto.IdProducto);
            Frame.GoBack();
        }
        private async void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();

            producto.Descripcion = IDDescripcionTB.Text;
            producto.MARCA = null;
            producto.CATEGORIA = null;
            var PRODUCTOJson = JsonConvert.SerializeObject(producto);
            var HttpContent = new StringContent(PRODUCTOJson);
            HttpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("Application/json");

            await client.PutAsync("https://localhost:44399/api/Producto/" + producto.IdProducto, HttpContent);
            Frame.GoBack();
        }
    }
}
