using Admin.Base.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Admin.Base.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        public INavigationService _navigationService { get; }

        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public static implicit operator ObservableCollection<object>(BaseViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
