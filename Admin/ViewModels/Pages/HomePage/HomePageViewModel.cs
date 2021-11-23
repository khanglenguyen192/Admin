using Admin.Base.Services;
using Admin.Base.ViewModels;
using Admin.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Admin.ViewModels.Pages.HomePage
{
    public class HomePageViewModel : BaseViewModel
    {
        public HomePageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
        }

        public ICommand NavigateProductListCommand => new Command(async () =>
        {
            await _navigationService.NavigateAsync(nameof(ProductListPage));
        });
    }
}
