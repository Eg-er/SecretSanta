using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Models;
using SecretSanta.Services;
using SecretSanta.Services.Interfaces;

namespace SecretSanta.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly IUserService _service;

        public HomeController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> Get()
        {
            var users = await _service.GetAllAsync();
            return users;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(user);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}