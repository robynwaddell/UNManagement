using Microsoft.AspNetCore.Mvc;

namespace UNManagement.Controllers
{
    public class DiplomatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
