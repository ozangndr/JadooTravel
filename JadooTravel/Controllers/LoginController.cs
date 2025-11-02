using JadooTravel.Services.UserServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            var result = await _userService.LoginAsync(username, password);
            if (result)
            {
                // Giriş başarılı
                return RedirectToAction("Index","Chart");
            }

            ViewBag.Message = "Kullanıcı adı veya şifre hatalı!";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string password)
        {
            var created = await _userService.RegisterAsync(username, password);
            ViewBag.Message = created ? "Kayıt başarılı!" : "Bu kullanıcı zaten var!";
            return View("Index");
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            // Cookie tabanlı kimlik doğrulama varsa:
            HttpContext.Session.Clear();

            // Default/Index sayfasına yönlendir
            return RedirectToAction("Index", "Default");
        }
    }
}
