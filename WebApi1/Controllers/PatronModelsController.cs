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
    public class PatronModelsController : ControllerBase
    {
        private readonly SocioModelContext _context;

        public PatronModelsController(SocioModelContext context)
        {
            _context = context;
        }

        // GET: api/PatronModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatronModel>>> GetPatronModels()
        {
            return await _context.PatronModels.ToListAsync();
        }

        // GET: api/PatronModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatronModel>> GetPatronModel(string id)
        {
            var patronModel = await _context.PatronModels.FindAsync(id);

            if (patronModel == null)
            {
                return NotFound();
            }

            return patronModel;
        }

        // PUT: api/PatronModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatronModel(string id, PatronModel patronModel)
        {
            if (id != patronModel.credentialID)
            {
                return BadRequest();
            }

            _context.Entry(patronModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatronModelExists(id))
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

        // POST: api/PatronModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PatronModel>> PostPatronModel(PatronModel patronModel)
        {
            _context.PatronModels.Add(patronModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PatronModelExists(patronModel.credentialID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPatronModel", new { id = patronModel.credentialID }, patronModel);
        }

        // DELETE: api/PatronModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PatronModel>> DeletePatronModel(string id)
        {
            var patronModel = await _context.PatronModels.FindAsync(id);
            if (patronModel == null)
            {
                return NotFound();
            }

            _context.PatronModels.Remove(patronModel);
            await _context.SaveChangesAsync();

            return patronModel;
        }

        private bool PatronModelExists(string id)
        {
            return _context.PatronModels.Any(e => e.credentialID == id);
        }
    }
}
