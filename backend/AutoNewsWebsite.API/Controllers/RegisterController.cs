using AutoNewsWebsite.BLL;
using AutoNewsWebsite.BLL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AutoNewsWebsite.API.Controllers
{
    // [ApiController, Route("[controller]")]
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Register([FromForm] User user)
        {
            if (UserLogic.IsExist(user))
                return Ok("User is exist");
            UserLogic.Create(user);
            return Ok("User created");
        }
    }
}