using fakefooddelivery_api.Models;

namespace fakefooddelivery_api.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
    }
}
