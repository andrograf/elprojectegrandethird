using bitfit.DAL.IServices;
using bitfit.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace bitfit.Controller
{
    [ApiController, Route("/user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddAsync(user);

                return Ok(user);    
            }

            return new JsonResult("Invalid User") { StatusCode = 500 };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByGuid(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpPost("{id}")]
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
