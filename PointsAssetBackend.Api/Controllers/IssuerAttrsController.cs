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
    public class IssuerAttrsController : ControllerBase
    {
        private readonly AdiraLoyaltyContext _context;

        public IssuerAttrsController(AdiraLoyaltyContext context)
        {
            _context = context;
        }

        // GET: api/IssuerAttrs
        [HttpGet("{skip}/{take}",Name ="Get Issuer Attr List" )]
        public async Task<ActionResult<IEnumerable<IssuerAttr>>> GetIssuerAttr(int skip, int take)
        {
            return await _context.IssuerAttr.Skip(skip).Take(take).ToListAsync();
        }

        // GET: api/IssuerAttrs/5
        [HttpGet("{id}",Name = "Get Issuer Attr Details")]
        public async Task<ActionResult<IssuerAttr>> GetIssuerAttr(Guid id)
        {
            var issuerAttr = await _context.IssuerAttr.FindAsync(id);

            if (issuerAttr == null)
            {
                return NotFound();
            }

            return issuerAttr;
        }

        // PUT: api/IssuerAttrs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}",Name = "Edit Issuer Attr")]
        public async Task<IActionResult> PutIssuerAttr(Guid id, IssuerAttr issuerAttr)
        {
            if (id != issuerAttr.IstId)
            {
                return BadRequest();
            }

            _context.Entry(issuerAttr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssuerAttrExists(id))
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

        // POST: api/IssuerAttrs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost(Name = "Insert New Issuer Attr")]
        public async Task<ActionResult<IssuerAttr>> PostIssuerAttr(IssuerAttr issuerAttr)
        {
            _context.IssuerAttr.Add(issuerAttr);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIssuerAttr", new { id = issuerAttr.IstId }, issuerAttr);
        }

        // DELETE: api/IssuerAttrs/5
        [HttpDelete("{id}",Name= "Delete Issuer Attr")]
        public async Task<ActionResult<IssuerAttr>> DeleteIssuerAttr(Guid id)
        {
            var issuerAttr = await _context.IssuerAttr.FindAsync(id);
            if (issuerAttr == null)
            {
                return NotFound();
            }

            _context.IssuerAttr.Remove(issuerAttr);
            await _context.SaveChangesAsync();

            return issuerAttr;
        }

        private bool IssuerAttrExists(Guid id)
        {
            return _context.IssuerAttr.Any(e => e.IstId == id);
        }
    }
}
