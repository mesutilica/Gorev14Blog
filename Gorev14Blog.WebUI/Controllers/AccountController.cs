using Gorev14Blog.Core.Entities;
using Gorev14Blog.Service.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Gorev14Blog.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IService<AppUser> _service;

        public AccountController(IService<AppUser> service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(string email, string password)
        {
            try
            {
                var kullanici = await _service.GetAsync(x => x.Email == email && x.Password == password && x.IsActive);
                if (kullanici is null)
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Giriş Başarısız!</div>";
                }
                else
                {
                    var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, kullanici.Email),
                    new Claim("Role", kullanici.IsAdmin ? "Admin" : "User"),
                    new Claim("UserGuid", kullanici.UserGuid.ToString())
                };
                    var userIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return Redirect(kullanici.IsAdmin ? "/Admin" : "/");
                }
            }
            catch (Exception)
            {
                TempData["Message"] = "<div class='alert alert-danger'>Hata Oluştu!</div>";
            }
            return View();
        }
        [Route("Logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
