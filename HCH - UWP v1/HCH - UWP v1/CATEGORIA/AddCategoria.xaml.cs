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
    public sealed partial class AddCategoria : Page
    {
        public AddCategoria()
        {
            this.InitializeComponent();
        }
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
        private async void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            var categoria = new CATEGORIA()
            {
                IdCategoria = (int)Double.Parse(IDCategoriaTB.Text),
                Descripcion = IDDescripcionTB.Text,
                Activo = new bool(),
                FechaRegistro = DateTime.Today
            };
            var client = new HttpClient();
            var CATEGORIAJson = JsonConvert.SerializeObject(categoria);
            var HttpContent = new StringContent(CATEGORIAJson);

            HttpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("Application/json");

            await client.PostAsync("https://localhost:44399/api/Categoria", HttpContent);

            Frame.GoBack();

        }
    }
}
