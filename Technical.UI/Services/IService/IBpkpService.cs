using Technical.UI.Models;

namespace Technical.UI.Services.IService
{
    public interface IBpkpService
    {
        Task<ResponseDto?> GetAllBpkp(bool isLoggedInUser = false);
        Task<ResponseDto?> CreateBpkpAsync(BpkpCreateDto model);
    }
}
