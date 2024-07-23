using Technical.UI.Models;
using Technical.UI.Services.IService;
using Technical.UI.Utility;

namespace Technical.UI.Services
{
    public class BpkpService : IBpkpService
    {
        private readonly IBaseService _baseService;

        public BpkpService(IBaseService baseService)
        {
            this._baseService = baseService;
        }
        public async Task<ResponseDto?> CreateBpkpAsync(BpkpCreateDto model)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = model,
                Url = SD.LocationAPIBase + "/api/bpkp"
            });
        }

        public async Task<ResponseDto?> GetAllBpkp()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BpkpAPIBase + "/api/bpkp"
            });
        }
    }
}
