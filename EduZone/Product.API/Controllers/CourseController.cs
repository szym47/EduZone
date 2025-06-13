using Microsoft.AspNetCore.Mvc;
using Product.Application.Services;
using ProductDomain.Models;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Get()
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

        // PUT: api/Course/5
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

        // DELETE: api/Course/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _course.GetAsync(id);
            if (course == null || course.Deleted)
                return NotFound();

            course.Deleted = true;
            var result = await _course.UpdateAsync(course);

            return Ok(result);
        }

        [HttpPost("restore/{id}")]
        public async Task<IActionResult> Restore(int id)
        {
            var restored = await _course.RestoreAsync(id);
            return restored == null ? NotFound() : Ok(restored);
        }

    }
}
