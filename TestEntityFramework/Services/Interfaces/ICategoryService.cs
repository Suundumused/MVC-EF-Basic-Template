using TutorialEntityFramework.Entities;


namespace TutorialEntityFramework.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> ListProductsByPopulatedCategory(int id);
    }
}
