using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Technical.UI.Models;
using Technical.UI.Services.IService;

namespace Technical.UI.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            this._locationService = locationService;
        }
        public async Task<IActionResult> List()
        {
            List<LocationDto>? data = new();
            ResponseDto? response = await _locationService.GetAllLocation();
            if (response != null && response.IsSuccess)
            {
                data = JsonConvert.DeserializeObject<List<LocationDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(data);
        }

        public async Task<IActionResult> Create(LocationDto model)
        {

            if (ModelState.IsValid)
            {
                ResponseDto? response = await _locationService.CreateLocationAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Location created successfully";
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    TempData["error"] = response?.Message ?? "Failed to create location.";
                }
            }
            return View(model);
        }


    }
}
