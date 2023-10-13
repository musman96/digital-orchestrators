using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FBI.WebAPI.Models;

namespace FBI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NextOfKinsController : ControllerBase
    {
        private readonly FbiContext _context;

        public NextOfKinsController(FbiContext context)
        {
            _context = context;
        }

        // GET: api/NextOfKins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NextOfKin>>> GetNextOfKins(Guid criminalId)
        {
          if (_context.NextOfKins == null)
          {
              return NotFound();
          }
            var nextOfKin = await _context.NextOfKins.Where(x => x.CriminalId == criminalId).ToListAsync();
            return nextOfKin;
        }

        // GET: api/NextOfKins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NextOfKin>> GetNextOfKin(Guid id)
        {
          if (_context.NextOfKins == null)
          {
              return NotFound();
          }
            var nextOfKin = await _context.NextOfKins.FindAsync(id);

            if (nextOfKin == null)
            {
                return NotFound();
            }

            return nextOfKin;
        }

        // PUT: api/NextOfKins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNextOfKin(Guid id, NextOfKin nextOfKin)
        {
            if (id != nextOfKin.Id)
            {
                return BadRequest();
            }

            _context.Entry(nextOfKin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NextOfKinExists(id))
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

        // POST: api/NextOfKins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NextOfKin>> PostNextOfKin(NextOfKin nextOfKin)
        {
          if (_context.NextOfKins == null)
          {
              return Problem("Entity set 'FbiContext.NextOfKins'  is null.");
          }
            _context.NextOfKins.Add(nextOfKin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNextOfKin", new { id = nextOfKin.Id }, nextOfKin);
        }

        // DELETE: api/NextOfKins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNextOfKin(Guid id)
        {
            if (_context.NextOfKins == null)
            {
                return NotFound();
            }
            var nextOfKin = await _context.NextOfKins.FindAsync(id);
            if (nextOfKin == null)
            {
                return NotFound();
            }

            _context.NextOfKins.Remove(nextOfKin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NextOfKinExists(Guid id)
        {
            return (_context.NextOfKins?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
