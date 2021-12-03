using System;
using AutoNewsWebsite.API.Models;
using AutoNewsWebsite.API.Services;
using AutoNewsWebsite.BLL;
using AutoNewsWebsite.BLL.Entities;
using AutoNewsWebsite.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AutoNewsWebsite.API.Controllers
{
    // [ApiController, Route("[controller]")]
    public class LoginController : Controller
    {
        
        private IConfiguration _config;    
    
        public LoginController(IConfiguration config)    
        {    
            _config = config;    
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]LoginModel loginModel)
        {
            IActionResult response = Unauthorized();

            var user = new UserDTO() {Id = Guid.Empty ,Login = loginModel.Login, Password = loginModel.Password};
            if (UserLogic.IsExist(user))
            {
                if (UserLogic.IsCorrectInfo(user))
                {
                    var tokenString = JwtLogic.GenerateJSONWebToken(user, _config); 
                    response = Ok(new { token = tokenString });
                }
            }

            Console.WriteLine($"{loginModel.Login} {loginModel.Password}");
            return response;
        }
    }
}