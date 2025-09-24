using fakefooddelivery_api.DTOs;

namespace fakefooddelivery_api.Interfaces
{
    public interface IMealService
    {
        Task<List<MealWithCategoryNameDTO>> GetAllMeals();

        Task<ServiceResult<MealWithCategoryNameDTO>> GetMealById(int id);
    }
}
