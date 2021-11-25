using Admin.Base.Services;
using Admin.Base.ViewModels;
using Admin.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Admin.ViewModels
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

        public ICommand NavigateOrderCommand => new Command(async () =>
        {
            await _navigationService.NavigateAsync(nameof(OrderPage));
        });

        public ICommand NavigateLogOutCommand => new Command(async () =>
        {
            await _navigationService.GoBack();
        });
    }
}
