using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Points.Application.Interfaces;
using Points.Domain.Entities;
using Points.Domain.ViewModels;

namespace Points.UI.Controllers
{
    public class PointsController : Controller
    {
        private readonly IDotRepository _dotRepository;
        public PointsController(IDotRepository dotRepository)
        {
            _dotRepository = dotRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetDots()
        {
            var dots = await _dotRepository.GetAllDots();
            return Json(dots);
        }

        [HttpPost]
        public async Task<JsonResult> Create(DotViewModel model)
        {
            var result = await _dotRepository.CreateDot(model);
            return Json(model);
        }

        [HttpDelete]
        public async Task<JsonResult> Delete(int dotId)
        {
            var result = await _dotRepository.RemoveDot(dotId);
            return Json(result);
        }
    }
}