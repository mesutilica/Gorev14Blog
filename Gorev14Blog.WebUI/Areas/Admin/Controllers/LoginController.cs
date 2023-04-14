using Microsoft.AspNetCore.Mvc;

namespace Gorev14Blog.WebUI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
