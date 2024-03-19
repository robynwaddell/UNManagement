using BLL;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UNManagement.Controllers
{
    public class DiplomatController : Controller
    {
        DiplomatService diplomatService = new DiplomatService();
        CountryService countryService = new CountryService();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetDiplomats()
        {
            var response = diplomatService.GetDiplomatsService();
            return Json(response);
        }

        [HttpPost]
        public IActionResult RegisterDiplomat([FromBody] Diplomat diplomatFormData)
        {
            var response = diplomatService.RegisterDiplomatService(diplomatFormData);
            return Json(response); // Return the response from the service directly
        }



        [HttpPost]
        public IActionResult UpdateDiplomat([FromBody] Diplomat diplomat)
        {
            var updatedDiplomat = diplomatService.UpdateDiplomatService(diplomat);
            return Json(updatedDiplomat);
        }

        [HttpPost]
        public IActionResult DeleteDiplomat(int id)
        {
            if(diplomatService.DeleteDiplomatService(id))
            {
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpGet]
        public IActionResult GetDiplomatById(int id)
        {
            var diplomat = diplomatService.GetDiplomatByIdService(id);
            if (diplomat != null)
            {
                return Json(diplomat);
            }
            else
            {
                return Json(null); // Return null if diplomat is not found
            }
        }



    }
}
