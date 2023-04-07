using Gorev14Blog.Core.Entities;
using Gorev14Blog.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gorev14Blog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IService<AppUser> _service;

        public AppUsersController(IService<AppUser> service)
        {
            _service = service;
        }

        // GET: api/<AppUsersController>
        [HttpGet]
        public async Task<IEnumerable<AppUser>> GetAsync()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<AppUsersController>/5
        [HttpGet("{id}")]
        public async Task<AppUser> GetAsync(int id)
        {
            return await _service.FindAsync(id);
        }

        // POST api/<AppUsersController>
        [HttpPost]
        public async Task PostAsync([FromBody] AppUser value)
        {
            await _service.AddAsync(value);
            await _service.SaveAsync();
        }

        // PUT api/<AppUsersController>/5
        [HttpPut]
        public async Task PutAsync([FromBody] AppUser value)
        {
            _service.Update(value);
            await _service.SaveAsync();
        }

        // DELETE api/<AppUsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var kayit = await _service.FindAsync(id);
            if (kayit == null)
            {
                return NotFound();
            }
            _service.Delete(kayit);
            await _service.SaveAsync();
            return Ok();
        }
    }
}
