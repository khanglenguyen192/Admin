using Admin.Base.Services;
using Admin.Base.ViewModels;
using Admin.Models;
using Admin.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Admin.ViewModels
{
    public class ProductListPageViewModel : BaseViewModel
    {
        private const string Url = "http://localhost:5000/products";

        public ObservableCollection<Product> DataSource { get; set; }

        private string _receive;
        public string Receive
        {
            get { return _receive; }
            set
            {
                SetProperty(ref _receive, value);
            }
        }

        public ProductListPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            GetListProducts();
            MessagingCenter.Subscribe<ProductListPageViewModel, string>(this, "productList", (vm, responseContent) => {
                if (!responseContent.Equals(string.Empty))
                {
                    List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseContent);
                    DataSource = new ObservableCollection<Product>(products);
                    Receive = DataSource.Count.ToString();
                    for (int i = 0; i < DataSource.Count; i++)
                    {
                        DataSource[i].setCategory();
                    }
                }
                else
                {
                    DataSource = new ObservableCollection<Product>();
                }

            });

        }

        async protected void GetListProducts()
        {
            HttpClient client = new HttpClient();
            string responseContent;
            try
            {
                responseContent = await client.GetStringAsync(Url);
            }
            catch
            {
                responseContent = string.Empty;
            }
            MessagingCenter.Send<ProductListPageViewModel, string>(this, "productList", responseContent);
        }

        public ICommand NavigateEditCommand => new Command(async () =>
        {
            await _navigationService.NavigateAsync(nameof(HomePage));
        });

        public ICommand NavigateRemoveCommand => new Command( (e) =>
        {
            //MessagingCenter.Subscribe<ProductListPageViewModel, int>(this, "ProductListRemovedItem", (vm, removedItemId) =>
            //{
            //    for (int i = 0; i < DataSource.Count; i++)
            //    {
            //        if (DataSource[i].Id == removedItemId)
            //        {
            //            DataSource.RemoveAt(i);
            //            break;
            //        }
            //    }
            //});

            var item = (e as Product);

            for (int i = 0; i < DataSource.Count; i++)
            {
                //if (DataSource[i].Id == item.Id)
                //{
                //    DataSource.RemoveAt(i);
                //    break;
                //}
            }


        });
    }
}
