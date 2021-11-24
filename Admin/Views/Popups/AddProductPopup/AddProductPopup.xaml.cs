using Admin.Models;
using Admin.ViewModels.Popups.AddProductPopup;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
    public partial class AddProductPopup : PopupPage
    {
        public Product product;

        public AddProductPopup()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new AddProductPopupViewModel(App.NavigationService, App.popupNavigation);
        }

        //public async void OnCloseClicked(object sender, EventArgs e)
        //{
        //    await App.popupNavigation.PopAsync();
        //}
    }
}