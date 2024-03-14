using Microsoft.AspNetCore.Mvc;

namespace UNManagement.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
