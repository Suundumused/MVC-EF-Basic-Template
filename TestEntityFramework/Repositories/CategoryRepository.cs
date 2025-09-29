using Microsoft.EntityFrameworkCore;
using TutorialEntityFramework.Data;
using TutorialEntityFramework.Entities;
using TutorialEntityFramework.Repositories.Interfaces;


namespace TutorialEntityFramework.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category?> GetByNameAsync(string name) 
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Category?> ListProductsByPopulatedCategory(int id) 
        {
            return await _context.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
