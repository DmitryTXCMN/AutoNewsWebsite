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

    //логика вам мерещится
    public IActionResult Index()
    {
        var monthAgo = DateTime.Now.AddMonths(-1);
        var twoMonthsAgo = DateTime.Now.AddMonths(-2);

        var news = _dataContext.News
            .Where(n => n.Date > monthAgo)
            .OrderBy(n => -n.Likes)
            .Select(n => new HomeIndexModel.BetterNews
            {
                Id = n.Id,
                Title = n.Title,
                Text = n.Text,
                LogoUrl = n.LogoUrl,
                Likes = n.Likes,
                Date = n.Date,
                Creator = _dataContext.Users.FirstOrDefault(u => u.Id == n.CreatorId)
            })
            .ToList();

        var writer1 = _dataContext.Users
            .OrderBy(u => _dataContext.News
                .Where(n => n.CreatorId == u.Id && n.Date >= twoMonthsAgo && n.Date < monthAgo)
                .Sum(n => n.Likes))
            .FirstOrDefault();
        var writer2 = _dataContext.Users
            .OrderBy(u => _dataContext.News
                .Where(n => n.CreatorId == u.Id && n.Date >= monthAgo)
                .Sum(n => n.Likes))
            .FirstOrDefault();

        var newsblock = new List<List<HomeIndexModel.BetterNews>>();
        for (int i = 1; i < news.Count(); i = i + 4) 
        {
            newsblock.Add(news.Skip(i).Take(Math.Min(4, news.Count - 1)).ToList());
        }

        var model = new HomeIndexModel
        {
            HeaderNews = news.Count != default ? news.FirstOrDefault() : null,
            NewsBlocks = newsblock,
            News1 = news.Count > 1
                ? news.Skip(1).Take(Math.Min(4, news.Count - 1)).ToList()
                : new List<HomeIndexModel.BetterNews>(),
            News2 = news.Count > 5
                ? news.Skip(5).Take(Math.Min(4, news.Count - 1)).ToList()
                : new List<HomeIndexModel.BetterNews>(),
            Writer1 = writer1,
            Writer2 = writer2,
            Likes1 = writer1 is not null
                ? _dataContext.News
                    .Where(n => n.CreatorId == writer1.Id &&
                                n.Date >= twoMonthsAgo && n.Date < monthAgo)
                    .Sum(n => n.Likes)
                : null,
            Likes2 = writer2 is not null
                ? _dataContext.News
                    .Where(n => n.CreatorId == writer2.Id &&
                                n.Date >= monthAgo)
                    .Sum(n => n.Likes)
                : null
        };
        return View(model);
    }

    public readonly struct HomeIndexModel
    {
        public BetterNews? HeaderNews { get; init; }
        public List<List<BetterNews>> NewsBlocks { get; init; }
        public List<BetterNews> News1 { get; init; }
        public List<BetterNews> News2 { get; init; }
        public User? Writer1 { get; init; }
        public int? Likes1 { get; init; }
        public User? Writer2 { get; init; }
        public int? Likes2 { get; init; }

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
    }

    public IActionResult Privacy() =>
        View();

    public IActionResult Contacts() =>
        View();
    public IActionResult AboutUs() =>
        View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});

    public IActionResult Search(string searchRequest) => 
        View(_dataContext.News.Where(n => n.Title.Contains(searchRequest)));

    public IActionResult Users() => View(_dataContext.Users);
}
