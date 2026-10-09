using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LibraryWebApi.Data;
using LibraryWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        private readonly LibraryDBContext _context;
        public LibrariesController(LibraryDBContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Libraries>>> Get()
        {
            var lib = await _context.Libraries.ToListAsync();

            return Ok(lib);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Libraries>> Get(int id)
        {
            var lib = await _context.Libraries.FindAsync(id);

            if (lib == null)
            {
                return NotFound();
            }

            return Ok(lib);
        }

         

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLibrary(
    int id,
    Libraries lib)
        {
            if (id != lib.Id)
            {
                return BadRequest();
            }

            var existinglib = await _context.Libraries.FindAsync(id);

            if (existinglib == null)
            {
                return NotFound();
            }

            existinglib.Id = lib.Id;
            existinglib.Address = lib.Address;
            existinglib.Name = lib.Name;
            

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLib(int id)
        {
            var lib = await _context.Libraries.FindAsync(id);

            if (lib == null)
            {
                return NotFound();
            }

            _context.Libraries.Remove(lib);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
