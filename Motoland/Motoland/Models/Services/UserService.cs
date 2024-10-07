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

        public bool ValidateUser(string email, string password)
        {
            // W prawdziwej aplikacji hasło powinno być haszowane i weryfikowane
            return _context.Users.Any(u => u.Email == email && u.Password == password);
        }

        public bool UserExists(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public void RegisterUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
