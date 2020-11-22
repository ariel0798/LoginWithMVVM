using LoginWithMVVM.Services.Interfaces;
using System.Threading.Tasks;

namespace LoginWithMVVM.Services
{
    public class PageDialogService : IPageDialogService
    {
        public async Task DisplayAlert(string title, string message, string okText = "Ok")
        {
            await App.Current.MainPage.DisplayAlert(title, message, okText);
        }
    }
}
