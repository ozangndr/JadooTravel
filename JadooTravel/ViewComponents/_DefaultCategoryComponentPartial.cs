using JadooTravel.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.ViewComponents
{
    public class _DefaultCategoryComponentPartial(ICategoryService _categoryService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {  
            var categories = await _categoryService.GetAllCategoryAsync();
            return View(categories); 
        }
    }
}
