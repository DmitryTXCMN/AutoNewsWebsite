using System;
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
            return Ok(user.ToString());
        }
    }
}