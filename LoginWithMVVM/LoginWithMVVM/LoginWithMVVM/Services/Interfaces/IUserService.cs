using LoginWithMVVM.Model;

namespace LoginWithMVVM.Services.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        bool ExistingUser(string email, string password);
        bool ExistingEmail(string email);
        User GetUser(string email, string password);
    }
}
