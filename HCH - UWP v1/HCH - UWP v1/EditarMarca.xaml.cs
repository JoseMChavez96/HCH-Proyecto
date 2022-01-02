using HCH___UWP_v1.Classes;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using System.Net.Http;



// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace HCH___UWP_v1
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class EditarMarca : Page
    {
        private MARCA marca = new MARCA();
        public EditarMarca()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            marca = e.Parameter as MARCA;

            IDDescripcionTB.Text = marca.Descripcion;

        }
        private async void AppBarButton_Click(object  sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            await client.DeleteAsync("https://localhost:44399/api/Marca/" + marca);
            Frame.GoBack();
        }
        private async void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();

            marca.Descripcion = IDDescripcionTB.Text;

            var MARCAJson = JsonConvert.SerializeObject(marca);
            var HttpContent = new StringContent(MARCAJson);
            HttpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("Application/json");

           await client.PutAsync("https://localhost:44399/api/Marca/" + marca, HttpContent);
            Frame.GoBack();
        } 
    }
}
