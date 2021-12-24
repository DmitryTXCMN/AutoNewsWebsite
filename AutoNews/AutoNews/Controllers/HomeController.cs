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
        View(_dataContext.News.OrderBy(n => n.Likes));

    public IActionResult Privacy() =>
        View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
}
