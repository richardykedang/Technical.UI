using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Technical.UI.Models;
using Technical.UI.Services;
using Technical.UI.Services.IService;

namespace Technical.UI.Controllers
{
    public class BpkpController : Controller
    {
        private readonly IBpkpService _bpkpService;
        private readonly ILocationService _locationService;

        public BpkpController(IBpkpService bpkpService, ILocationService locationService)
        {
            this._bpkpService = bpkpService;
            this._locationService = locationService;
        }
        public async Task<IActionResult> List()
        {
            List<BpkpDto>? data = new();
            ResponseDto? response = await _bpkpService.GetAllBpkp();
            if (response != null && response.IsSuccess)
            {
                data = JsonConvert.DeserializeObject<List<BpkpDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(data);
        }
        
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // Mendapatkan daftar lokasi
            var response = await _locationService.GetAllLocation();
            if (response?.IsSuccess == true)
            {
                var locations = JsonConvert.DeserializeObject<List<LocationDto>>(Convert.ToString(response.Result));
                ViewBag.Locations = locations.Select(x => new SelectListItem
                {
                    Text = x.locationName,
                    Value = x.LocationId
                }).ToList();
            }
            else
            {
                ViewBag.Locations = new List<SelectListItem>();
                TempData["error"] = response?.Message ?? "Failed to load locations.";
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(BpkpCreateDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _bpkpService.CreateBpkpAsync(model);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Bpkp Created Successfully";
                    return RedirectToAction(nameof(List)); // Redirect ke halaman lain jika diperlukan
                }
                else
                {
                    TempData["error"] = response?.Message ?? "Failed to create Bpkp";
                }
            }

            // Jika model tidak valid, reload lokasi
            var locationResponse = await _locationService.GetAllLocation();
            if (locationResponse?.IsSuccess == true)
            {
                var locations = JsonConvert.DeserializeObject<List<LocationDto>>(Convert.ToString(locationResponse.Result));
                ViewBag.Locations = locations.Select(x => new SelectListItem
                {
                    Text = x.locationName,
                    Value = x.LocationId
                }).ToList();
            }
            else
            {
                ViewBag.Locations = new List<SelectListItem>();
                TempData["error"] = locationResponse?.Message ?? "Failed to load locations.";
            }

            return View(model);
        }
    }
}
