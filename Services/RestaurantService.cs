using fakefooddelivery_api.Data;
using fakefooddelivery_api.DTOs;
using fakefooddelivery_api.Interfaces;
using fakefooddelivery_api.Models;
using Microsoft.EntityFrameworkCore;

namespace fakefooddelivery_api.Services
{
    public class RestaurantService : IRestaurantService
    {
        public readonly FakeFoodDeliveryDbContext _context;

        public RestaurantService(FakeFoodDeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult<String>> CreateMeal(NewMealRequest request)
        {
            Category category = await _context.Categories
                .Where(c => c.Id == request.CategoryId)
                .FirstOrDefaultAsync();

            Restaurant restaurant = await _context.Restaurants
                .Where(r => r.Id == request.RestaurantId)
                .FirstOrDefaultAsync();

            if (category == null || restaurant == null) return ServiceResult<String>.Fail("Error, please try again.");

            Meal meal = new Meal();
            meal.Name = request.Name;
            meal.Description = request.Description;
            meal.Price = request.Price;
            meal.Category = category;
            meal.Restaurant = restaurant;

            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();

            return ServiceResult<String>.Ok("Meal created.");
        }

        public async Task<ServiceResult<String>> RestaurantChangeName(RestaurantChangeNameRequest request)
        {
            Restaurant restaurant = await _context.Restaurants
                .Where(r => r.Id == request.RestaurantId)
                .FirstOrDefaultAsync();

            if (restaurant == null) return ServiceResult<String>.Fail("Failed. Please try again.");

            restaurant.Name = request.NewName;

            await _context.SaveChangesAsync();

            return ServiceResult<String>.Ok("Restaurant's name has been changed.");
        }

        public async Task<ServiceResult<String>> EditMeal(EditMealRequest request)
        {
            Meal meal = await _context.Meals
                .Where(m => m.Id == request.MealId)
                .FirstOrDefaultAsync();

            if (meal == null) return ServiceResult<String>.Fail("Meal with this id was not found.");

            meal.Id = meal.Id;
            meal.Name = request.NewName;
            meal.Description = request.NewDescription;
            meal.Price = request.NewPrice;
            meal.Category = meal.Category;
            meal.Restaurant = meal.Restaurant;

            await _context.SaveChangesAsync();

            return ServiceResult<String>.Ok("Meal data updated.");
        }
    }
}
