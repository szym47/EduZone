using Microsoft.AspNetCore.Mvc;
using Product.Application.Services;
using ProductDomain.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _course;

        public CourseController(ICourseService course)
        {
            _course = course;
        }

        // GET: api/Course
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _course.GetAllAsync();
            return Ok(result);
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _course.GetAsync(id);
            if (result == null || result.Deleted)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST: api/Course
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Course course)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _course.AddAsync(course);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        // PUT: api/Course/
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Course course)
        {
            if (id != course.Id)
                return BadRequest("ID incorrect");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _course.UpdateAsync(course);
            return Ok(updated);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _course.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("restore/{id}")]
        public async Task<IActionResult> Restore(int id)
        {
            var restored = await _course.RestoreAsync(id);
            return restored == null ? NotFound() : Ok(restored);
        }

    }
}
