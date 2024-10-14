using Microsoft.AspNetCore.Mvc;

namespace PortfolioWebsite.Controllers
{
    public class PhotoController : Controller
    {
        public IActionResult Upload()
        {
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
