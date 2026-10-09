using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryWebApi.Data;
using LibraryWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Members : ControllerBase
    {
        private readonly LibraryDBContext _context;
        public Members(LibraryDBContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Members>>> GetMembers()
        {
            var member = await _context.Members.ToListAsync();

            return Ok(member);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Members>> GetMember(int id)
        {
            var memb = await _context.Members.FindAsync(id);

            if (memb == null)
            {
                return NotFound();
            }

            return Ok(memb);
        }

        [HttpPost]
        public async Task<ActionResult<Members>> CreateMember(Member member)
        {
            _context.Members.Add(member);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetMember),
                new { id = member.Id },
                member);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(
    int id,
    Member member)
        {
            if (id != member.Id)
            {
                return BadRequest();
            }

            var existingmemb = await _context.Members.FindAsync(id);

            if (existingmemb  == null)
            {
                return NotFound();
            }

            existingmemb.FullName = member.FullName   ;
            existingmemb.Email = member.Email;
            existingmemb.Phone = member.Phone;
            existingmemb.Dateofjoined = member.Dateofjoined;
            existingmemb.LibraryID = member.LibraryID;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var memb = await _context.Members.FindAsync(id);

            if (memb == null)
            {
                return NotFound();
            }

            _context.Members.Remove(memb);

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
