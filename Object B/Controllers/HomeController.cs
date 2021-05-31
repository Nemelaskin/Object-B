using Microsoft.AspNetCore.Mvc;

namespace Object_B.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
