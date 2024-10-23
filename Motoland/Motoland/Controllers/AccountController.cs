using Microsoft.AspNetCore.Mvc;
using Motoland.Models;
using Motoland.Services;

namespace Motoland.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (_userService.ValidateUser(email, password))
            {
                // Sprawdzamy, czy użytkownik jest administratorem
                if (_userService.IsAdmin(email))
                {
                    // Przekierowanie na panel admina, jeśli użytkownik jest adminem
                    return RedirectToAction("Administrator", "Account");
                }
                else
                {
                    // Jeśli użytkownik nie jest adminem, przekierowujemy do strony użytkownika
                    return RedirectToAction("User_Login", "CarAds");
                }
            }

            ViewBag.Error = "Nieprawidłowy email lub hasło";
            return View();
        }

        // GET: Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        public IActionResult Register(User user, string confirmPassword)
        {
            if (user.Password != confirmPassword)
            {
                ViewBag.Error = "Hasła nie są zgodne.";
                return View();
            }

            if (_userService.UserExists(user.Email))
            {
                ViewBag.Error = "Użytkownik z tym adresem email już istnieje.";
                return View();
            }

            if (ModelState.IsValid)
            {
                // W prawdziwej aplikacji hasło powinno być haszowane przed zapisaniem
                _userService.RegisterUser(user);
                return RedirectToAction("Login");
            }

            return View(user);
        }

        // Panel administratora - dostępny tylko dla admina
        public IActionResult Administrator()
        {
            return View();
        }
    }
}
