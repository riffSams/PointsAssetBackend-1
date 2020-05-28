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
    public class IssuersController : ControllerBase
    {
        private readonly AdiraLoyaltyContext _context;

        public IssuersController(AdiraLoyaltyContext context)
        {
            _context = context;
        }

        // GET: api/Issuers
        [HttpGet("{skip}/{take}",Name = "Get Issuer List")]
        public async Task<ActionResult<IEnumerable<Issuer>>> GetIssuer(int skip, int take)
        {
            return await _context.Issuer.Skip(skip).Take(take).ToListAsync();
        }

        // GET: api/Issuers/5
        [HttpGet("{id}",Name ="Get Issuer Details")]
        public async Task<ActionResult<Issuer>> GetIssuer(Guid id)
        {
            var issuer = await _context.Issuer.FindAsync(id);

            if (issuer == null)
            {
                return NotFound();
            }

            return issuer;
        }

        // PUT: api/Issuers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}",Name =" Update Issuer")]
        public async Task<IActionResult> PutIssuer(Guid id, Issuer issuer)
        {
            if (id != issuer.IsId)
            {
                return BadRequest();
            }

            _context.Entry(issuer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssuerExists(id))
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

        // POST: api/Issuers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost(Name ="Insert New Issuer")]
        public async Task<ActionResult<Issuer>> PostIssuer(Issuer issuer)
        {
            _context.Issuer.Add(issuer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIssuer", new { id = issuer.IsId }, issuer);
        }

        // DELETE: api/Issuers/5
        [HttpDelete("{id}",Name ="Delete Issuer")]
        public async Task<ActionResult<Issuer>> DeleteIssuer(Guid id)
        {
            var issuer = await _context.Issuer.FindAsync(id);
            if (issuer == null)
            {
                return NotFound();
            }

            _context.Issuer.Remove(issuer);
            await _context.SaveChangesAsync();

            return issuer;
        }

        private bool IssuerExists(Guid id)
        {
            return _context.Issuer.Any(e => e.IsId == id);
        }
    }
}
