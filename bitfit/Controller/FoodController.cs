using bitfit.DAL.IConfiguration;
using bitfit.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace bitfit.Controller
{
    [ApiController, Route("/food")]
    public class FoodController : ControllerBase
    {
        private readonly ILogger<FoodController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public FoodController(IUnitOfWork unitOfWork, ILogger<FoodController> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Food food)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Foods.AddAsync(food);
                await _unitOfWork.CompleteAsync();

                return Ok(food);
            }

            return new JsonResult("Invalid food properties maybe.?") { StatusCode = 500 };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(long id)
        {
            var food = await _unitOfWork.Foods.GetByIdAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var foods = await _unitOfWork.Foods.GetAllAsync();
            return Ok(foods);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(long id, Food food)
        {
            if (id != food.Id)
            {
                return BadRequest();
            }

            await _unitOfWork.Foods.UpdateAsync(food);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("/food/delete/{id}")]
        public async Task<IActionResult> DeleteRoom(long id)
        {
            var food = await _unitOfWork.Foods.GetByIdAsync(id);
            if (food == null)
            {
                return BadRequest();
            }

            await _unitOfWork.Foods.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return Ok(id);
        }
    }
}
