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
    public class SocioModelsController : ControllerBase
    {
        private readonly SocioModelContext _context;

        public SocioModelsController(SocioModelContext context)
        {
            _context = context;
        }

        // GET: api/SocioModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SocioModel>>> GetSocioModels()
        {
            return await _context.SocioModels.ToListAsync();
        }

        // GET: api/SocioModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SocioModel>> GetSocioModel(string id)
        {
            var socioModel = await _context.SocioModels.FindAsync(id);

            if (socioModel == null)
            {
                return NotFound();
            }

            return socioModel;
        }

        // PUT: api/SocioModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSocioModel(string id, SocioModel socioModel)
        {
            if (id != socioModel.credentialID)
            {
                return BadRequest();
            }

            _context.Entry(socioModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocioModelExists(id))
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

        // POST: api/SocioModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SocioModel>> PostSocioModel(SocioModel socioModel)
        {
            _context.SocioModels.Add(socioModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SocioModelExists(socioModel.credentialID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSocioModel", new { id = socioModel.credentialID }, socioModel);
        }

        // DELETE: api/SocioModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SocioModel>> DeleteSocioModel(string id)
        {
            var socioModel = await _context.SocioModels.FindAsync(id);
            if (socioModel == null)
            {
                return NotFound();
            }

            _context.SocioModels.Remove(socioModel);
            await _context.SaveChangesAsync();

            return socioModel;
        }

        private bool SocioModelExists(string id)
        {
            return _context.SocioModels.Any(e => e.credentialID == id);
        }
    }
}
