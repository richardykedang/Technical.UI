using Technical.UI.Models;

namespace Technical.UI.Services.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);
        //Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
