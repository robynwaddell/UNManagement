using Microsoft.AspNetCore.Mvc;

namespace UNManagement.Controllers
{
    public class AssemblyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
