using fakefooddelivery_api.Data;
using fakefooddelivery_api.DTOs;
using fakefooddelivery_api.Interfaces;
using fakefooddelivery_api.Models;
using Microsoft.EntityFrameworkCore;

namespace fakefooddelivery_api.Services
{
    public class MealService : IMealService
    {
        public readonly FakeFoodDeliveryDbContext _context;

        public MealService(FakeFoodDeliveryDbContext context)
        {  
            _context = context; 
        }

        public async Task<List<MealWithCategoryNameDTO>> GetAllMeals()
        {
            List<MealWithCategoryNameDTO> meals = await _context.Meals
                .Select(m => new MealWithCategoryNameDTO
                {
                    Id = m.Id,
                    Name = m.Name,
                    Description = m.Description,
                    Price = m.Price,
                    CategoryName = m.Category.Name
                })
                .ToListAsync();

            return meals;
        }

        public async Task<ServiceResult<MealWithCategoryNameDTO>> GetMealById(int id)
        {
            MealWithCategoryNameDTO meal = await _context.Meals
                .Where(m => m.Id == id)
                .Select(m => new MealWithCategoryNameDTO
                {
                    Id = m.Id,
                    Name = m.Name,
                    Description = m.Description,
                    Price = m.Price,
                    CategoryName = m.Category.Name
                })
                .FirstOrDefaultAsync();

            if (meal == null)
            {
                return ServiceResult<MealWithCategoryNameDTO>.Fail("Meal not found.");
            }

            return ServiceResult<MealWithCategoryNameDTO>.Ok(meal);
        }
    }
}
