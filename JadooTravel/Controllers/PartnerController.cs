
using JadooTravel.Dtos.PartnerDtos;
using JadooTravel.Services.PartnerServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers
{
    public class PartnerController : Controller
    {
        private readonly IPartnerService _partnerService;

        public PartnerController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }


        public async Task<IActionResult> PartnerList()
        {
            var values = await _partnerService.GetAllPartnerAsync();
            return View(values);
        }

        [HttpGet]

        public IActionResult CreatePartner()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreatePartner(CreatePartnerDto createPartnerDto)
        {
            await _partnerService.CreatePartnerAsync(createPartnerDto);
            return RedirectToAction("PartnerList");
        }

        public async Task<IActionResult> DeletePartner(string id)
        {
            await _partnerService.DeletePartnerAsync(id);
            return RedirectToAction("PartnerList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePartner(string id)
        {
            var value = await _partnerService.GetPartnerByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePartner(UpdatePartnerDto updatePartnerDto)
        {
            await _partnerService.UpdatePartnerAsync(updatePartnerDto);
            return RedirectToAction("PartnerList");
        }
    }
}
