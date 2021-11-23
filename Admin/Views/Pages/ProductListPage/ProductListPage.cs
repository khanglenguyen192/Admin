using Admin.Base.Pages;
using Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Admin.Pages
{
    public class ProductListPage : BaseContentPage
    {
        public ProductListPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new ProductListPageViewModel(App.NavigationService);
        }

        protected override void SetupLandscapeLayout()
        {
            this.Content = new ProductListPageLandscape();
        }

        protected override void SetupPortraitLayout()
        {
            this.Content = new ProductListPageLandscape();
        }
    }
}
