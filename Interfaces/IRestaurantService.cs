using fakefooddelivery_api.DTOs;
using fakefooddelivery_api.Models;

namespace fakefooddelivery_api.Interfaces
{
    public interface IRestaurantService
    {
        public Task<ServiceResult<String>> CreateMeal(NewMealRequest request);

        public Task<ServiceResult<String>> RestaurantChangeName(RestaurantChangeNameRequest request);

        public Task<ServiceResult<String>> EditMeal(EditMealRequest request);

        public Task<ServiceResult<String>> DeleteMeal(int id);

        public Task<ServiceResult<List<Order>>> GetAllOrders(int restaurantId);

        public Task<ServiceResult<String>> AcceptOrder(int id);

        public Task<ServiceResult<String>> RejectOrder(int id);

        public Task<ServiceResult<String>> DeliveredOrder(int id);
    }
}
