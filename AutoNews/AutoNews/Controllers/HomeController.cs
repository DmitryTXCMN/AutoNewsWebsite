using System.Diagnostics;
using AutoNews.DB;
using AutoNews.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoNews.Controllers;

public class HomeController : Controller
{
    private readonly AutoNewsContext _dataContext;

    public HomeController(AutoNewsContext dataContext) =>
        _dataContext = dataContext;

    public IActionResult Index() =>
        View(_dataContext.News.OrderBy(n => n.Likes).Select(n => new BetterNews
        {
            Id = n.Id,
            Title = n.Title,
            Text = n.Text,
            LogoUrl = n.LogoUrl,
            Likes = n.Likes,
            Date = n.Date,
            Creator = _dataContext.Users.FirstOrDefault(u => u.Id == n.CreatorId)
        }));

    public readonly struct BetterNews
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Text { get; init; }
        public string LogoUrl { get; init; }
        public int Likes { get; init; }
        public DateTime Date { get; init; }
        public User? Creator { get; init; }
    }

    public IActionResult Privacy() =>
        View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
}
