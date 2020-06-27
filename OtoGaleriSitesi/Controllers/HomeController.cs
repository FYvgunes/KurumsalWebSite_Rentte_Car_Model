using Microsoft.AspNetCore.Mvc;

namespace OtoGaleriSitesi.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}