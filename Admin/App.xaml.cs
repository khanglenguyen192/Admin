using Admin.Base.Services;
using Admin.Pages;
using Admin.Popups;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Admin
{
    public partial class App : Application
    {
        public static INavigationService NavigationService { get; } = new ViewNavigationService();

        public static IPopupNavigation popupNavigation { get; } = PopupNavigation.Instance;

        public App()
        {
            InitializeComponent();

            NavigationService.Register(nameof(LoginPage), typeof(LoginPage));
            NavigationService.Register(nameof(HomePage), typeof(HomePage));
            NavigationService.Register(nameof(ProductListPage), typeof(ProductListPage));
            NavigationService.Register(nameof(OrderPage), typeof(OrderPage));

            MainPage = ((ViewNavigationService)NavigationService).SetRootPage(nameof(LoginPage));

            //MainPage = ((ViewNavigationService)NavigationService).SetRootPage(nameof(HomePage));

            //MainPage = ((ViewNavigationService)NavigationService).SetRootPage(nameof(ProductListPage));

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
