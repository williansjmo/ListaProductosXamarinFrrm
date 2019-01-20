using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListaProductos
{
    public partial class MainPage : ContentPage
    {
        JArray arrData;
        public MainPage()
        {
            InitializeComponent();
            LoadJsonAsync();
        }

        private async Task LoadJsonAsync()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("http://area51.pe/sol/")
            };
            string url = string.Format("tienda.json");
            var resp = await client.GetAsync(url);
            var result = resp.Content.ReadAsStringAsync().Result;
            JObject values = JObject.Parse(result);
            arrData = (JArray)values["tienda"];
            FillData(arrData);
        }

        private void FillData(JArray arrData)
        {
            var data = new List<Product>();
            for (int i = 0; i < arrData.Count; i++)
            {
                string cantidad = $"Cantidad: {((JArray)arrData[i]["items"]).Count}";
                Product tmp = new Product()
                {
                    nombre = arrData[i]["nombre"].ToString(),
                    cantidad = cantidad,
                    imagen = $"http://area51.pe/sol/{arrData[i]["imagen"]}",
                    items = (JArray)arrData[i]["items"]
                };
                data.Add(tmp);
            }
            list.ItemsSource = data;
            list.ItemSelected += List_ItemSelected;
        }

        private void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            if (e.SelectedItem == null) return;
            //DisplayAlert("Proximamente", (list.SelectedItem as Product).nombre,"Muchas gracias");
            var product = (list.SelectedItem as Product);

            ListarItems listar = new ListarItems(product.items);
            listar.Title = product.nombre;

            Navigation.PushAsync(listar);
        }
    }
}
