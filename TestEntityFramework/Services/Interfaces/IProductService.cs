using TutorialEntityFramework.Entities;
using TutorialEntityFramework.ViewModels;


namespace TutorialEntityFramework.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);

        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);

        Task<ProductViewModel> GetViewModelAsync(int? id = null);
        //Task SaveViewModelAsync(ProductViewModel vm);
    }
}
