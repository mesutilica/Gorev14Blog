using Gorev14Blog.Core.Entities;
using Gorev14Blog.Service.Abstract;
using Gorev14Blog.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gorev14Blog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Post> _service;

        public HomeController(IService<Post> service)
        {
            _service = service;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}