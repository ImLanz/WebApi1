using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi1.Models;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutputDetailsController : ControllerBase
    {
        private readonly SocioModelContext _context;

        public OutputDetailsController(SocioModelContext context)
        {
            _context = context;
        }

        // GET: api/OutputDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OutputDetail>>> GetoutputDetails()
        {
            return await _context.outputDetails.ToListAsync();
        }

        // GET: api/OutputDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OutputDetail>> GetOutputDetail(int id)
        {
            var outputDetail = await _context.outputDetails.FindAsync(id);

            if (outputDetail == null)
            {
                return NotFound();
            }

            return outputDetail;
        }

        // PUT: api/OutputDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOutputDetail(int id, OutputDetail outputDetail)
        {
            if (id != outputDetail.id)
            {
                return BadRequest();
            }

            _context.Entry(outputDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OutputDetailExists(id))
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

        // POST: api/OutputDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OutputDetail>> PostOutputDetail(OutputDetail outputDetail)
        {
            _context.outputDetails.Add(outputDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOutputDetail", new { id = outputDetail.id }, outputDetail);
        }

        // DELETE: api/OutputDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OutputDetail>> DeleteOutputDetail(int id)
        {
            var outputDetail = await _context.outputDetails.FindAsync(id);
            if (outputDetail == null)
            {
                return NotFound();
            }

            _context.outputDetails.Remove(outputDetail);
            await _context.SaveChangesAsync();

            return outputDetail;
        }

        private bool OutputDetailExists(int id)
        {
            return _context.outputDetails.Any(e => e.id == id);
        }
    }
}
