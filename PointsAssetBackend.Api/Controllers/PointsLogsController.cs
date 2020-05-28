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
    public class PointsLogsController : ControllerBase
    {
        private readonly AdiraLoyaltyContext _context;

        public PointsLogsController(AdiraLoyaltyContext context)
        {
            _context = context;
        }

        // GET: api/PointsLogs
        [HttpGet("{skip}/{take}",Name ="Get Points Log List")]
        public async Task<ActionResult<IEnumerable<PointsLog>>> GetPointsLog(int skip, int take)
        {
            return await _context.PointsLog.Skip(skip).Take(take).ToListAsync();
        }

        // GET: api/PointsLogs/5
        [HttpGet("{id}", Name = "Get Points Log Details")]
        public async Task<ActionResult<PointsLog>> GetPointsLog(Guid id)
        {
            var pointsLog = await _context.PointsLog.FindAsync(id);

            if (pointsLog == null)
            {
                return NotFound();
            }

            return pointsLog;
        }

        // PUT: api/PointsLogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}", Name = "Edit Points Log")]
        public async Task<IActionResult> PutPointsLog(Guid id, PointsLog pointsLog)
        {
            if (id != pointsLog.PhId)
            {
                return BadRequest();
            }

            _context.Entry(pointsLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointsLogExists(id))
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

        // POST: api/PointsLogs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost(Name = "Insert New Point Log")]
        public async Task<ActionResult<PointsLog>> PostPointsLog(PointsLog pointsLog)
        {
            _context.PointsLog.Add(pointsLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPointsLog", new { id = pointsLog.PhId }, pointsLog);
        }

        // DELETE: api/PointsLogs/5
        [HttpDelete("{id}",Name = "Delete Points Log")]
        public async Task<ActionResult<PointsLog>> DeletePointsLog(Guid id)
        {
            var pointsLog = await _context.PointsLog.FindAsync(id);
            if (pointsLog == null)
            {
                return NotFound();
            }

            _context.PointsLog.Remove(pointsLog);
            await _context.SaveChangesAsync();

            return pointsLog;
        }

        private bool PointsLogExists(Guid id)
        {
            return _context.PointsLog.Any(e => e.PhId == id);
        }
    }
}
