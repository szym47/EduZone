using Product.Application;
using ProductDomain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Product.Application.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: api/<CourseController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _courseService.GetAllAsync();
            return Ok(result);
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _courseService.GetAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Course courseService)
        {
            var result = await _courseService.AddAsync(courseService);

            return Ok(result);
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Course courseService)
        {
            var result = await _courseService.UpdateAsync(courseService);

            return Ok(result);
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var course = await _courseService.GetAsync(id);
            course.Deleted = true;
            var result = await _courseService.UpdateAsync(course);

            return Ok(result);
        }

        [HttpPatch]
        public ActionResult Add([FromBody] Course courseService)
        {
            var result = _courseService.Add(courseService);

            return Ok(result);
        }
    }
}