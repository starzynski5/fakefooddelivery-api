using fakefooddelivery_api.Data;
using fakefooddelivery_api.DTOs;
using fakefooddelivery_api.Interfaces;
using fakefooddelivery_api.Models;
using Microsoft.EntityFrameworkCore;

namespace fakefooddelivery_api.Services
{
    public class UserService : IUserService
    {
        public readonly FakeFoodDeliveryDbContext _context;

        public UserService(FakeFoodDeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult<Order>> CreateOrder(int userId, NewOrderRequest request)
        {
            User user = await _context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            Restaurant restaurant = await _context.Restaurants
                .Where(r =>  r.Id == request.RestaurantId)
                .FirstOrDefaultAsync();

            Meal meal = await _context.Meals
                .Where(m => m.Id == request.MealId)
                .FirstOrDefaultAsync();

            if (user == null || restaurant == null || meal == null) return ServiceResult<Order>.Fail("Something went wrong. Please try again.");

            Order order = new Order();

            order.Restaurant = restaurant;
            order.Meal = meal;
            order.Client = user;

            order.RestaurantId = request.RestaurantId;
            order.ClientId = userId;
            order.MealId = meal.Id;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return ServiceResult<Order>.Ok(order);
        }

        public async Task<ServiceResult<Order>> GetOrderById(int id)
        {
            Order order = await _context.Orders
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            if (order == null) return ServiceResult<Order>.Fail("Failed. Please try again.");

            return ServiceResult<Order>.Ok(order);
        }
    }
}
