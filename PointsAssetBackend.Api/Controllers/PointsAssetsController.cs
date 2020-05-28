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
    public class PointsAssetsController : ControllerBase
    {
        private readonly AdiraLoyaltyContext _context;

        public PointsAssetsController(AdiraLoyaltyContext context)
        {
            _context = context;
        }

        // GET: api/PointsAssets
        [HttpGet("{skip}/{take}", Name ="Get Points Asset List")]
        public async Task<ActionResult<IEnumerable<PointsAsset>>> GetPointsAsset(int skip, int take)
        {
            return await _context.PointsAsset.Skip(skip).Take(take).ToListAsync();
        }

        // GET: api/PointsAssets/5
        [HttpGet("{id}",Name = "Get Points Asset Details")]
        public async Task<ActionResult<PointsAsset>> GetPointsAsset(Guid id)
        {
            var pointsAsset = await _context.PointsAsset.FindAsync(id);

            if (pointsAsset == null)
            {
                return NotFound();
            }

            return pointsAsset;
        }

        // PUT: api/PointsAssets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}",Name ="Edit PointsAsset")]
        public async Task<IActionResult> PutPointsAsset(Guid id, PointsAsset pointsAsset)
        {
            if (id != pointsAsset.PaId)
            {
                return BadRequest();
            }

            _context.Entry(pointsAsset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointsAssetExists(id))
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

        // POST: api/PointsAssets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost (Name =" Insert New Points Asset")]
        public async Task<ActionResult<PointsAsset>> PostPointsAsset(PointsAsset pointsAsset)
        {
            _context.PointsAsset.Add(pointsAsset);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPointsAsset", new { id = pointsAsset.PaId }, pointsAsset);
        }

        // DELETE: api/PointsAssets/5
        [HttpDelete("{id}",Name = "Delete Points Asset")]
        public async Task<ActionResult<PointsAsset>> DeletePointsAsset(Guid id)
        {
            var pointsAsset = await _context.PointsAsset.FindAsync(id);
            if (pointsAsset == null)
            {
                return NotFound();
            }

            _context.PointsAsset.Remove(pointsAsset);
            await _context.SaveChangesAsync();

            return pointsAsset;
        }

        private bool PointsAssetExists(Guid id)
        {
            return _context.PointsAsset.Any(e => e.PaId == id);
        }
    }
}
