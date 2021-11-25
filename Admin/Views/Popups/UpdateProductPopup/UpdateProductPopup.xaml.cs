using Admin.Models;
using Admin.ViewModels;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Admin.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateProductPopup : PopupPage
    {
        private Product _product;

        public UpdateProductPopup(Product product)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _product = product;
            var vm = new UpdateProductPopupViewModel(App.NavigationService, App.popupNavigation);
            vm.setProduct(product);
            this.BindingContext = vm;
        }
    }
}