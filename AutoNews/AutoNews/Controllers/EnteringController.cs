using System.Linq.Expressions;
using System.Text.RegularExpressions;
using AutoNews.DB;
using Microsoft.AspNetCore.Mvc;
using player.Services;

namespace AutoNews.Controllers;

public class EnteringController : ControllerBase
{
    private readonly AutoNewsContext _dataContext;

    public EnteringController(AutoNewsContext dataContext) =>
        _dataContext = dataContext;

    [HttpPost]
    public IActionResult Login([FromForm] UserLoginPassword logPass)
    {
        var user = DbHelper.GetUserWithId(logPass.Login, logPass.Password, _dataContext);
        if (user is null) return BadRequest();
        HttpContext.Response.Cookies.Append("Authorization", JwtGenerator.GenerateJwtToken(user.Id));
        return Ok();
    }

    [HttpPost]
    public IActionResult Register([FromForm] User user)
    {
        Console.WriteLine($"new user: {user}");

        if (!Regex.IsMatch(user.Login, @"[a-z0-9._%+-]+\@[a-z0-9.-]+\.[a-z]{2,4}$") ||
            !Regex.IsMatch(user.Password, @"^(?=.*?[A-Z]).{8,}"))
        {
            if (!Regex.IsMatch(user.Login, @"[a-z0-9._%+-]+\@[a-z0-9.-]+\.[a-z]{2,4}$"))
                Console.WriteLine("bad login");
            if (!Regex.IsMatch(user.Password, @"^(?=.*?[A-Z]).{8,}"))
                Console.WriteLine("bad pass");
            return BadRequest();
        }

        Expression<Func<User, bool>> searchingExpression = u => u.Login == user.Login;
        if (_dataContext.Users.Any(searchingExpression))
            throw new Exception("already registered");
        _dataContext.Users.Add(user);
        _dataContext.SaveChanges();
        user = _dataContext.Users.First(searchingExpression);
        HttpContext.Response.Cookies.Append("Authorization", JwtGenerator.GenerateJwtToken(user.Id));
        return Ok();
    }

    public class UserLoginPassword
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
