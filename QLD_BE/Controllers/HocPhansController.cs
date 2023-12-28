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
    public class HocPhansController : ControllerBase
    {
        private readonly QldsvContext _context;

        public HocPhansController(QldsvContext context)
        {
            _context = context;
        }

        // GET: api/HocPhans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HocPhan>>> GetHocPhans()
        {
            return await _context.HocPhans.ToListAsync();
        }

        // GET: api/HocPhans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HocPhan>> GetHocPhan(int id)
        {
            var hocPhan = await _context.HocPhans.FindAsync(id);

            if (hocPhan == null)
            {
                return NotFound();
            }

            return hocPhan;
        }

        // PUT: api/HocPhans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHocPhan(int id, HocPhan hocPhan)
        {
            if (id != hocPhan.Idh)
            {
                return BadRequest();
            }

            _context.Entry(hocPhan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HocPhanExists(id))
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

        // POST: api/HocPhans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HocPhan>> PostHocPhan(HocPhan hocPhan)
        {
            _context.HocPhans.Add(hocPhan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHocPhan", new { id = hocPhan.Idh }, hocPhan);
        }

        // DELETE: api/HocPhans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHocPhan(int id)
        {
            var hocPhan = await _context.HocPhans.FindAsync(id);
            if (hocPhan == null)
            {
                return NotFound();
            }

            _context.HocPhans.Remove(hocPhan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HocPhanExists(int id)
        {
            return _context.HocPhans.Any(e => e.Idh == id);
        }
    }
}
