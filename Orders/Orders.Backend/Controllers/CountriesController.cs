using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Shared.Entities;

namespace Orders.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra
            }
            return Ok(country);
        }

        // POST: api/Countries
        [HttpPost]
        public async Task<IActionResult> PostAsync(Country country)
        {
            try
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
                // Devuelve 201 Created con la ubicación del nuevo recurso y el recurso mismo
                return CreatedAtAction(nameof(GetAsync), new { id = country.Id }, country);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException != null && dbUpdateException.InnerException.Message.Contains("duplicate key"))
                {
                    return BadRequest($"Ya existe un país con el nombre {country.Name}.");
                }
                // Puedes loggear el error completo aquí si es necesario
                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                // Puedes loggear el error completo aquí si es necesario
                return BadRequest(exception.Message);
            }
        }

        // PUT: api/Countries
        [HttpPut]
        public async Task<IActionResult> PutAsync(Country country)
        {
            try
            {
                _context.Update(country);
                await _context.SaveChangesAsync();
                return Ok(country);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException != null && dbUpdateException.InnerException.Message.Contains("duplicate key"))
                {
                    return BadRequest($"Ya existe un país con el nombre {country.Name}.");
                }
                // Puedes loggear el error completo aquí si es necesario
                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                // Puedes loggear el error completo aquí si es necesario
                return BadRequest(exception.Message);
            }
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            try
            {
                _context.Remove(country);
                await _context.SaveChangesAsync();
                return NoContent(); // Devuelve 204 No Content, indicando éxito sin cuerpo de respuesta
            }
            catch (Exception exception)
            {
                // Puedes loggear el error completo aquí si es necesario
                return BadRequest(exception.Message);
            }
        }
    }
}