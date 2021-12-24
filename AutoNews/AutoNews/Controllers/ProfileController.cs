using Microsoft.AspNetCore.Mvc;

namespace AutoNews.Controllers;

public class ProfileController : Controller
{
    public IActionResult Index() => View(HttpContext.Items["User"]);
    public IActionResult Edit() => View();
}
