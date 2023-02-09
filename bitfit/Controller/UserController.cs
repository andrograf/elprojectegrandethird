using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using bitfit.DAL.IServices;
using bitfit.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace bitfit.Controller
{
    [Authorize]
    [ApiController, Route("/user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly JWTSettings _jwtSettings;

        
        public UserController(IUserService userService, IOptions<JWTSettings> jwtsettings)
        {
            _jwtSettings = jwtsettings.Value;
            _userService = userService;
        }

        [HttpPost]
        [Route("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromForm]User user)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddAsync(user);
                return Redirect("https://localhost:44447/login");    
            }

            return new JsonResult("Invalid User") { StatusCode = 500 };
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Login([FromForm] User user)
        {
            var users = await _userService.GetAllAsync();
            user = users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            UserToken userWithToken = new UserToken(user);


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                }),
                Expires = DateTime.UtcNow.AddMonths(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userWithToken.AccessToken = tokenHandler.WriteToken(token);

            return userWithToken;
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

        [HttpPut("{id}")]
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
