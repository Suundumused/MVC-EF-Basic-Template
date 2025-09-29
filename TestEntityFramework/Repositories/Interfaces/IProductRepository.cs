using TutorialEntityFramework.Entities;


namespace TutorialEntityFramework.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsWithCategoryAsync();
    }
}
