using System.IO;
using AutoNewsWebsite.DAL;
using AutoNewsWebsite.DAL.Models;
using LinqToDB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoNewsWebsite.API.Controllers
{
    public class FileController : Controller
    {
        IWebHostEnvironment _appEnvironment;
 
        public FileController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }
        
        [HttpPost]
        public IActionResult AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/Files/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    uploadedFile.CopyToAsync(fileStream);
                }
                var file = new FileModel { Name = uploadedFile.FileName, Path = path };
                using var db = new DbRepository();

                db.Insert(file);
            }

            return Ok("Success");
        }
    }
}