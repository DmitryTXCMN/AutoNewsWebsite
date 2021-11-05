using System;
using AutoNewsWebsite.BLL;
using AutoNewsWebsite.BLL.Models;
using AutoNewsWebsite.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoNewsWebsite.API.Controllers
{
    [ApiController, Route("[controller]")]
    public class LoginController : Controller
    {
        [HttpPost]
        public ActionResult Login([FromForm] User user)
        {
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