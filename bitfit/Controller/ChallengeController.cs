using bitfit.DAL.IServices;
using bitfit.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace bitfit.Controller
{
    [ApiController, Route("/gantt")]
    public class ChallengeController : ControllerBase
    {
        private readonly IChallengeService _challengeService;

        public ChallengeController(IChallengeService ganttService)
        {
            _challengeService = ganttService;
        }
        
        [HttpPost]
        [Route("/gantt/new")]
        public async Task<IActionResult> GenerateChart([FromForm]ChallengeSettings settings)
        {
            if (ModelState.IsValid)
            {
                var challenge = _challengeService.GenerateChart(settings);
                return Redirect("/gantt");
            }
            return new JsonResult("Invalid settings") { StatusCode = 500 };
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm]Challenge gantt)
        {
            if (ModelState.IsValid)
            {
                await _challengeService.AddAsync(gantt);

                return Ok(gantt);    
            }

            return new JsonResult("Invalid Diagram") { StatusCode = 500 };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var gantt = await _challengeService.GetByIdAsync(id);
            if (gantt == null)
            {
                return NotFound();
            }

            return Ok(gantt);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var gantt = await _challengeService.GetAllAsync();
            return Ok(gantt);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(long id, Challenge gantt)
        {
            if (id != gantt.Id)
            {
                return BadRequest();
            }

            await _challengeService.UpdateAsync(gantt);

            return NoContent();
        }

        [HttpDelete("/gantt/delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var gantt = await _challengeService.GetByIdAsync(id);
            if (gantt == null)
            {
                return BadRequest();
            }

            await _challengeService.DeleteAsync(id);
            return Ok(id);
        }
    }
}
