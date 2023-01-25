using bitfit.DAL.IRepositories;
using bitfit.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace bitfit.Controller
{
    [ApiController, Route("/food")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService unitOfWork )
        {
            _foodService = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Food food)
        {
            if (ModelState.IsValid)
            {
                await _foodService.AddAsync(food);

                return Ok(food);
            }

            return new JsonResult("Invalid food properties maybe.?") { StatusCode = 500 };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(long id)
        {
            var food = await _foodService.GetByIdAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var foods = await _foodService.GetAllAsync();
            return Ok(foods);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(long id, Food food)
        {
            if (id != food.Id)
            {
                return BadRequest();
            }

            await _foodService.UpdateAsync(food);


            return NoContent();
        }

        [HttpDelete("/food/delete/{id}")]
        public async Task<IActionResult> DeleteRoom(long id)
        {
            var food = await _foodService.GetByIdAsync(id);
            if (food == null)
            {
                return BadRequest();
            }

            await _foodService.DeleteAsync(id);
            return Ok(id);
        }
    }
}
