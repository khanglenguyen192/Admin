using Admin.Base.Pages;
using Admin.ViewModels.Pages.HomePage;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Admin.Pages
{
    public class HomePage : BaseContentPage
    {
        public HomePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new HomePageViewModel(App.NavigationService);
        }

        protected override void SetupLandscapeLayout()
        {
            this.Content = new HomePageLandscape();
        }

        protected override void SetupPortraitLayout()
        {
            this.Content = new HomePageLandscape();
        }
    }
}
