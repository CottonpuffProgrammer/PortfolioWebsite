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
            // Gets the necessary paths to add the files to the specified folder
            string wwwPath = this._environment.WebRootPath;
            string contentPath = this._environment.ContentRootPath;

            // Creates a path to the images folder in wwwroot
            string path = Path.Combine(this._environment.WebRootPath, "images");

            // If the image folder somehow doesn't exist, create it
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // Creates a list to temporarily track uploaded Files
            List<string> uploadedFiles = new List<string>();

            // For each file posted on the Upload page
            foreach (IFormFile postedFile in postedFiles)
            {
                // Creates the name of the current file
                string fileName = Path.GetFileName(postedFile.FileName);

                // Add the file to the image folder and return a success message
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
