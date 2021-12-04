using System;
using System.Security.Cryptography;
using System.Text;
using AutoNewsWebsite.API.Models;
using AutoNewsWebsite.API.Services;
using AutoNewsWebsite.BLL;
using AutoNewsWebsite.BLL.Entities;
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
            Guid result = Guid.Empty;
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(loginModel.Login));
                result = new Guid(hash);
            }
            var user = new UserDTO() {
                Id = result, 
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