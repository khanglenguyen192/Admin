using Admin.Models;
using Admin.ViewModels.Popups.OrderDetailPopup;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public OrderDetailPopup(int orderId)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            var vm = new OrderDetailPopupViewModel(App.NavigationService, App.popupNavigation);
            vm.setOrderId(orderId);
            //vm.setListOrderItemJson(orderId);
            //vm.setListOrderItem();

            this.BindingContext = vm;

            DataSource = new ObservableCollection<OrderItemDetail>();
            DataSource.Add(new OrderItemDetail("Acus Stage Pre 3", "https://vietthuongshop.vn/image/cache/catalog/2-san-pham/amply/acus/amplifier-acus-stage-pre-3-1-400x400.jpg", 17300000, 2));
            DataSource.Add(new OrderItemDetail("Acus Stage Pre 3", "https://vietthuongshop.vn/image/cache/catalog/2-san-pham/amply/acus/amplifier-acus-stage-pre-3-1-400x400.jpg", 17300000, 2));
            DataSource.Add(new OrderItemDetail("Acus Stage Pre 3", "https://vietthuongshop.vn/image/cache/catalog/2-san-pham/amply/acus/amplifier-acus-stage-pre-3-1-400x400.jpg", 17300000, 2));
            DataSource.Add(new OrderItemDetail("Acus Stage Pre 3", "https://vietthuongshop.vn/image/cache/catalog/2-san-pham/amply/acus/amplifier-acus-stage-pre-3-1-400x400.jpg", 17300000, 2));
            DataSource.Add(new OrderItemDetail("Acus Stage Pre 3", "https://vietthuongshop.vn/image/cache/catalog/2-san-pham/amply/acus/amplifier-acus-stage-pre-3-1-400x400.jpg", 17300000, 2));
            OrderItemView.ItemsSource = DataSource;
        }

        public async void OnConfirmClicked(object sender, EventArgs e)
        {
            await App.popupNavigation.PopAsync();
        }
    }
}