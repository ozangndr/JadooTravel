using Microsoft.AspNetCore.Mvc;
using JadooTravel.Services.TestimonialServices;
using System.Threading.Tasks;

namespace JadooTravel.ViewComponents
{
    public class _DefaultTestimonialComponentPartial(ITestimonialService _testimonialService) :ViewComponent
    {

        public async Task <IViewComponentResult> InvokeAsync()
        {
            var values =await _testimonialService.GetAllTestimonialAsync();
            return View(values);
        }
    }
}
