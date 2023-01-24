using bitfit.DAL.IConfiguration;
using bitfit.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace bitfit.Controller
{
    [ApiController, Route("/recipe")]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public RecipeController(IUnitOfWork unitOfWork, ILogger<RecipeController> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Recipes.AddAsync(recipe);
                await _unitOfWork.CompleteAsync();

                return Ok(recipe);
            }

            return new JsonResult("You aint cooking this meal son.") { StatusCode = 500 };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var recipe = await _unitOfWork.Recipes.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var recipes = await _unitOfWork.Recipes.GetAllAsync();
            return Ok(recipes);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(long id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }

            await _unitOfWork.Recipes.UpdateAsync(recipe);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("/recipe/delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var recipe = await _unitOfWork.Foods.GetByIdAsync(id);
            if (recipe == null)
            {
                return BadRequest();
            }

            await _unitOfWork.Recipes.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return Ok(id);
        }
    }
}
