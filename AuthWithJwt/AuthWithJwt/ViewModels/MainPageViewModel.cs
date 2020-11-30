using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AuthWithJwt.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private const string API_URL = "";

        private string _userName;
        private string _password;

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }


        public ICommand SignInCommand { get; set; }
        public ICommand SignUpCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";

            _navigationService = navigationService;

            SignInCommand = new Command(async () => await SignIn());
            SignUpCommand = new Command(async () => await SignUp());
        }

        private async Task SignIn()
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
                await App.Current.MainPage.DisplayAlert("Wraning", "Some Fields Still Empty , please Fill them before your sbmit", "got it");

            //call sign in API here
        }

        private async Task SignUp()
        {
            //got to register page
            await _navigationService.NavigateAsync("");
        }
    }
}
