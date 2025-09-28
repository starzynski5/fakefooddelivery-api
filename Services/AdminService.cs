using fakefooddelivery_api.Data;
using fakefooddelivery_api.DTOs;
using fakefooddelivery_api.Interfaces;
using fakefooddelivery_api.Models;
using Microsoft.EntityFrameworkCore;

namespace fakefooddelivery_api.Services
{
    public class AdminService : IAdminService
    {
        public readonly FakeFoodDeliveryDbContext _context;

        public AdminService(FakeFoodDeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult<String>> CreateRestaurant(NewRestaurantRequest request)
        {
            User user = await _context.Users
                .Where(u => u.Id == request.OwnerId)
                .FirstOrDefaultAsync();

            if (user == null) return ServiceResult<String>.Fail("User with this id doesn't exist.");

            Restaurant restaurant = new Restaurant(user.Id, user);

            restaurant.Name = request.Name;

            _context.Restaurants.Add(restaurant);
            user.Role = "OWNER";
            await _context.SaveChangesAsync();

            return ServiceResult<String>.Ok("Restaurant created.");
        }

        public async Task<ServiceResult<String>> CreateCategory(NewCategoryRequest request)
        {
            Category category = await _context.Categories
                .Where(c => c.Name == request.Name)
                .FirstOrDefaultAsync();

            if (category != null) return ServiceResult<String>.Fail("This category already exists.");

            Category newCategory = new Category();
            newCategory.Name = request.Name;

            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();

            return ServiceResult<String>.Ok("Category created.");
        }
    }
}
