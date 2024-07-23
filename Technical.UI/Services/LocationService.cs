using Technical.UI.Models;
using Technical.UI.Services.IService;
using Technical.UI.Utility;

namespace Technical.UI.Services
{
    public class LocationService : ILocationService
    {
        private readonly IBaseService _baseService;

        public LocationService(IBaseService baseService)
        {
            this._baseService = baseService;
        }

        public async Task<ResponseDto?> CreateLocationAsync(LocationDto model)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = model,
                Url = SD.LocationAPIBase + "/api/location"
            });

        }

        public async Task<ResponseDto?> GetAllLocation()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.LocationAPIBase + "/api/location"
            });

        }
    }
}
