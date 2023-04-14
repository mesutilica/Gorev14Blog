using Gorev14Blog.Core.Entities;
using Gorev14Blog.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gorev14Blog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class PostsController : Controller
    {
        private readonly IService<Post> _service;
        private readonly IService<Category> _serviceCategory;

        public PostsController(IService<Post> service, IService<Category> serviceCategory)
        {
            _service = service;
            _serviceCategory = serviceCategory;
        }

        // GET: PostsController
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: PostsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostsController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: PostsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Post collection, IFormFile? Image)
        {
            try
            {
                string directory = Directory.GetCurrentDirectory() + "/wwwroot/Images/" + Image.FileName;
                using var stream = new FileStream(directory, FileMode.Create);
                await Image.CopyToAsync(stream);
                collection.Image = Image.FileName;
                await _service.AddAsync(collection);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");
                return View();
            }
        }

        // GET: PostsController/Edit/5
        public async Task<IActionResult> EditAsync(int id)
        {
            ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: PostsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Post collection, IFormFile? Image)
        {
            try
            {
                if (Image is not null)
                {
                    string directory = Directory.GetCurrentDirectory() + "/wwwroot/Images/" + Image.FileName;
                    using var stream = new FileStream(directory, FileMode.Create);
                    await Image.CopyToAsync(stream);
                    collection.Image = Image.FileName;
                }
                _service.Update(collection);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");
                return View();
            }
        }

        // GET: PostsController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: PostsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Post collection)
        {
            try
            {
                _service.Delete(collection);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
