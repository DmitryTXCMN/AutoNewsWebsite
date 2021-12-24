using Microsoft.AspNetCore.Mvc;

namespace AutoNews.Controllers;

public class ProfileController : Controller
{
    public IActionResult Index() => View();
    public IActionResult Edit() => View();
}
