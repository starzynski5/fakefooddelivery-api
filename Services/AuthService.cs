using fakefooddelivery_api.Data;
using fakefooddelivery_api.DTOs;
using fakefooddelivery_api.Interfaces;
using fakefooddelivery_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fakefooddelivery_api.Services
{
    public class AuthService : IAuthService
    {
        public readonly FakeFoodDeliveryDbContext _context;
        public readonly JwtService _jwtService;

        public AuthService(FakeFoodDeliveryDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<RegisterResult> Register(RegisterRequest request)
        {
            var user = await _context.Users
                .Where(u => u.Email == request.Email)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                return new RegisterResult { Success = false, ErrorMessage = "User with this email already exists." };
            }

            User newUser = new User();

            newUser.Email = request.Email;
            newUser.Name = request.Name;
            newUser.Password = request.Password;

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return new RegisterResult { Success = true, Token = _jwtService.GenerateToken(newUser) };
        }

        public async Task<LoginResult> Login(LoginRequest request)
        {
            var user = await _context.Users
                .Where(u => u.Email == request.Email)
                .FirstOrDefaultAsync();

            if (user == null || user.Password != request.Password) return new LoginResult { Success = false, ErrorMessage = "Wrong email or password." };

            return new LoginResult { Success = true, Token = _jwtService.GenerateToken(user) };
        }

    }
}
