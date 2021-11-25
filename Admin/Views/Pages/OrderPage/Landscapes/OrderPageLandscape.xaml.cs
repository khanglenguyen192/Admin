using Admin.Models;
using Admin.Popups;
using Newtonsoft.Json;
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
    public partial class OrderPageLandscape : ContentView
    {
        public ObservableCollection<Order> DataSource { get; set; }

        private const string Url = "http://localhost:5000/payment/order";

        public OrderPageLandscape()
        {
            InitializeComponent();
            getListOrder();
        }

        public async void getListOrder()
        {
            HttpClient client = new HttpClient();
            string responseContent;
            responseContent = await client.GetStringAsync(Url);
            if (!responseContent.Equals(string.Empty))
            {
                List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(responseContent);
                DataSource = new ObservableCollection<Order>(orders);
                debugText.Text = DataSource.Count.ToString();
            }
            else
            {
                DataSource = new ObservableCollection<Order>();
            }

            //DataSource.Add(new Order(1, "Nguyễn Văn A", "0123456789", "nva@gmail.com", "268 Lý Thường Kiệt, phường 14, quận 10, Thành phố Hồ Chí Minh", "", "Tiền mặt", "Đã nhận"));
            OrderListView.ItemsSource = DataSource;
        }

        public async void OrderDetailClicked(object sender, EventArgs e)
        {
            var item = (Button)sender;
            int id = (int)item.CommandParameter;
            for (int i = 0; i < DataSource.Count; i++)
            {
                if (DataSource[i].OrderId == id)
                {
                    await App.popupNavigation.PushAsync(new OrderDetailPopup(id));
                    break;
                }
            }
        }
    }
}