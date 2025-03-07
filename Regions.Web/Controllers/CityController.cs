using Microsoft.AspNetCore.Mvc;
using Regions.Application.Common.Interfaces;

namespace Regions.Web.Controllers
{
    public class CityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            var cities = _unitOfWork.City.GetAll(includeProperties: "Province");
            var citiesLists = cities.Select(d => new
            {
                CityName = d.Name,
                ProvinceName = d.Province?.Name
            });
            return Json(new { data = citiesLists });
        }
    }
}
