using Admin.Base.Services;
using Admin.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Admin
{
    public partial class App : Application
    {
        public static INavigationService NavigationService { get; } = new ViewNavigationService();

        public App()
        {
            InitializeComponent();

            NavigationService.Register(nameof(LoginPage), typeof(LoginPage));
            NavigationService.Register(nameof(HomePage), typeof(HomePage));
            NavigationService.Register(nameof(ProductListPage), typeof(ProductListPage));

            MainPage = ((ViewNavigationService)NavigationService).SetRootPage(nameof(LoginPage));

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
