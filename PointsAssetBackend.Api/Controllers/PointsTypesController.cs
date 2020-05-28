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
    public class PointsTypesController : ControllerBase
    {
        private readonly AdiraLoyaltyContext _context;

        public PointsTypesController(AdiraLoyaltyContext context)
        {
            _context = context;
        }

        // GET: api/PointsTypes
        [HttpGet("{skip}/{take}", Name ="Get Points Type List")]
        public async Task<ActionResult<IEnumerable<PointsType>>> GetPointsType(int skip, int take)
        {
            return await _context.PointsType.Skip(skip).Take(take).ToListAsync();
        }

        // GET: api/PointsTypes/5
        [HttpGet("{id}",Name = "Get Points Type Details")]
        public async Task<ActionResult<PointsType>> GetPointsType(Guid id)
        {
            var pointsType = await _context.PointsType.FindAsync(id);

            if (pointsType == null)
            {
                return NotFound();
            }

            return pointsType;
        }

        // PUT: api/PointsTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}",Name ="Edit Points Type Details")]
        public async Task<IActionResult> PutPointsType(Guid id, PointsType pointsType)
        {
            if (id != pointsType.PtId)
            {
                return BadRequest();
            }

            _context.Entry(pointsType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointsTypeExists(id))
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

        // POST: api/PointsTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost(Name ="Insert new Points Type")]
        public async Task<ActionResult<PointsType>> PostPointsType(PointsType pointsType)
        {
            _context.PointsType.Add(pointsType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPointsType", new { id = pointsType.PtId }, pointsType);
        }

        // DELETE: api/PointsTypes/5
        [HttpDelete("{id}",Name = "Delete Points Type")]
        public async Task<ActionResult<PointsType>> DeletePointsType(Guid id)
        {
            var pointsType = await _context.PointsType.FindAsync(id);
            if (pointsType == null)
            {
                return NotFound();
            }

            _context.PointsType.Remove(pointsType);
            await _context.SaveChangesAsync();

            return pointsType;
        }

        private bool PointsTypeExists(Guid id)
        {
            return _context.PointsType.Any(e => e.PtId == id);
        }
    }
}
