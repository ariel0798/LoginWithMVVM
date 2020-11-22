using LoginWithMVVM.Model;
using LoginWithMVVM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginWithMVVM.ViewModel
{
    public class RegistationViewModel
    {
        public RegistationViewModel(IPageDialogService pageDialogService, INavigationPageService navigationPageService, IUserService userService)
        {
            this.pageDialogService = pageDialogService;
            this.navigationPageService = navigationPageService;
            this.userService = userService;
        }   
        readonly IPageDialogService pageDialogService;
        readonly INavigationPageService navigationPageService;
        readonly IUserService userService;

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public ICommand RegisterCommand => new Command(() => 
        {
            if (string.IsNullOrEmpty(Name))
            {
                pageDialogService.DisplayAlert("Error", "Campo name no puede estar vacio");
            }
            else if (string.IsNullOrEmpty(Email))
            {
                pageDialogService.DisplayAlert("Error", "Campo email no puede estar vacio");
            }
            else if (string.IsNullOrEmpty(Password))
            {
                pageDialogService.DisplayAlert("Error", "Campo password no puede estar vacio");
            }
            else if (string.IsNullOrEmpty(ConfirmPassword))
            {
                pageDialogService.DisplayAlert("Error", "Campo confirm password no puede estar vacio");
            }
            else if (Password != ConfirmPassword)
            {
                pageDialogService.DisplayAlert("Error", "Las claves no coinciden, favor revisar");
            }
            else
            {
                if (userService.ExistingEmail(Email))
                {
                    pageDialogService.DisplayAlert("Email existente", "El email ya existe, elegir otro");
                }
                else
                {
                    var user = new User();
                    user.Name = Name;
                    user.Email = Email.ToLower();
                    user.Password = Password;

                    userService.AddUser(user);

                    pageDialogService.DisplayAlert("Creado", "El usuario fue creado satisfactoriamente");

                    navigationPageService.NavigationPagePop();
                }

            }
        });
    }
}
