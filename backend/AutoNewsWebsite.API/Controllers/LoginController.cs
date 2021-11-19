using System;
using AutoNewsWebsite.BLL;
using AutoNewsWebsite.BLL.Entities;
using AutoNewsWebsite.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoNewsWebsite.API.Controllers
{
    // [ApiController, Route("[controller]")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            var user = new User() { Login = login, Password = password};
            if (UserLogic.IsExist(user))
            {
                if (UserLogic.IsCorrectInfo(user))
                {
                    return Ok("He He :)");
                }

                return Ok("Not he he 😠");
            }
            else
            {
                return Ok("User is not exist");
            }
        }
    }
}