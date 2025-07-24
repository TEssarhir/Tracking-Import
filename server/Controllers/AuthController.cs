using Microsoft.AspNetCore.Mvc;
using server.DTOs;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult<LoginResponse> Login(LoginRequest request)
        {
            try
            {
                var response = _authService.Login(request);
                return Ok(response);
            }
            catch
            {
                return Unauthorized("Email ou mot de passe incorrect");
            }
        }
    }
}
