using server.DTOs;

namespace server.Services
{
    public interface IAuthService
    {
        LoginResponse Login(LoginRequest request);
    }
}
