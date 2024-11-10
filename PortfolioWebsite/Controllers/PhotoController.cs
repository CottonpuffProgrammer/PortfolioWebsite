using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Photolio.Data;
using PortfolioWebsite.Models;

namespace PortfolioWebsite.Controllers
{
    public class PhotoController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _environment;

        public PhotoController(ApplicationDbContext context, IWebHostEnvironment Environment)
        { 
            _context = context;
            _environment = Environment;
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(List<IFormFile> postedFiles)
        {
            string wwwPath = this._environment.WebRootPath;
            string contentPath = this._environment.ContentRootPath;

            string path = Path.Combine(this._environment.WebRootPath, "images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                    ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                }
            }

            return View();
        }

        public IActionResult ViewPhotos()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
