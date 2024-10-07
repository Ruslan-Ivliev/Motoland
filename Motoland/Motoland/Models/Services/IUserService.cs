using Motoland.Models;

namespace Motoland.Services
{
    public interface IUserService
    {
        bool ValidateUser(string email, string password);
        bool UserExists(string email);
        void RegisterUser(User user);
    }
}
