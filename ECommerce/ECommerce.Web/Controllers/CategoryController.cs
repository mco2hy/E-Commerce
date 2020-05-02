using ECommerce.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

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
            return View(id);
        }

        [Route("/kategori/getir/{id:int}")]
        public IActionResult Get(int id)
        {
            var category = _unitOfWork.CategoryRepository.Get(id);

            return new JsonResult(category);
        }

        [Route("/kategori/kaydet")]
        public IActionResult Save([FromBody] Data.DTO.Category_Save_Request dto)
        {
            if (!ModelState.IsValid) return BadRequest("Kötü çocuk");

            if (dto.CategoryId == 0)
            {
                //yeni kayıt

                var menu = _unitOfWork.MenuRepository.Get(dto.MenuId);
                var parentCategory = _unitOfWork.CategoryRepository.Get(dto.ParentCategoryId);

                var category = new Data.Entities.Category()
                {
                    Active = true,
                    CreateDate = DateTime.UtcNow,
                    Menu = menu,
                    Name = dto.Name,
                    Parent = parentCategory
                };
            }
            else
            {
                //güncelleme
                var category = _unitOfWork.CategoryRepository.Get(dto.CategoryId);
            }

            return new JsonResult(category);
        }
    }
}