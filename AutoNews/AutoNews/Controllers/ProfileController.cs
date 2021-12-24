using AutoNews.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace AutoNews.Controllers;

public class ProfileController : Controller
{
    [Authorize]
    public IActionResult Index() => View(HttpContext.Items["User"]);

    [Authorize]
    public IActionResult Edit() => View(HttpContext.Items["User"]);
}
