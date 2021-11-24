using System;
using AutoNewsWebsite.BLL;
using AutoNewsWebsite.BLL.Entities;
using AutoNewsWebsite.DAL.Models;
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
        public ActionResult Register(string login, string password)
        {
            var user = new UserDTO() {Id = Guid.Empty, Login = login, Password = password};
            if (UserLogic.IsExist(user))
                return Ok("User is exist");
            UserLogic.Create(user);
            return Ok("User created");
        }
    }
}