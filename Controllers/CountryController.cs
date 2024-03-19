using BLL;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
 
namespace UNManagement.Controllers
{
    public class CountryController : Controller
    {
        CountryService countryService = new CountryService();

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This action method gets all the countries from the Database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCountries()
        {
            var response = countryService.GetCountriesService();
            return Json(response);
        }

        /// <summary>
        /// This action method registers a new country for the assembly to the Database.
        /// </summary>
        /// <param name="countryFormData"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RegisterCountry([FromBody] Country countryFormData)
        {
            var response = countryService.RegisterCountryService(countryFormData);
            return Json(response);
        }

        /// <summary>
        /// This method updates a country in the Database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCountryById(int id)
        {
            var country = countryService.GetCountryByIdService(id);
            return Json(country);
        }

        /// <summary>
        /// This method returns a country based on country ID.
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateCountry([FromBody] Country country)
        {
            var countryUpdated = countryService.UpdateCountryService(country);
            return Json(countryUpdated);
        }

        /// <summary>
        /// This method deletes a country from the Database based on the country ID.
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteCountry(int id)
        {
            if (countryService.DeleteCountryService(id))
            {
                return Json(new { success = true });
            }
            return Json(new { success = false });
            //if (countryService.DeleteCountryService(countryId))
            //    return Json(null);
            //return Json(null);
        }
    }
}
