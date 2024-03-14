using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vegapunk.Services.AuthAPI.Model;
using Vegapunk.Services.AuthAPI.Service.IService;

namespace Vegapunk.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        protected ResponseDto responseDto;
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
            responseDto = new();
        }
        [HttpGet]
        [Route("GenerateToken")]
        public async Task<IActionResult> GenerateToken()
        {
            return Ok(await authService.GenerateToken());
        }
    }
}
