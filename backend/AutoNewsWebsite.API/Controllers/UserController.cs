using System;
using AutoNewsWebsite.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoNewsWebsite.API.Controllers
{
    public class UserController : Controller
    {
        // [Authorize]
        [HttpPost]
        public IActionResult GetInfo(Guid id)
        {
            return Ok(UserLogic.Get(id));
        }

        [HttpPost]
        public IActionResult SetInfo(Guid id)
        {
            return Ok(UserLogic.Get(id));
        }
    }
}