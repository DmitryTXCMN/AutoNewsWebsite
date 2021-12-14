using System;
using AutoMapper;
using AutoNewsWebsite.API.Models;
using AutoNewsWebsite.BLL;
using AutoNewsWebsite.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoNewsWebsite.API.Controllers
{
    public class AutomobileController : Controller
    {
        private IMapper _mapper;
        public AutomobileController(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetById(Guid id) => Ok(AutomobileLogic.GetById(id));

        [HttpPost]
        public IActionResult Create([FromBody] AutomobileModel automobile)
        {
            var automobileDto = _mapper.Map<Automobile>(automobile);
            automobileDto.Id = Guid.NewGuid();
            AutomobileLogic.Create(automobileDto);
            return Ok("Nice");
        }
    }
}