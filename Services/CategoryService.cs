using System.Collections.Generic;
using fakefooddelivery_api.Data;
using fakefooddelivery_api.DTOs;
using fakefooddelivery_api.Interfaces;
using fakefooddelivery_api.Models;
using Microsoft.EntityFrameworkCore;

namespace fakefooddelivery_api.Services
{
    public class CategoryService : ICategoryService
    {
        public readonly FakeFoodDeliveryDbContext _context;
        public CategoryService(FakeFoodDeliveryDbContext context) { 
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            List<Category> categories = await _context.Categories.ToListAsync();

            return categories;
        }
    }
}
