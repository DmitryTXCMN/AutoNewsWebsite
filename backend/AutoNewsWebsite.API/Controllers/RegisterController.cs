using System;
using System.Security.Cryptography;
using System.Text;
using AutoNewsWebsite.API.Models;
using AutoNewsWebsite.API.Services;
using AutoNewsWebsite.BLL;
using AutoNewsWebsite.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoNewsWebsite.API.Controllers
{
    // [ApiController, Route("[controller]")]
    public class RegisterController : Controller
    {
        private IHashable _hash;

        public RegisterController(IHashable hash)
        {
            _hash = hash;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register([FromBody] LoginModel loginModel)
        {
            var uniqueGuid = new Guid(_hash.Create(loginModel.Login));
            var user = new UserDTO()
            {
                Id = uniqueGuid,
                Login = loginModel.Login,
                Password = _hash.Create(loginModel.Password)
            };

            if (UserLogic.IsExist(user))
                return Ok("User is exist");
            UserLogic.Create(user);
            return Ok("User created");
        }
    }
}