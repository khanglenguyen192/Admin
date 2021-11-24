using Admin.Base.Pages;
using Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Admin.Pages
{
    public class OrderPage : BaseContentPage
    {
        public OrderPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new OrderPageViewModel(App.NavigationService);
        }

        protected override void SetupLandscapeLayout()
        {
            this.Content = new OrderPageLandscape();
        }

        protected override void SetupPortraitLayout()
        {
            this.Content = new OrderPageLandscape();
        }
    }
}
