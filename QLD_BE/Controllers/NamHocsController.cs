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
    public class NamHocsController : ControllerBase
    {
        private readonly QldsvContext _context;

        public NamHocsController(QldsvContext context)
        {
            _context = context;
        }

        // GET: api/NamHocs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NamHoc>>> GetNamHocs()
        {
            return await _context.NamHocs.ToListAsync();
        }

        // GET: api/NamHocs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NamHoc>> GetNamHoc(int id)
        {
            var namHoc = await _context.NamHocs.FindAsync(id);

            if (namHoc == null)
            {
                return NotFound();
            }

            return namHoc;
        }

        // PUT: api/NamHocs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNamHoc(int id, NamHoc namHoc)
        {
            if (id != namHoc.Idn)
            {
                return BadRequest();
            }

            _context.Entry(namHoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NamHocExists(id))
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

        // POST: api/NamHocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NamHoc>> PostNamHoc(NamHoc namHoc)
        {
            _context.NamHocs.Add(namHoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNamHoc", new { id = namHoc.Idn }, namHoc);
        }

        // DELETE: api/NamHocs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNamHoc(int id)
        {
            var namHoc = await _context.NamHocs.FindAsync(id);
            if (namHoc == null)
            {
                return NotFound();
            }

            _context.NamHocs.Remove(namHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NamHocExists(int id)
        {
            return _context.NamHocs.Any(e => e.Idn == id);
        }
    }
}
