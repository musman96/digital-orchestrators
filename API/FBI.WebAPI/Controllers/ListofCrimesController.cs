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
    public class ListofCrimesController : ControllerBase
    {
        private readonly FbiContext _context;

        public ListofCrimesController(FbiContext context)
        {
            _context = context;
        }

        // GET: api/ListofCrimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListofCrime>>> GetListofCrimes( )
        {
          if (_context.ListofCrimes == null)
          {
              return NotFound();
          }
            return await _context.ListofCrimes.ToListAsync();
        }

        // GET: api/ListofCrimes/5
        [HttpGet("{criminalId}")]
        public async Task<ActionResult<List<ListofCrime>>> GetListofCrime(Guid criminalId)
        {
          if (_context.ListofCrimes == null)
          {
              return NotFound();
          }
            var listofCrimes = await _context.ListofCrimes.Where(x=>x.CriminalId == criminalId).ToListAsync();

            if (listofCrimes == null)
            {
                return NotFound();
            }

            return listofCrimes;
        }

        // PUT: api/ListofCrimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListofCrime(long id, ListofCrime listofCrime)
        {
            if (id != listofCrime.Id)
            {
                return BadRequest();
            }

            _context.Entry(listofCrime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListofCrimeExists(id))
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

        // POST: api/ListofCrimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ListofCrime>> PostListofCrime(ListofCrime listofCrime)
        {
          if (_context.ListofCrimes == null)
          {
              return Problem("Entity set 'FbiContext.ListofCrimes'  is null.");
          }
            _context.ListofCrimes.Add(listofCrime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListofCrime", new { id = listofCrime.Id }, listofCrime);
        }

        // DELETE: api/ListofCrimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListofCrime(long id)
        {
            if (_context.ListofCrimes == null)
            {
                return NotFound();
            }
            var listofCrime = await _context.ListofCrimes.FindAsync(id);
            if (listofCrime == null)
            {
                return NotFound();
            }

            _context.ListofCrimes.Remove(listofCrime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListofCrimeExists(long id)
        {
            return (_context.ListofCrimes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
