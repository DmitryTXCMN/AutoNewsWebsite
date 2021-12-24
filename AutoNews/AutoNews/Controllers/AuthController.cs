using Microsoft.AspNetCore.Mvc;

namespace AutoNews.Controllers;

public class AuthController : Controller
{
    public IActionResult Login() => View();
    public IActionResult Register() => View();
}
