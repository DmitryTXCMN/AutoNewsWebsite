using AutoNewsWebsite.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoNewsWebsite.API.Controllers
{
    [ApiController, Route("[controller]")]
    public class RegisterController : Controller
    {
        [HttpPost]
        public ActionResult Register([FromForm] User user)
        {
            return Ok(user.ToString());
        }
    }
}