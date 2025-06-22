using Microsoft.AspNetCore.Mvc;
using Product.Application.Services;
using ProductDomain.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _category;

        public CategoryController(ICategoryService category)
        {
            _category = category;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _category.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _category.GetAsync(id);
            if (result == null || result.Deleted)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _category.AddAsync(category);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Category category)
        {
            if (id != category.Id) return BadRequest("ID mismatch.");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updated = await _category.UpdateAsync(category);
            return Ok(updated);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _category.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("restore/{id}")]
        public async Task<IActionResult> Restore(int id)
        {
            var restored = await _category.RestoreAsync(id);
            return restored == null ? NotFound() : Ok(restored);
        }


    }
}
