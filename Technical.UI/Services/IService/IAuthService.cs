using Technical.UI.Models;

namespace Technical.UI.Services.IService
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
       
    }
}
