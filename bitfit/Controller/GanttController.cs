using bitfit.DAL.IServices;
using bitfit.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace bitfit.Controller
{
    [ApiController, Route("/gantt")]
    public class GanttController : ControllerBase
    {
        private readonly IGanttService _ganttService;

        public GanttController(IGanttService ganttService)
        {
            _ganttService = ganttService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]Gantt gantt)
        {
            if (ModelState.IsValid)
            {
                await _ganttService.AddAsync(gantt);

                return Ok(gantt);    
            }

            return new JsonResult("Invalid Diagram") { StatusCode = 500 };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var gantt = await _ganttService.GetByIdAsync(id);
            if (gantt == null)
            {
                return NotFound();
            }

            return Ok(gantt);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var gantt = await _ganttService.GetAllAsync();
            return Ok(gantt);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(long id, Gantt gantt)
        {
            if (id != gantt.Id)
            {
                return BadRequest();
            }

            await _ganttService.UpdateAsync(gantt);

            return NoContent();
        }

        [HttpDelete("/gantt/delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var gantt = await _ganttService.GetByIdAsync(id);
            if (gantt == null)
            {
                return BadRequest();
            }

            await _ganttService.DeleteAsync(id);
            return Ok(id);
        }
    }
}
