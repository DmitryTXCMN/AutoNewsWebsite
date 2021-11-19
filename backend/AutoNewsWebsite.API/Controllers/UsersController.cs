using AutoNewsWebsite.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoNewsWebsite.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : DbBaseController<Users>
    {}
}