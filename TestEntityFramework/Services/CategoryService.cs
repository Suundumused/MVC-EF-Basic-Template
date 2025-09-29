using TutorialEntityFramework.Entities;
using TutorialEntityFramework.Repositories;
using TutorialEntityFramework.Repositories.Interfaces;
using TutorialEntityFramework.Services.Interfaces;


namespace TutorialEntityFramework.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;


        public CategoryService(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetCategoriesAsync();
        }

        public async Task<Category?> ListProductsByPopulatedCategory(int id) 
        {
            return await _categoryRepository.ListProductsByPopulatedCategory(id);
        }
    }
}
