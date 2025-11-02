using JadooTravel.Services.PartnerServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.ViewComponents
{
    public class _DefaultPartnerComponentPartial(IPartnerService _partnerService): ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var partners = await _partnerService.GetAllPartnerAsync();
            return View(partners);
        }
    }
}
