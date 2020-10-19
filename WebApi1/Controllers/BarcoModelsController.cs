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
    public class BarcoModelsController : ControllerBase
    {
        private readonly SocioModelContext _context;

        public BarcoModelsController(SocioModelContext context)
        {
            _context = context;
        }

        // GET: api/BarcoModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BarcoModel>>> GetBarcoModels()
        {
            return await _context.BarcoModels.ToListAsync();
        }

        // GET: api/BarcoModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BarcoModel>> GetBarcoModel(string id)
        {
            var barcoModel = await _context.BarcoModels.FindAsync(id);

            if (barcoModel == null)
            {
                return NotFound();
            }

            return barcoModel;
        }

        // PUT: api/BarcoModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBarcoModel(string id, BarcoModel barcoModel)
        {
            if (id != barcoModel.boatID)
            {
                return BadRequest();
            }

            _context.Entry(barcoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarcoModelExists(id))
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

        // POST: api/BarcoModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BarcoModel>> PostBarcoModel(BarcoModel barcoModel)
        {
            _context.BarcoModels.Add(barcoModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BarcoModelExists(barcoModel.boatID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBarcoModel", new { id = barcoModel.boatID }, barcoModel);
        }

        // DELETE: api/BarcoModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BarcoModel>> DeleteBarcoModel(string id)
        {
            var barcoModel = await _context.BarcoModels.FindAsync(id);
            if (barcoModel == null)
            {
                return NotFound();
            }

            _context.BarcoModels.Remove(barcoModel);
            await _context.SaveChangesAsync();

            return barcoModel;
        }

        private bool BarcoModelExists(string id)
        {
            return _context.BarcoModels.Any(e => e.boatID == id);
        }
    }
}
