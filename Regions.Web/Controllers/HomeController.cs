// Regions.Web/Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;
using Regions.Application.Common.Interfaces;
using Regions.Web.Models;
using Regions.Web.ViewModel;
using System.Diagnostics;

namespace Regions.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                ProvinceCount = _unitOfWork.Province.GetAll().Count(),
                CityCount = _unitOfWork.City.GetAll().Count(),
                DistrictCount = _unitOfWork.District.GetAll().Count(),
                RecentProvinces = _unitOfWork.Province.GetAll(includeProperties: "Cities")
                    .OrderByDescending(p => p.Id)
                    .Take(5)
                    .ToList() 
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}