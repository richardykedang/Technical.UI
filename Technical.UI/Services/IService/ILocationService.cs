using Technical.UI.Models;

namespace Technical.UI.Services.IService
{
    public interface ILocationService
    {
        Task<ResponseDto?> GetAllLocation();
        Task<ResponseDto?> CreateLocationAsync(LocationDto model);
    }
}
