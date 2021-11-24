using Admin.Base.Services;
using Admin.Base.ViewModels;
using Admin.Models;
using Rg.Plugins.Popup.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Admin.ViewModels.Popups.AddProductPopup
{
    public class AddProductPopupViewModel : BaseViewModel
    {
        private IPopupNavigation _popupNavigation;

        public AddProductPopupViewModel(INavigationService navigationService, IPopupNavigation popupNavigation)
            : base(navigationService)
        {
            _popupNavigation = popupNavigation;
        }

        public ICommand NavigateAddCommand => new Command(async () =>
        {
            await _popupNavigation.PopAsync();
        });

        public ICommand NavigateCloseCommand => new Command(async () =>
        {
            await _popupNavigation.PopAsync();
        });
    }
}
