using fakefooddelivery_api.Data;
using fakefooddelivery_api.Interfaces;

namespace fakefooddelivery_api.Services
{
    public class UserService : IUserService
    {
        public readonly FakeFoodDeliveryDbContext _context;

        public UserService(FakeFoodDeliveryDbContext context)
        {
            _context = context;
        }
    }
}
