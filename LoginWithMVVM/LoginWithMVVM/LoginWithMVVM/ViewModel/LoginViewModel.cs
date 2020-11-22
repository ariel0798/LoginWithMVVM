using LoginWithMVVM.Services.Interfaces;
using LoginWithMVVM.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginWithMVVM.ViewModel
{
    public class LoginViewModel
    {
        public LoginViewModel(IPageDialogService _pageDialogService, INavigationPageService _navigationPageService,
                IUserService _userService)
        {
            this.pageDialogService = _pageDialogService;
            this.navigationPageService = _navigationPageService;
            this.userService = _userService;
        }
        
        readonly IPageDialogService pageDialogService;
        readonly INavigationPageService navigationPageService;
        readonly IUserService userService;

        public string Email { get; set; }
        public string Password { get; set; }

        public ICommand LogInCommand => new Command(() =>
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                pageDialogService.DisplayAlert("Error", "El campo de Email o Password esta vacio");
            }
            else
            {
                if(userService.ExistingUser(Email,Password))
                {
                    navigationPageService.NavigationPagePush(new HomePage());
                }
                else
                {
                    pageDialogService.DisplayAlert("Error", "El email o password es incorrecto");
                }

            }
        });

        public ICommand GoToRegisterCommand => new Command(() => 
        {
            navigationPageService.NavigationPagePush(new RegistrationPage());
        });
    }
}
