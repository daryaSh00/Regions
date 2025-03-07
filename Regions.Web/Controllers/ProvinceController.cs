// Regions.Web/Controllers/ProvinceController.cs
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using Regions.Application.Common.Interfaces;
using Regions.Application.Constant;

namespace Regions.Web.Controllers
{
    public class ProvinceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProvinceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetProvince()
        {
            var provinces = _unitOfWork.Province.GetAll();
            return Json(new { data = provinces });
        }

        [HttpGet]
        public IActionResult CreateRandomProvinces()
        {
            try
            {
                _unitOfWork.Province.CreateRandomProvinces();
                _unitOfWork.Save();
                TempData["success"] = Message.successSave;
            }
            catch (Exception ex)
            {
                TempData["error"] = Message.failedSave + System.Environment.NewLine + ex?.InnerException.Message;
            }
            return RedirectToAction("Index");
        }

        public IActionResult RenameProvince(int id)
        {
            var province = _unitOfWork.Province.GetById(p => p.Id == id);
            if (province == null)
            {
                return NotFound();
            }
            try
            {
                _unitOfWork.Province.RenameProvince(province);
                _unitOfWork.Save();
                TempData["success"] = Message.successSave;
            }
            catch (Exception ex)
            {
                TempData["error"] = Message.failedSave + System.Environment.NewLine + ex?.InnerException.Message;
            }
            return RedirectToAction("Index");
        }
    }

}