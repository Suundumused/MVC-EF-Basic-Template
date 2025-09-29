using TutorialEntityFramework.Entities;


namespace TutorialEntityFramework.Repositories.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category?> GetByNameAsync(string name);
        Task<Category?> ListProductsByPopulatedCategory(int id);

        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
