using Admin.Models;
using Admin.Popups;
using Admin.ViewModels;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Admin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductListPageLandscape : ContentView
    {
        public ObservableCollection<Product> DataSource { get; set; }
        private HttpClient client;

        private const string ProductUrl = "http://localhost:5000/products/detail";

        public ProductListPageLandscape()
        {
            InitializeComponent();
            getListProduct();
        }

        public async void getListProduct()
        {
            string Url = "http://localhost:5000/products";
            client = new HttpClient();
            string responseContent;
            responseContent = await client.GetStringAsync(Url);
            if (!responseContent.Equals(string.Empty))
            {
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseContent);
                DataSource = new ObservableCollection<Product>(products);
                debugText.Text = DataSource.Count.ToString();
                for (int i = 0; i < DataSource.Count; i++)
                {
                    DataSource[i].setCategory();
                }
            }
            else
            {
                DataSource = new ObservableCollection<Product>();
            }
            ProductListView.ItemsSource = DataSource;
        }

        public async void ItemRemoveClicked(object sender, EventArgs e)
        {
            var item = (Button)sender;
            //debugText.Text = item.CommandParameter.ToString();
            int id = (int)item.CommandParameter;
            for (int i = 0; i < DataSource.Count; i++)
            {
                if (DataSource[i].Id == id)
                {
                    DataSource.RemoveAt(i);
                    debugText.Text = DataSource.Count.ToString();
                    await client.DeleteAsync(ProductUrl + "?id=" + id.ToString());
                    break;
                }
            }
        }

        public async void ItemEditClicked(object sender, EventArgs e)
        {
        }

        public async void AddProductClicked(object sender, EventArgs e)
        {
            await App.popupNavigation.PushAsync(new AddProductPopup());
        }
    }
}