using fakefooddelivery_api.DTOs;

namespace fakefooddelivery_api.Interfaces
{
    public interface IAdminService
    {
        Task<ServiceResult<String>> CreateRestaurant(NewRestaurantRequest request);
    }
}
