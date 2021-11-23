using Admin.Base.Pages;
using Admin.Pages;
using Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Admin.Pages
{
    public class LoginPage : BaseContentPage
    {
        public LoginPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new LoginPageViewModel(App.NavigationService);
        }

        protected override void SetupLandscapeLayout()
        {
            this.Content = new LoginPageLandscape();
        }

        protected override void SetupPortraitLayout()
        {
            this.Content = new LoginPageLandscape();
        }
    }
}
