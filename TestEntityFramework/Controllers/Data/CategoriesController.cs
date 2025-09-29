using Microsoft.AspNetCore.Mvc;
using TutorialEntityFramework.Services;
using TutorialEntityFramework.Services.Interfaces;

namespace TutorialEntityFramework.Controllers.Data
{
    [Route("Data/ProductsByCategory")]
    public class CategoriesController : BaseController
    {
        private ICategoryService _categoryService;


        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            return View(await _categoryService.ListProductsByPopulatedCategory(id));
        }

        /*[HttpGet("Category/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _productService.GetByIdAsync(id));
        }*/
    }
}
