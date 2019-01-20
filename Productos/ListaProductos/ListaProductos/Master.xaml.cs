using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaProductos
{
	public partial class Master : MasterDetailPage
	{
		public Master ()
		{
			InitializeComponent ();
            var listView = new ListView();
            listView.RowHeight = 50;
            listView.BackgroundColor = Color.White;
            listView.SeparatorColor = Color.White;

            var template = new DataTemplate(typeof(TextCell));
            template.SetValue(TextCell.TextColorProperty, Color.White);

            //Lista del menu
            listView.ItemsSource = new string[] 
            {
                "Favoritos",
                "Los mas buscados",
                "Los mas vendidos",
                "Promociones del mes"
            };

            //Crear el menu
            this.Master = new ContentPage
            {
                Title = "Menu",
                Content = new StackLayout
                {
                    Children =
                    {
                        listView
                    }
                }
            };
            this.Detail = new NavigationPage(new MainPage());
		}
	}
}