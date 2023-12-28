using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLD_BE.Models;

namespace QLD_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopsController : ControllerBase
    {
        private readonly QldsvContext _context;

        public LopsController(QldsvContext context)
        {
            _context = context;
        }

        // GET: api/Lops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lop>>> GetLops()
        {
            return await _context.Lops.ToListAsync();
        }

        // GET: api/Lops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lop>> GetLop(int id)
        {
            var lop = await _context.Lops.FindAsync(id);

            if (lop == null)
            {
                return NotFound();
            }

            return lop;
        }

        // PUT: api/Lops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLop(int id, Lop lop)
        {
            if (id != lop.Idl)
            {
                return BadRequest();
            }

            _context.Entry(lop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LopExists(id))
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

        // POST: api/Lops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lop>> PostLop(Lop lop)
        {
            _context.Lops.Add(lop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLop", new { id = lop.Idl }, lop);
        }

        // DELETE: api/Lops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLop(int id)
        {
            var lop = await _context.Lops.FindAsync(id);
            if (lop == null)
            {
                return NotFound();
            }

            _context.Lops.Remove(lop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LopExists(int id)
        {
            return _context.Lops.Any(e => e.Idl == id);
        }
    }
}
