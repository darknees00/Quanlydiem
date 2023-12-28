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
    public class DiemsController : ControllerBase
    {
        private readonly QldsvContext _context;

        public DiemsController(QldsvContext context)
        {
            _context = context;
        }

        // GET: api/Diems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diem>>> GetDiems()
        {
            return await _context.Diems.ToListAsync();
        }

        // GET: api/Diems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diem>> GetDiem(int id)
        {
            var diem = await _context.Diems.FindAsync(id);

            if (diem == null)
            {
                return NotFound();
            }

            return diem;
        }

        // PUT: api/Diems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiem(int id, Diem diem)
        {
            if (id != diem.Idd)
            {
                return BadRequest();
            }

            _context.Entry(diem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiemExists(id))
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

        // POST: api/Diems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Diem>> PostDiem(Diem diem)
        {
            _context.Diems.Add(diem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiem", new { id = diem.Idd }, diem);
        }

        // DELETE: api/Diems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiem(int id)
        {
            var diem = await _context.Diems.FindAsync(id);
            if (diem == null)
            {
                return NotFound();
            }

            _context.Diems.Remove(diem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiemExists(int id)
        {
            return _context.Diems.Any(e => e.Idd == id);
        }
    }
}
