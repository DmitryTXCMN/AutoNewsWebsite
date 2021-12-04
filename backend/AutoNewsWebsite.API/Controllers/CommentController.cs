using System;
using AutoMapper;
using AutoNewsWebsite.API.Models;
using AutoNewsWebsite.BLL;
using AutoNewsWebsite.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoNewsWebsite.API.Controllers
{
    public class CommentController : Controller
    {
        private IMapper _mapper;
        public CommentController(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetById(Guid id) => Ok(CommentLogic.GetById(id));

        [HttpPost]
        public IActionResult Create([FromBody] CommentModel comment)
        {
            var commentDto = _mapper.Map<Comment>(comment);
            commentDto.Id = Guid.NewGuid();
            CommentLogic.Create(commentDto);
            return Ok("Nice");
        }
    }
}