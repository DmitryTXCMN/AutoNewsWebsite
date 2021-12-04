using System;
using AutoMapper;
using AutoNewsWebsite.API.Models;
using AutoNewsWebsite.BLL;
using AutoNewsWebsite.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoNewsWebsite.API.Controllers
{
    public class UserInfoController : Controller
    {
        private IMapper _mapper;
        public UserInfoController(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetById(Guid id) => Ok(UserInfoLogic.GetById(id));

        [HttpPost]
        public IActionResult Create([FromBody] UserInfoModel userInfo)
        {
            var userInfoDto = _mapper.Map<UserInfo>(userInfo);
            userInfoDto.Id = Guid.NewGuid();
            UserInfoLogic.Create(userInfoDto);
            return Ok("Nice");
        }
    }
}