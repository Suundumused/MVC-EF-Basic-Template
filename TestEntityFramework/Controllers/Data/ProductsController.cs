using Microsoft.AspNetCore.Mvc;
using TutorialEntityFramework.Entities;

using TutorialEntityFramework.Services.Interfaces;
using TutorialEntityFramework.ViewModels;


namespace TutorialEntityFramework.Controllers.Data
{
    [Route("Data/Products")]
    public class ProductsController : BaseController
    {
        private IProductService _productService;


        public ProductsController(IProductService productService) 
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAllAsync());
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _productService.GetByIdAsync(id));
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create() 
        {
            return View(await _productService.GetViewModelAsync());
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel vm)
        {
            if (ModelState.IsValid) 
            {
                await _productService.AddAsync(
                    new Product()
                    {
                        Id = vm.Id,
                        Name = vm.Name,
                        Price = vm.Price,
                        CategoryId = vm.CategoryId,
                        Description = vm.Description
                    }
                );

                return RedirectToAction("Products", "Data");
            }

            ViewBag.Error = "Required dada is missing";
            return View(vm);
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return View(id);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id) 
        {
            ProductViewModel? vm = await _productService.GetViewModelAsync(id);

            if (vm == null) 
            {
                return RedirectToAction("Products", "Data");
            }

            return View(vm);
        }

        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel vm) 
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(
                    new Product()
                    {
                        Id = vm.Id,
                        Name = vm.Name,
                        Price = vm.Price,
                        CategoryId = vm.CategoryId,
                        Description = vm.Description
                    }
                );

                return RedirectToAction("Products", "Data");
            }

            ViewBag.Error = "Required dada is missing";
            return View(vm);
        }

        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection _)
        {
            await _productService.DeleteAsync(id);

            return RedirectToAction("Products", "Data");
        }
    }
}
