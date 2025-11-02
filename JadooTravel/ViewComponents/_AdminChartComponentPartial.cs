using JadooTravel.Services.DestinationServices;
using JadooTravel.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace JadooTravel.ViewComponents
{
    public class _AdminChartComponentPartial(IDestinationService _destinationService,ITestimonialService _testimonialService) : ViewComponent
    {
        public async Task< IViewComponentResult> InvokeAsync()
        {
            var destinations = await _destinationService.GetAllDestinationAsync();
            var testimonial = await _testimonialService.GetAllTestimonialAsync();
            ViewBag.DestinationsList = destinations;
            ViewBag.CheapDestination = destinations.OrderBy(d => d.Price).FirstOrDefault();
            ViewBag.ExpensiveDestination = destinations.OrderByDescending(d => d.Price).FirstOrDefault();
            ViewBag.LastDestination = destinations.OrderByDescending(d => d.DestinationId).FirstOrDefault();
            ViewBag.LastFiveDestination=destinations.OrderByDescending(d => d.DestinationId).Take(5).ToList();
            ViewBag.LastFourTestimonial = testimonial.OrderBy(d => d.TestimonialId).Take(4).ToList();
            return View();
        }
    }
}
