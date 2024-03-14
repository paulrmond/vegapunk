using Vegapunk.FrontEnd.Shaka.Models;

namespace Vegapunk.FrontEnd.Shaka.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
