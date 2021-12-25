using AutoNews.Attributes;
using AutoNews.DB;
using Microsoft.AspNetCore.Mvc;

namespace AutoNews.Controllers;

public class BackController : Controller
{
    private readonly AutoNewsContext _dataContext;

    public BackController(AutoNewsContext dataContext) =>
        _dataContext = dataContext;

    [HttpPost, Authorize]
    public IActionResult EditProfile([FromForm] User user)
    {
        var currentUser = (HttpContext.Items["User"] as User)!;
        if (user.Age != default)
            currentUser.Age = user.Age;
        if (user.Login != string.Empty && user.Login != default)
            currentUser.Login = user.Login;
        if (user.Name != string.Empty && user.Name != default)
            currentUser.Name = user.Name;
        if (user.Password != string.Empty && user.Password != default)
            currentUser.Password = user.Password;
        if (user.AboutMe != string.Empty && user.AboutMe != default)
            currentUser.AboutMe = user.AboutMe;
        if (user.NickName != string.Empty && user.NickName != default)
            currentUser.NickName = user.NickName;
        if (user.AvatarUrl != string.Empty && user.AvatarUrl != default)
            currentUser.AvatarUrl = user.AvatarUrl;
        _dataContext.Update(currentUser);
        _dataContext.SaveChanges();
        return Ok();
    }

    [HttpPost, Authorize]
    public IActionResult DeleteComment([FromForm] int commentId)
    {
        var comment = _dataContext.Comments.FirstOrDefault(c => c.Id == commentId);
        if (comment == default) return BadRequest();
        _dataContext.Comments.Remove(comment);
        _dataContext.SaveChanges();
        return Ok();
    }

    [HttpPost, Authorize]
    public IActionResult SendComment([FromForm] Comment comment)
    {
        if (comment.WriterId == default || comment.NewsId == default) return BadRequest();
        _dataContext.Comments.Add(comment);
        _dataContext.SaveChanges();
        return Ok();
    }

    [HttpPost, Authorize]
    public IActionResult CreateNews(string title, string text, string logoUrl)
    {
        if (title == default || text == default || logoUrl == default) return BadRequest();
        _dataContext.News.Add(new News
        {
            Title = title,
            Text = text,
            LogoUrl = logoUrl,
            Likes = 0,
            Date = DateTime.Now,
            CreatorId = (HttpContext.Items["User"] as User)!.Id
        });
        _dataContext.SaveChanges();
        return Ok();
    }

    [HttpPost, Authorize]
    public IActionResult Like(int newsId)
    {
        var userId = (HttpContext.Items["User"] as User)!.Id;
        lock (_dataContext)
        {
            if (_dataContext.Likes.Any(l => l.NewsId == newsId && l.WriterId == userId)) return BadRequest();
            var news = _dataContext.News.FirstOrDefault(n => n.Id == newsId);
            if (news is null) return BadRequest();
            _dataContext.Likes.Add(new Like
            {
                WriterId = userId,
                NewsId = newsId
            });
            ++news.Likes;
            _dataContext.News.Update(news);
            _dataContext.SaveChanges();
        }

        return Ok();
    }

    [HttpPost, Authorize]
    public IActionResult UnLike(int newsId)
    {
        var userId = (HttpContext.Items["User"] as User)!.Id;
        lock (_dataContext)
        {
            var like = _dataContext.Likes.FirstOrDefault(l => l.NewsId == newsId && l.WriterId == userId);
            if (like is null) return BadRequest();
            _dataContext.Likes.Remove(like);
            var news = _dataContext.News.FirstOrDefault(n => n.Id == newsId);
            if (news is null)
            {
                _dataContext.SaveChanges();
                return BadRequest();
            }

            --news.Likes;
            _dataContext.News.Update(news);
            _dataContext.SaveChanges();
        }

        return Ok();
    }
}
