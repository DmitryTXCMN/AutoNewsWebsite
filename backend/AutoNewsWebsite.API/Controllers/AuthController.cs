using System;
using AutoNewsWebsite.API.Models;
using AutoNewsWebsite.API.Services;
using AutoNewsWebsite.BLL;
using AutoNewsWebsite.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AutoNewsWebsite.API.Controllers
{
    public class AuthController : Controller
    {
        private IHashable _hash;
        private IConfiguration _config;

        public AuthController(IConfiguration config,IHashable hash)
        {
            _hash = hash;
            _config = config;
        }
        
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            IActionResult response = Unauthorized();

            var user = new UserDTO()
            {
                Id = Guid.Empty,
                Login = loginModel.Login,
                Password = _hash.Create(loginModel.Password)
            };

            if (UserLogic.IsExist(user))
            {
                if (UserLogic.IsCorrectInfo(user))
                {
                    var tokenString = JwtLogic.GenerateJSONWebToken(user, _config);
                    response = Ok(new {token = tokenString});
                }
            }

            
            //HttpContext.Response.Cookies.Append("Authorization", JwtLogic.GenerateJSONWebToken(user, _config));
            Console.WriteLine($"{loginModel.Login} {loginModel.Password}");
            return response;
        }
        
        [AllowAnonymous]
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

            //HttpContext.Response.Cookies.Append("Authorization", JwtLogic.GenerateJSONWebToken(user, _config));
            
            if (UserLogic.IsExist(user))
                return Ok("User is exist");
            UserLogic.Create(user);
            return Ok("User created");
        }
    }
}