using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaProductos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListarItems : ContentPage
	{
		public ListarItems (JArray arrData)
		{
			InitializeComponent ();

            var data = new List<Product>();
            for (int i = 0; i < arrData.Count; i++)
            {
                //string cantidad = $"Cantidad: {((JArray)arrData[i]["items"]).Count}";
                Product tmp = new Product()
                {
                    nombre = arrData[i]["nombre"].ToString(),
                    PrecioMillar = arrData[i]["precioMillar"].ToString(),
                    imagen = $"http://area51.pe/sol/{arrData[i]["imagen"]}",
                };
                data.Add(tmp);
            }
            
            list.ItemsSource = data;
        }


	}
}