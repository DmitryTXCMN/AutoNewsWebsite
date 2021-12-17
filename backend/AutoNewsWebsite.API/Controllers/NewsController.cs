using System;
using AutoNewsWebsite.API.Models;
using AutoNewsWebsite.API.Services;
using AutoNewsWebsite.BLL;
using AutoNewsWebsite.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoNewsWebsite.API.Controllers
{
    public class NewsController : Controller
    {
        
        private IHashable _hash;

        public NewsController(IHashable hash)
        {
            _hash = hash;
        }
        
        [HttpGet]
        public IActionResult GetById(Guid id) => Ok(NewsLogic.GetById(id));
        
        [HttpGet]
        public IActionResult GetByIdFilter(Guid id, DateTime time) => Ok(NewsLogic.GetByIdFilter(id, time));

        [HttpPost]
        public IActionResult Create([FromBody] NewsModel news)
        {
            
            NewsLogic.Create(new News()
            {
                Id = Guid.NewGuid(),
                Content = news.Content,
                DateOfCreate = news.DateOfCreate,
                Head = news.Head
            });
            return Ok("Nice");
        }
    }
}