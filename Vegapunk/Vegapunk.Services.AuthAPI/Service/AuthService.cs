using Vegapunk.Services.AuthAPI.Model;
using Vegapunk.Services.AuthAPI.Service.IService;

namespace Vegapunk.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AuthService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<ResponseDto> GenerateToken()
        {

            return new ResponseDto()
            {
                IsSuccess = true,
                Result = _jwtTokenGenerator.GenerateToken(),
                Message = string.Empty
            };
        }
    }
}
