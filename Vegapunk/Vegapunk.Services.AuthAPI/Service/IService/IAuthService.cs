using Vegapunk.Services.AuthAPI.Model;

namespace Vegapunk.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        public Task<ResponseDto> GenerateToken();
    }
}
