using Microsoft.AspNetCore.Mvc;
using Orders.Shared.Entities;
using Ordes.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Ordes.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoutriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CoutriesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync() 
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var contry = await _context.Countries.FindAsync(id);
            if (contry == null)
            {
                return NotFound();
            }
            return Ok(contry);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);

        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Country country)
        {
            _context.Update(country);
            await _context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var contry = await _context.Countries.FindAsync(id);
            if (contry == null)
            {
                return NotFound();
            }
            _context.Remove(contry);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
