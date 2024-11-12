using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Photolio.Data;
using PortfolioWebsite.Models;
using Microsoft.AspNetCore.Identity;
using PortfolioWebsite.Areas.Identity.Data;

namespace PortfolioWebsite.Controllers
{
    public class PhotoController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _environment;
        
        private readonly IHttpContextAccessor _contextAccessor;

        private readonly UserManager<PhotolioUser> _userManager;

        public PhotoController(ApplicationDbContext context, IWebHostEnvironment Environment, IHttpContextAccessor contextAccessor, UserManager<PhotolioUser> userManager)
        { 
            _context = context;
            _environment = Environment;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Upload()
        {
            PhotolioUser user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                return View();
            }
            else
            {
                TempData["message"] = "You need to log in to Upload photos!";
                ViewBag.Message = TempData["message"];
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> postedFiles)
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

            // Gets current user
            PhotolioUser user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                string userId = user.Id;
            }
            else
            {
                TempData["message"] = "You need to log in to Upload photos!";
                ViewBag.Message = TempData["message"];
                return View();
            }

            // For each file posted on the Upload page
            foreach (IFormFile postedFile in postedFiles)
            {
                // Creates the name of the current file
                string fileName = Path.GetFileName(postedFile.FileName);

                // Add the file to the database as a path, AND to the user's UploadedPhotos list
                // This also puts the current user's PhotolioUserId into the photo object
                Photo photo = new Photo();
                photo.PhotoPath = fileName;
                user.UploadedPhotos.Add(photo);
                await _context.SaveChangesAsync();

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
