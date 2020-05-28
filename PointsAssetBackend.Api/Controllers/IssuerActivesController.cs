using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointsAssetBackend.Api.Models;

namespace IssuerBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuerActivesController : ControllerBase
    {
        private readonly AdiraLoyaltyContext _context;

        public IssuerActivesController(AdiraLoyaltyContext context)
        {
            _context = context;
        }

        // GET: api/IssuerActives
        [HttpGet("{skip}/{take}", Name ="Get Issuer Active List")]
        public async Task<ActionResult<IEnumerable<IssuerActive>>> GetIssuerActive(int skip, int take)
        {
            return await _context.IssuerActive.Skip(skip).Take(take).ToListAsync();
        }

        // GET: api/IssuerActives/5
        [HttpGet("{id}",Name = "Get Issuer Active Details")]
        public async Task<ActionResult<IssuerActive>> GetIssuerActive(Guid id)
        {
            var issuerActive = await _context.IssuerActive.FindAsync(id);

            if (issuerActive == null)
            {
                return NotFound();
            }

            return issuerActive;
        }

        // PUT: api/IssuerActives/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}", Name= "Edit Issuer Active")]
        public async Task<IActionResult> PutIssuerActive(Guid id, IssuerActive issuerActive)
        {
            if (id != issuerActive.IsaId)
            {
                return BadRequest();
            }

            _context.Entry(issuerActive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssuerActiveExists(id))
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

        // POST: api/IssuerActives
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost(Name = "Insert New Issuer Active")]
        public async Task<ActionResult<IssuerActive>> PostIssuerActive(IssuerActive issuerActive)
        {
            _context.IssuerActive.Add(issuerActive);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIssuerActive", new { id = issuerActive.IsaId }, issuerActive);
        }

        // DELETE: api/IssuerActives/5
        [HttpDelete("{id}",Name ="Delete Issuer Active")]
        public async Task<ActionResult<IssuerActive>> DeleteIssuerActive(Guid id)
        {
            var issuerActive = await _context.IssuerActive.FindAsync(id);
            if (issuerActive == null)
            {
                return NotFound();
            }

            _context.IssuerActive.Remove(issuerActive);
            await _context.SaveChangesAsync();

            return issuerActive;
        }

        private bool IssuerActiveExists(Guid id)
        {
            return _context.IssuerActive.Any(e => e.IsaId == id);
        }
    }
}
