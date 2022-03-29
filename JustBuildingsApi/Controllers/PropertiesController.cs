#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JustBuildingsApi.Models;

namespace JustBuildingsApi.Controllers
{
    [Route("api/Properties")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly PropertiesContext _context;

        public PropertiesController(PropertiesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Properties>>> GetProperties()
        {
            return await _context.Properties.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Properties>> GetProperties(long id)
        {
            var properties = await _context.Properties.FindAsync(id);

            if (properties == null)
            {
                return NotFound();
            }

            return properties;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperties(long id, Properties properties)
        {
            if (id != properties.Id)
            {
                return BadRequest();
            }

            _context.Entry(properties).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertiesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Properties>> PostProperties(Properties properties)
        {
            _context.Properties.Add(properties);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProperties), new { id = properties.Id }, properties);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperties(long id)
        {
            var properties = await _context.Properties.FindAsync(id);
            if (properties == null)
            {
                return NotFound();
            }

            _context.Properties.Remove(properties);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropertiesExists(long id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}
