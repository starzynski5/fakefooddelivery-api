using fakefooddelivery_api.DTOs;
using fakefooddelivery_api.Models;

namespace fakefooddelivery_api.Interfaces
{
    public interface IAdminService
    {
        Task<ServiceResult<String>> CreateRestaurant(NewRestaurantRequest request);

        Task<ServiceResult<String>> CreateCategory(NewCategoryRequest request);

        Task<ServiceResult<List<Order>>> GetAllOrders();

        Task<ServiceResult<List<Order>>> GetOrdersOfRestaurant(int restaurantId);

        Task<ServiceResult<Order>> GetOrderById(int id);
    }
}
