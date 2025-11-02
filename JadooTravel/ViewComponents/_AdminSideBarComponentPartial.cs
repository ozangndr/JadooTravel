using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.ViewComponents
{
    public class _AdminSideBarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
