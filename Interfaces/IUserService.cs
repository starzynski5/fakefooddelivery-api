using fakefooddelivery_api.DTOs;
using fakefooddelivery_api.Models;

namespace fakefooddelivery_api.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResult<Order>> CreateOrder(int userId, NewOrderRequest request);
    }
}
