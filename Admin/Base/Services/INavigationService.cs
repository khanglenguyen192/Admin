using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Base.Services
{
    public interface INavigationService
    {
        string CurrentPageKey { get; }

        void Register(string pageKey, Type pageType);
        Task GoBack();
        Task NavigateModalAsync(string pageKey, bool animated = true);
        Task NavigateModalAsync(string pageKey, object parameter, bool animated = true);
        Task NavigateAsync(string pageKey, bool animated = true);
        Task NavigateAsync(string pageKey, object parameter, bool animated = true);
    }
}
