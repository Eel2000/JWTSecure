using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AuthWithJwt.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private const string API_URL = "";//base your to bind to API

        private string _userName;
        private string _email;
        private string _password;

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }


        public ICommand RegisterCommand { get; set; }

        public RegisterPageViewModel(INavigationService navigationService)
            :base(navigationService)
        {
            _navigationService = navigationService;
        }

        private async Task Register()
        {
            ///put code to register new user with password here;
        }
    }
}
