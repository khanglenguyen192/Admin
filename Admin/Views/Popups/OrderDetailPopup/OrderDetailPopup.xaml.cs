using Admin.Models;
using Admin.ViewModels.Popups.OrderDetailPopup;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Admin.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetailPopup : PopupPage
    {
        public ObservableCollection<OrderItemDetail> DataSource { get; set; }

        private const string Url = "http://localhost:5000/payment/order_item";

        public OrderDetailPopup(int orderId)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            var vm = new OrderDetailPopupViewModel(App.NavigationService, App.popupNavigation);
            vm.setOrderId(orderId);
            //vm.setListOrderItemJson(orderId);
            //vm.setListOrderItem();
            this.BindingContext = vm;

            getOrderItemList(orderId);

            //DataSource = new ObservableCollection<OrderItemDetail>();
            //DataSource.Add(new OrderItemDetail("Acus Stage Pre 3", "https://vietthuongshop.vn/image/cache/catalog/2-san-pham/amply/acus/amplifier-acus-stage-pre-3-1-400x400.jpg", 17300000, 2));
            //DataSource.Add(new OrderItemDetail("Acus Stage Pre 3", "https://vietthuongshop.vn/image/cache/catalog/2-san-pham/amply/acus/amplifier-acus-stage-pre-3-1-400x400.jpg", 17300000, 2));
            //DataSource.Add(new OrderItemDetail("Acus Stage Pre 3", "https://vietthuongshop.vn/image/cache/catalog/2-san-pham/amply/acus/amplifier-acus-stage-pre-3-1-400x400.jpg", 17300000, 2));
            //DataSource.Add(new OrderItemDetail("Acus Stage Pre 3", "https://vietthuongshop.vn/image/cache/catalog/2-san-pham/amply/acus/amplifier-acus-stage-pre-3-1-400x400.jpg", 17300000, 2));
            //DataSource.Add(new OrderItemDetail("Acus Stage Pre 3", "https://vietthuongshop.vn/image/cache/catalog/2-san-pham/amply/acus/amplifier-acus-stage-pre-3-1-400x400.jpg", 17300000, 2));
            //OrderItemView.ItemsSource = DataSource;
        }

        private async void getOrderItemList(int id)
        {
            string productUrl = "http://localhost:5000/products/detail";

            HttpClient client = new HttpClient();
            string responseOrderItems = await client.GetStringAsync(Url + "?ID=" + id.ToString());
            List<OrderItem> orderItems = JsonConvert.DeserializeObject<List<OrderItem>>(responseOrderItems);

            string responseProduct;
            Product product;
            DataSource = new ObservableCollection<OrderItemDetail>();

            long total = 0;

            for (int i = 0; i < orderItems.Count; i++)
            {
                responseProduct = await client.GetStringAsync(productUrl + "?id=" + orderItems[i].ProductId.ToString());
                //responseProduct = responseProduct.Substring(1, responseProduct.Length-2);
                //debugTest.Text = responseProduct;
                if (!responseProduct.Equals(string.Empty))
                {
                    product = JsonConvert.DeserializeObject<Product>(responseProduct.Substring(1, responseProduct.Length - 2));
                    OrderItemDetail orderItemDetail = new OrderItemDetail(product.Name, product.Img, product.Price, orderItems[i].Quantity);
                    DataSource.Add(orderItemDetail);
                    total = total + product.Price * orderItems[i].Quantity;
                }
            }
            OrderItemView.ItemsSource = DataSource;
            totalPrice.Text = total.ToString();
        }

        public async void OnConfirmClicked(object sender, EventArgs e)
        {
            await App.popupNavigation.PopAsync();
        }
    }
}