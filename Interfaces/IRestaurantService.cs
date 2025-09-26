using fakefooddelivery_api.DTOs;

namespace fakefooddelivery_api.Interfaces
{
    public interface IRestaurantService
    {
        public Task<ServiceResult<String>> CreateMeal(NewMealRequest request);

        public Task<ServiceResult<String>> RestaurantChangeName(RestaurantChangeNameRequest request);

        public Task<ServiceResult<String>> EditMeal(EditMealRequest request);

        public Task<ServiceResult<String>> DeleteMeal(int id);
    }
}
