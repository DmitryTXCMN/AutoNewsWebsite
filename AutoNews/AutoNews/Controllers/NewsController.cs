using AutoNews.DB;
using Microsoft.AspNetCore.Mvc;

namespace AutoNews.Controllers;

public class NewsController : Controller
{
    private readonly AutoNewsContext _dataContext;

    public NewsController(AutoNewsContext dataContext) =>
        _dataContext = dataContext;

    public IActionResult Index(int newsId) =>
        _dataContext.News.FirstOrDefault(n => n.Id == newsId) is not { } news
            ? BadRequest()
            : View(new NewsModel
            {
                User = HttpContext.Items["User"] as User,
                News = news,
                Comments = _dataContext.Comments
                    .Where(c => c.NewsId == newsId)
                    .Select(c => new BetterComment
                    {
                        Id = c.Id,
                        Writer = _dataContext.Users.FirstOrDefault(u => u.Id == c.WriterId),
                        News = _dataContext.News.FirstOrDefault(n => n.Id == c.NewsId),
                        Text = c.Text
                    }),
                UserLiked = (HttpContext.Items["User"] as User)?.Id is { } userId &&
                            _dataContext.Likes.Any(l => l.NewsId == newsId && l.WriterId == userId)
            });

    public readonly struct BetterComment
    {
        public int Id { get; init; }
        public User? Writer { get; init; }
        public News? News { get; init; }
        public string Text { get; init; }
    }


    public readonly struct NewsModel
    {
        public User? User { get; init; }
        public News News { get; init; }
        public IQueryable<BetterComment> Comments { get; init; }
        public bool UserLiked { get; init; }
    }
}
