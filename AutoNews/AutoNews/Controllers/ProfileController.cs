using AutoNews.Attributes;
using AutoNews.DB;
using Microsoft.AspNetCore.Mvc;

namespace AutoNews.Controllers;

public class ProfileController : Controller
{
    private readonly AutoNewsContext _dataContext;

    public ProfileController(AutoNewsContext dataContext) =>
        _dataContext = dataContext;

    public IActionResult Index(int userId)
    {
        var currentUser = HttpContext.Items["User"] as User;
        return View(new ProfileModel
        {
            User = userId == default
                ? currentUser
                : _dataContext.Users.FirstOrDefault(u => u.Id == userId),
            Edit = userId == default || currentUser?.Id == userId
        });
    }

    public readonly struct ProfileModel
    {
        public User? User { get; init; }
        public bool Edit { get; init; }
    }
    
    [Authorize]
    public IActionResult Edit() => View(HttpContext.Items["User"]);
}
