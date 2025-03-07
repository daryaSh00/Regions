using Microsoft.AspNetCore.Mvc;
using Regions.Application.Common.Interfaces;

namespace Regions.Web.Controllers
{
    public class DistrictController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DistrictController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetDistricts()
        {
            var districts = _unitOfWork.District.GetAll(includeProperties: "City,City.Province");
            var districtList = districts.Select(d => new
            {
                DistrictName = d.Name,
                CityName = d.City?.Name,
                ProvinceName = d.City?.Province?.Name
            });
            return Json(new { data = districtList });
        }
    }
}