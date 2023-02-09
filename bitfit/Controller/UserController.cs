using bitfit.DAL.IServices;
using bitfit.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bitfit.Controller
{
    [Authorize]
    [ApiController, Route("/user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Create([FromForm]User user)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddAsync(user);
                return Redirect("https://localhost:44447/login");    
            }

            return new JsonResult("Invalid User") { StatusCode = 500 };
        }

        [HttpGet("/users/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByGuid(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("/users")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpPost("/user/edit/{id}")]
        public async Task<IActionResult> Update(Guid id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userService.UpdateAsync(user);

            return NoContent();
        }

        [HttpDelete("/user/delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }

            await _userService.DeleteAsync(id);
            return Ok(id);
        }
    }
}
