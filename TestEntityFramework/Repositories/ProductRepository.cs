using Microsoft.EntityFrameworkCore;
using TutorialEntityFramework.Data;
using TutorialEntityFramework.Entities;
using TutorialEntityFramework.Repositories.Interfaces;


namespace TutorialEntityFramework.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsWithCategoryAsync()
        {
            return await _dbSet.Include(p => p.Category).ToListAsync();
        }
    }
}
