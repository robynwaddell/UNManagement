using Microsoft.AspNetCore.Mvc;
using BLL;
using Entities.ViewModels;
using System.Collections.Generic;
using System.Linq;
using DAL;


namespace UNManagement.Controllers
{
    public class CountryAssemblyController : Controller
    {
        private readonly CountryAssemblyService _countryAssemblyService = new CountryAssemblyService();

        //public CountryAssemblyController(CountryAssemblyService countryAssemblyService)
        //{
        //    _countryAssemblyService = countryAssemblyService;
        //}

        public IActionResult Index()
        {
            var response = _countryAssemblyService.GetCountryDiplomatForAssembly();
            return View(response);
        }

        [HttpPost]
        public string UpdateCountryAssemblies([FromBody] Dictionary<int, List<int>> countryAssemblies)
        {
            var response = _countryAssemblyService.UpdateAssembly(countryAssemblies);
            return response;
        }

        [HttpPost]
        public IActionResult CreateCountryAssembly([FromBody] CountryAssemblyModel countryAssembly)
        {
            var response = _countryAssemblyService.CreateAssembly(countryAssembly);
            return View(response);
        }

        [HttpGet]
        public IActionResult GetCountryAssembly(int id)
        {
            var response = _countryAssemblyService.GetAssembly(id);
            return View(response);
        }

        [HttpPost]
        public IActionResult UpdateCountryAssembly([FromBody] CountryAssemblyModel countryAssembly)
        {
            var response = _countryAssemblyService.UpdateAssembly(countryAssembly);
            return View(response);
        }

        [HttpPost]
        public string DeleteCountryAssembly(int id)
        {
            var response = _countryAssemblyService.DeleteAssembly(id);
            return response;
        }

        // Action to display composite view
        public IActionResult CountryAssemblyResult()
        {
            var viewModelList = new List<CountryAssemblyResult>();

            // Retrieve data for countries and selected diplomats saved in the CountryAssembly view
            var countryAssemblies = _countryAssemblyService.GetCountryDiplomatForAssembly();
            foreach (var countryAssembly in countryAssemblies)
            {
                var viewModel = new CountryAssemblyResult
                {
                    CountryName = countryAssembly.CountryName,
                    SelectedDiplomats = countryAssembly.Diplomats.Where((d, i) => countryAssembly.Checked[i]).ToList()
                };
                viewModelList.Add(viewModel);
            }

            return View(viewModelList);
        }
    }
}
