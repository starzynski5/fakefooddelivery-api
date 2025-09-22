using fakefooddelivery_api.DTOs;

namespace fakefooddelivery_api.Interfaces
{
    public interface IAuthService
    {
        Task<RegisterResult> Register(RegisterRequest request);

        Task<LoginResult> Login(LoginRequest request);
    }
}
