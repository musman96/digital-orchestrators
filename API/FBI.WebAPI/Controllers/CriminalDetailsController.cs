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
    public class CriminalDetailsController : ControllerBase
    {
        private readonly FbiContext _context;

        public CriminalDetailsController(FbiContext context)
        {
            _context = context;
        }

        // GET: api/CriminalDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CriminalDetail>>> GetCriminalDetails()
        {
          if (_context.CriminalDetails == null)
          {
              return NotFound();
          }
            return await _context.CriminalDetails.ToListAsync();
        }

        // GET: api/CriminalDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CriminalDetail>> GetCriminalDetail(Guid id)
        {
          if (_context.CriminalDetails == null)
          {
              return NotFound();
          }
            var criminalDetail = await _context.CriminalDetails.FindAsync(id);

            if (criminalDetail == null)
            {
                return NotFound();
            }

            return criminalDetail;
        }

        // PUT: api/CriminalDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCriminalDetail(Guid id, CriminalDetail criminalDetail)
        {
            if (id != criminalDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(criminalDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CriminalDetailExists(id))
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

        // POST: api/CriminalDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CriminalDetail>> PostCriminalDetail(CriminalDetail criminalDetail)
        {
          if (_context.CriminalDetails == null)
          {
              return Problem("Entity set 'FbiContext.CriminalDetails'  is null.");
          }
            _context.CriminalDetails.Add(criminalDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCriminalDetail", new { id = criminalDetail.Id }, criminalDetail);
        }

        // DELETE: api/CriminalDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCriminalDetail(Guid id)
        {
            if (_context.CriminalDetails == null)
            {
                return NotFound();
            }
            var criminalDetail = await _context.CriminalDetails.FindAsync(id);
            if (criminalDetail == null)
            {
                return NotFound();
            }

            _context.CriminalDetails.Remove(criminalDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CriminalDetailExists(Guid id)
        {
            return (_context.CriminalDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
