using fakefooddelivery_api.DTOs;

namespace fakefooddelivery_api.Interfaces
{
    public interface IRestaurantService
    {
        public Task<ServiceResult<String>> CreateMeal(NewMealRequest request);
    }
}
