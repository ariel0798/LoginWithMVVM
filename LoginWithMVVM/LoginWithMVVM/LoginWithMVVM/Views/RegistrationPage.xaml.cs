using LoginWithMVVM.Services;
using LoginWithMVVM.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginWithMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            this.BindingContext = new RegistationViewModel(new PageDialogService(), new NavigationPageService(), new UserService());
        }
    }
}