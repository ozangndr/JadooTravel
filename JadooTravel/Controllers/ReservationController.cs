using JadooTravel.Dtos.ReservationDtos;
using JadooTravel.Services.ReservationServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task<IActionResult> ReservationList()
        {
            var values = await _reservationService.GetAllReservationAsync();
            return View(values);
        }

        [HttpGet]

        public IActionResult CreateReservation()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateReservation(CreateReservationDto createReservationDto)
        {
            
            await _reservationService.CreateReservationAsync(createReservationDto);
            return RedirectToAction("ReservationList");
        }

        public async Task<IActionResult> DeleteReservation(string id)
        {
            await _reservationService.DeleteReservationAsync(id);
            return RedirectToAction("ReservationList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateReservation(string id)
        {
            var value = await _reservationService.GetReservationByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateReservation(UpdateReservationDto updateReservationDto)
        {
            await _reservationService.UpdateReservationAsync(updateReservationDto);
            return RedirectToAction("ReservationList");
        }
    }
}
