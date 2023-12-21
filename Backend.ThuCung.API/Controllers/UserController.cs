using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.ThuCung.API.Models;
using Backend.ThuCung.API.DTO;

namespace Backend.ThuCung.API.Controllers
{
    [Route("api/UserAPI")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ThuCungDbContext _context;

        public UserController(ThuCungDbContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tuser>>> GetTusers()
        {
          if (_context.Tusers == null)
          {
              return NotFound();
          }
            return await _context.Tusers.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tuser>> GetTuser(Guid id)
        {
          if (_context.Tusers == null)
          {
              return NotFound();
          }
            var tuser = await _context.Tusers.FindAsync(id);

            if (tuser == null)
            {
                return NotFound();
            }

            return tuser;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTuser(Guid id, Tuser tuser)
        {
            if (id != tuser.Iduser)
            {
                return BadRequest();
            }

            _context.Entry(tuser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TuserExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tuser>> PostTuser(Tuser tuser)
        {
          if (_context.Tusers == null)
          {
              return Problem("Entity set 'ThuCungDbContext.Tusers'  is null.");
          }
            _context.Tusers.Add(tuser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TuserExists(tuser.Iduser))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTuser", new { id = tuser.Iduser }, tuser);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTuser(Guid id)
        {
            if (_context.Tusers == null)
            {
                return NotFound();
            }
            var tuser = await _context.Tusers.FindAsync(id);
            if (tuser == null)
            {
                return NotFound();
            }

            _context.Tusers.Remove(tuser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TuserExists(Guid id)
        {
            return (_context.Tusers?.Any(e => e.Iduser == id)).GetValueOrDefault();
        }
    }
}
