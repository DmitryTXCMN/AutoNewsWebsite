using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoNewsWebsite.API.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoNewsWebsite.API.Models;
using AutoNewsWebsite.API.Services;
using Microsoft.AspNetCore.Http;

namespace AutoNewsWebsite.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public void Help()
        {
            Response.Headers.Add("Authorization","eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJuYmYiOjE2Mzc2OTU2NTMsImV4cCI6MTYzODMwMDQ1MywiaWF0IjoxNjM3Njk1NjUzfQ.cDi5Xm9L0ADohHDg4GtsGaOoeroEK91UVCmyPBRZs-4");
            //Response.WriteAsync(JwtLogic.GenerateJwtToken(1));
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}