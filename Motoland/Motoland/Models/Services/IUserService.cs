using Motoland.Models;

namespace Motoland.Services
{
    public interface IUserService
    {
        bool ValidateUser(string email, string password); // Walidacja użytkownika
        bool UserExists(string email); // Sprawdzenie, czy użytkownik istnieje
        void RegisterUser(User user); // Rejestracja nowego użytkownika
        bool IsAdmin(string email); // Sprawdzenie, czy użytkownik jest administratorem
        void CreateAdminIfNotExists(); // Inicjalizacja konta administratora, jeśli nie istnieje
    }
}
