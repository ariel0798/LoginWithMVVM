using LoginWithMVVM.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using LoginWithMVVM.Services;

namespace LoginWithMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : Xamarin.Forms.TabbedPage
    {
        public LoginPage()
        {
            InitializeComponent();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            this.BindingContext = new LoginViewModel(new PageDialogService(), new NavigationPageService(), new UserService());
        }
    }
}