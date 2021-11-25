using Admin.Base.Services;
using Admin.Base.ViewModels;
using Admin.Models;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Admin.ViewModels.Popups.OrderDetailPopup
{
    public class OrderDetailPopupViewModel : BaseViewModel
    {
        private IPopupNavigation _popupNavigation;

        public ObservableCollection<OrderItem> OrderItemList { get; set; }

        public ObservableCollection<OrderItemDetail> OrderItemDetailList { get; set; }

        private const string Url = "http://localhost:5000/payment/order_item";

        private HttpClient client;

        private int _orderId { get; set; }

        private string _receive;
        public string Receive
        {
            get { return _receive; }
            set
            {
                SetProperty(ref _receive, value);
            }
        }

        public OrderDetailPopupViewModel(INavigationService navigationService, IPopupNavigation popupNavigation)
            : base(navigationService)
        {
            _popupNavigation = popupNavigation;
            client = new HttpClient();
        }

        public void setOrderId (int id)
        {
            _orderId = id;
        }

        public ICommand NavigateCloseCommand => new Command(async () =>
        {
            await _popupNavigation.PopAsync();
        });

        async public void setListOrderItemJson(int id)
        {
            string responseContent;
            try
            {
                responseContent = await client.GetStringAsync(Url + "?ID=" + id.ToString());
            }
            catch
            {
                responseContent = string.Empty;
            }
            MessagingCenter.Send<OrderDetailPopupViewModel, string>(this, "OrderItemList", responseContent);
        }

        public void setListOrderItem()
        {
            MessagingCenter.Subscribe<OrderDetailPopupViewModel, string>(this, "OrderItemList", (vm, responseContent) =>
            {
                if (!responseContent.Equals(string.Empty))
                {
                    List<OrderItem> orderItems = JsonConvert.DeserializeObject<List<OrderItem>>(responseContent);
                    OrderItemList = new ObservableCollection<OrderItem>(orderItems);
                    //Receive = OrderItemList.Count.ToString();
                    Receive = responseContent;
                }
                else
                {
                    OrderItemList = new ObservableCollection<OrderItem>();
                    Receive = "Failed";
                }
            });
        }

        async public void setListOrderItemDetail()
        {
            string productUrl = "http://localhost:5000/products/detail";
            string response;
            Product product;
            for (int i = 0; i < OrderItemList.Count; i++)
            {
                response = await client.GetStringAsync(productUrl + "?id=" + OrderItemList[i].ProductId.ToString());
                if (!response.Equals(string.Empty))
                {
                    product = JsonConvert.DeserializeObject<Product>(response);
                }
            }
        }
    }
}
