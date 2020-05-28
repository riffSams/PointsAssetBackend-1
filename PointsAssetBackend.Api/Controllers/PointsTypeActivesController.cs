using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointsAssetBackend.Api.Models;

namespace PointsAssetBackend.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PointsTypeActivesController : ControllerBase
    {
        private readonly AdiraLoyaltyContext _context;

        public PointsTypeActivesController(AdiraLoyaltyContext context)
        {
            _context = context;
        }

        // GET: api/PointsTypeActives
        [HttpGet("{skip}/{take}", Name ="Get Points Type Active List")]
        public async Task<ActionResult<IEnumerable<PointsTypeActive>>> GetPointsTypeActive(int skip, int take)
        {
            return await _context.PointsTypeActive.Skip(skip).Take(take).ToListAsync();
        }

        // GET: api/PointsTypeActives/5
        [HttpGet("{id}", Name ="Get Points Type Active Details")]
        public async Task<ActionResult<PointsTypeActive>> GetPointsTypeActive(Guid id)
        {
            var pointsTypeActive = await _context.PointsTypeActive.FindAsync(id);

            if (pointsTypeActive == null)
            {
                return NotFound();
            }

            return pointsTypeActive;
        }

        // PUT: api/PointsTypeActives/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}",Name ="Edit Points Type Active")]
        public async Task<IActionResult> PutPointsTypeActive(Guid id, PointsTypeActive pointsTypeActive)
        {
            if (id != pointsTypeActive.PtaId)
            {
                return BadRequest();
            }

            _context.Entry(pointsTypeActive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointsTypeActiveExists(id))
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

        // POST: api/PointsTypeActives
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost (Name = "Insert New Points Type Active")]
        public async Task<ActionResult<PointsTypeActive>> PostPointsTypeActive(PointsTypeActive pointsTypeActive)
        {
            _context.PointsTypeActive.Add(pointsTypeActive);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPointsTypeActive", new { id = pointsTypeActive.PtaId }, pointsTypeActive);
        }

        // DELETE: api/PointsTypeActives/5
        [HttpDelete("{id}", Name ="Delete Points Type Active")]
        public async Task<ActionResult<PointsTypeActive>> DeletePointsTypeActive(Guid id)
        {
            var pointsTypeActive = await _context.PointsTypeActive.FindAsync(id);
            if (pointsTypeActive == null)
            {
                return NotFound();
            }

            _context.PointsTypeActive.Remove(pointsTypeActive);
            await _context.SaveChangesAsync();

            return pointsTypeActive;
        }

        private bool PointsTypeActiveExists(Guid id)
        {
            return _context.PointsTypeActive.Any(e => e.PtaId == id);
        }
    }
}
