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
    public class PointsTypeAttrsController : ControllerBase
    {
        private readonly AdiraLoyaltyContext _context;

        public PointsTypeAttrsController(AdiraLoyaltyContext context)
        {
            _context = context;
        }

        // GET: api/PointsTypeAttrs
        [HttpGet("{skip}/{take}", Name ="Get Points Type Attr")]
        public async Task<ActionResult<IEnumerable<PointsTypeAttr>>> GetPointsTypeAttr(int skip, int take)
        {
            return await _context.PointsTypeAttr.Skip(skip).Take(take).ToListAsync();
        }

        // GET: api/PointsTypeAttrs/5
        [HttpGet("{id}", Name ="Get Points Type Attr Details")]
        public async Task<ActionResult<PointsTypeAttr>> GetPointsTypeAttr(Guid id)
        {
            var pointsTypeAttr = await _context.PointsTypeAttr.FindAsync(id);

            if (pointsTypeAttr == null)
            {
                return NotFound();
            }

            return pointsTypeAttr;
        }

        // PUT: api/PointsTypeAttrs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}",Name ="Edit Points Type Attr")]
        public async Task<IActionResult> PutPointsTypeAttr(Guid id, PointsTypeAttr pointsTypeAttr)
        {
            if (id != pointsTypeAttr.PttId)
            {
                return BadRequest();
            }

            _context.Entry(pointsTypeAttr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointsTypeAttrExists(id))
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

        // POST: api/PointsTypeAttrs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost(Name ="Insert New Points Type Attr")]
        public async Task<ActionResult<PointsTypeAttr>> PostPointsTypeAttr(PointsTypeAttr pointsTypeAttr)
        {
            _context.PointsTypeAttr.Add(pointsTypeAttr);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPointsTypeAttr", new { id = pointsTypeAttr.PttId }, pointsTypeAttr);
        }

        // DELETE: api/PointsTypeAttrs/5
        [HttpDelete("{id}",Name ="Delete Points Type Attr")]
        public async Task<ActionResult<PointsTypeAttr>> DeletePointsTypeAttr(Guid id)
        {
            var pointsTypeAttr = await _context.PointsTypeAttr.FindAsync(id);
            if (pointsTypeAttr == null)
            {
                return NotFound();
            }

            _context.PointsTypeAttr.Remove(pointsTypeAttr);
            await _context.SaveChangesAsync();

            return pointsTypeAttr;
        }

        private bool PointsTypeAttrExists(Guid id)
        {
            return _context.PointsTypeAttr.Any(e => e.PttId == id);
        }
    }
}
