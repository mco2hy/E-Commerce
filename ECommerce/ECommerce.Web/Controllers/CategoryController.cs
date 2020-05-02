using ECommerce.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("/yonetim/kategori/ekle/{id:int}")]
        public IActionResult Manage(int id)
        {
            Data.Entities.Category category = null;

            if (id != 0)
            {
                category = _unitOfWork.CategoryRepository.Get(id);
            }

            return View(category);
        }
    }
}