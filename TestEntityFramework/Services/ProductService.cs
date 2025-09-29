using Microsoft.AspNetCore.Mvc.Rendering;
using TutorialEntityFramework.Entities;
using TutorialEntityFramework.Repositories.Interfaces;
using TutorialEntityFramework.Services.Interfaces;
using TutorialEntityFramework.ViewModels;


namespace TutorialEntityFramework.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;


        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository) 
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() 
        {
            return await _productRepository.GetProductsWithCategoryAsync();
        }

        public async Task<Product?> GetByIdAsync(int id) 
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Product product) 
        {
            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product) 
        {
            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id) 
        {
            await _productRepository.DeleteAsync(id);
            await _productRepository.SaveChangesAsync();
        }

        public async Task<ProductViewModel> GetViewModelAsync(int? id = null)
        {
            ProductViewModel? vm = new ProductViewModel();

            if (id is not null) 
            {
                Product? vma = await _productRepository.GetByIdAsync((int)id);

                if (vma is not null) 
                {
                    vm.Id = vma.Id;
                    vm.Name = vma.Name;
                    vm.Price = vma.Price;
                    vm.CategoryId = vma.CategoryId;
                    vm.Description = vma.Description;
                }
            }

            vm.Categories = (await _categoryRepository.GetAllAsync()).Select(c => new SelectListItem 
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });

            return vm;
        }

        /*public async Task SaveViewModelAsync(ProductViewModel vm)
        {
            await _productRepository.SaveChangesAsync();
        }*/
    }
}
