using Microsoft.AspNetCore.Mvc;
using Motoland.Models;

public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: Account/Login
    public ActionResult Login()
    {
        return View();
    }

    // POST: Account/Login
    [HttpPost]
    public ActionResult Login(string email, string password)
    {
        if (_userService.ValidateUser(email, password))
        {
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Nieprawidłowy email lub hasło";
        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    // POST: Account/Register
    [HttpPost]
    public IActionResult Register(User user)
    {
        if (ModelState.IsValid)
        {
            // Tu możesz dodać logikę do zapisu użytkownika w bazie danych
            TempData["SuccessMessage"] = "Registration successful!";
            return RedirectToAction("Login"); // Przekierowanie do strony logowania po rejestracji
        }

        return View(user); // W przypadku błędów walidacji zwróć formularz z błędami
    }

}
