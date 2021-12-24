using System;
using AutoNewsWebsite.BLL;
using AutoNewsWebsite.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoNewsWebsite.API.Controllers
{
    public class UserController : Controller
    {
        // [Authorize]
        [HttpPost]
        public IActionResult Get(Guid id)
        {
            return Ok(UserLogic.Get(id));
        }

        [HttpPost]
        public IActionResult Update([FromBody]UserDTO user)
        {
            UserLogic.Update(user);
            return Ok();
        }
    }
}