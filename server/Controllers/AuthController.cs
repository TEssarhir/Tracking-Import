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
                response.Role = response.Role; // Correction appliquée ici
                return Ok(response);
            }
            catch
            {
                return Unauthorized("Email ou mot de passe incorrect");
            }
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            try
            {
                _authService.Register(request);
                return Ok(new { message = "Utilisateur enregistré avec succès" });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Une erreur s'est produite lors de l'enregistrement de l'utilisateur" });
            }
        }
    }
}
