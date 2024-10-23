using Microsoft.AspNetCore.Mvc;

public class AdminController : Controller
{
    public IActionResult Panel()
    {
        // Logika dla panelu admina
        return View();
    }
}
