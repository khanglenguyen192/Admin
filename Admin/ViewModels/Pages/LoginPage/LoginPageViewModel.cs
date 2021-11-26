using Admin.Base.Services;
using Admin.Base.ViewModels;
using Admin.Models;
using Admin.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Admin.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private const string Url = "http://localhost:5000/admin";
        public ObservableCollection<AdminAccount> DataSource { get; set; }

        private string _account;
        public string Account
        {
            get { return _account; }
            set
            {
                SetProperty(ref _account, value);
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value);
            }
        }

        public LoginPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Account = String.Empty;
            Password = String.Empty;
            GetListAccounts();
            MessagingCenter.Subscribe<LoginPageViewModel, string>(this, "adminList", (vm, responseContent) => {
                if (!responseContent.Equals(string.Empty))
                {
                    List<AdminAccount> admins = JsonConvert.DeserializeObject<List<AdminAccount>>(responseContent);
                    this.DataSource = new ObservableCollection<AdminAccount>(admins);
                }
                else
                {
                    this.DataSource = new ObservableCollection<AdminAccount>();
                }
                
            });
        }

        async protected void GetListAccounts()
        {
            HttpClient client = new HttpClient();
            string responseContent;
            try { 
                responseContent = await client.GetStringAsync(Url); 
            }
            catch
            {
                responseContent = string.Empty;
            }
            MessagingCenter.Send<LoginPageViewModel,string>(this, "adminList", responseContent);
        }

        public ICommand NavigateLoginCommand => new Command(async () =>
        {
            if (Account.Equals(string.Empty) || Password.Equals(string.Empty))
            {
                return;
            }

            for (int i = 0; i < this.DataSource.Count; i++)
            {
                if (Account.Equals(DataSource[i].UserName) && Password.Equals(DataSource[i].Password))
                {
                    Account = string.Empty;
                    Password = string.Empty;
                    await _navigationService.NavigateAsync(nameof(HomePage));
                    break;
                }
            }
        });
    }
}
