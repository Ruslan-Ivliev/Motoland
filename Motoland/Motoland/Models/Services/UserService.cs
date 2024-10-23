using System.Linq;
using Motoland.Models;

namespace Motoland.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Walidacja użytkownika - sprawdzenie poprawności emaila i hasła
        public bool ValidateUser(string email, string password)
        {
            // W prawdziwej aplikacji hasło powinno być haszowane i weryfikowane
            return _context.Users.Any(u => u.Email == email && u.Password == password);
        }

        // Sprawdzenie, czy użytkownik o podanym emailu istnieje
        public bool UserExists(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        // Rejestracja nowego użytkownika
        public void RegisterUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // Sprawdzenie, czy użytkownik jest administratorem
        public bool IsAdmin(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            return user?.IsAdmin ?? false; // Zwraca true, jeśli użytkownik ma uprawnienia admina
        }

        // Inicjalizacja konta administratora, jeśli jeszcze nie istnieje
        public void CreateAdminIfNotExists()
        {
            if (!_context.Users.Any(u => u.IsAdmin))
            {
                var adminUser = new User
                {
                    Email = "admin@motoland.com",   // Domyślny email admina
                    Password = "AdminPassword123",  // Domyślne hasło (powinno być zahaszowane)
                    Name = "Administrator",         // Dodaj nazwę admina
                    IsAdmin = true
                };

                _context.Users.Add(adminUser);
                _context.SaveChanges();
            }
        }
        
    }
}
