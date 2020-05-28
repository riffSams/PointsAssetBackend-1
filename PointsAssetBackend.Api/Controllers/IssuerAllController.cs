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
    [Route("api/[controller]")]
    [ApiController]
    public class IssuerAllController : ControllerBase
    {
        private readonly AdiraLoyaltyContext _context;

        public IssuerAllController(AdiraLoyaltyContext context)
        {
            _context = context;
        }


        // GET: api/Issuers

        [HttpGet("{skip}/{take}", Name = " Get Issuer All")]
        public async Task<ActionResult<IEnumerable<IssuerAll>>> GetIssuerAll(int skip, int take)
        {
            List<Issuer> isu = await _context.Issuer.Skip(skip).Take(take).ToListAsync();

            List<IssuerAll> isAll = new List<IssuerAll>();

            foreach (Issuer data in isu)
            {
                IssuerAll isAllElement = new IssuerAll();
                isAllElement.IsId = data.IsId;
                isAllElement.Issuer = data;

                List<IssuerAttr> isAttrList = new List<IssuerAttr>();
                isAttrList = await _context.IssuerAttr.Where(isu => isu.IsId == data.IsId).ToListAsync();

                isAllElement.IssuerAttrs = isAttrList;

                isAll.Add(isAllElement);
            }
            return isAll;
        }

        [HttpGet("{id}", Name = "Get Points Issuer All Details")]
        public async Task<ActionResult<IssuerAll>> GetIssuerAllDetail(Guid id)
        {
            Issuer isu = await _context.Issuer.FindAsync(id);
            IssuerAll issuerAll = new IssuerAll();

            issuerAll.IsId = isu.IsId;
            issuerAll.Issuer = isu;
            issuerAll.IssuerAttrs = await _context.IssuerAttr.Where(i => i.IsId == isu.IsId).ToListAsync();

            if (issuerAll.IsId == null)
            {
                return NotFound();
            }
            return issuerAll;

        }
        // POST: api/PointsTypeAll
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost(Name = "Insert New Issuer All")]
        public async Task<ActionResult<IssuerAll>> PostIssuerAll([FromBody]IssuerAll issuerAll)
        {
            issuerAll.IsId = Guid.NewGuid();
            issuerAll.Issuer.IsId = issuerAll.IsId;

            _context.Issuer.Add(issuerAll.Issuer);
            await _context.SaveChangesAsync();

            foreach (IssuerAttr item in issuerAll.IssuerAttrs)
            {
                item.IsId = issuerAll.IsId;
                _context.IssuerAttr.Add(item);
                await _context.SaveChangesAsync();
            }
            return CreatedAtAction("GetIssuerAllDetail", new { id = issuerAll.IsId }, issuerAll);
            //return CreatedAtAction("", new { id = issuerAll.IsId }, issuelAll);
        }

        // PUT: api/Issuers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}", Name = " Update Issuer All")]
        public async Task<IActionResult> PutIssuerAll(Guid id, IssuerAll issuerAll)
        {
            if (id != issuerAll.IsId)
            {
                return BadRequest();
            }

            _context.Entry(issuerAll.Issuer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssuerAllExist(id))
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

        [HttpDelete("{id}", Name ="Delete Issuer All")]
        public async Task<ActionResult<IssuerAll>> DeleteIssuerAll(Guid id)
        {
            Issuer isu = await _context.Issuer.FindAsync(id);
            IssuerAll issuerAll = new IssuerAll();

            issuerAll.IsId = isu.IsId;
            issuerAll.Issuer = isu;
            issuerAll.IssuerAttrs = await _context.IssuerAttr.Where(i => i.IsId == isu.IsId).ToListAsync();
            if (issuerAll == null)
            {
                return NotFound();
            }
            _context.Issuer.Remove(isu);
            await _context.SaveChangesAsync();

            return issuerAll;
        }
        private bool IssuerAllExist(Guid id)
        {
            return _context.Issuer.Any(e => e.IsId == id);
        }

    }
}