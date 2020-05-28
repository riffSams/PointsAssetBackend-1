using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointsAssetBackend.Api.Models;

namespace PointsAssetBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsTypeAllController : ControllerBase
    {
        private readonly AdiraLoyaltyContext _context;

        public PointsTypeAllController(AdiraLoyaltyContext context)
        {
            _context = context;
        }
        // GET: api/PointsTypeAll
        //[HttpGet("{skip}/{take}", Name = "Get Points Type All")]
        //public async Task<ActionResult<IEnumerable<PointsTypeAll>>> GetPointsTypeAll(int skip, int take)
        //{
        //    return await _context.PointsTypeAll.Skip(skip).Take(take).ToListAsync();
        //}

        [HttpGet("{skip}/{take}", Name = "Get Points Type All")]
        public async Task<ActionResult<IEnumerable<PointsTypeAll>>> GetPointsTypeAll(int skip, int take)
        {
            List<PointsType> pt = await _context.PointsType.Skip(skip).Take(take).ToListAsync();

            List<PointsTypeAll> ptAll = new List<PointsTypeAll>();

            foreach (PointsType data in pt)
            {
                PointsTypeAll ptAllElement = new PointsTypeAll();
                ptAllElement.PtId = data.PtId;
                ptAllElement.PointsType = data;

                List<PointsTypeAttr> ptAttrList = new List<PointsTypeAttr>();
                ptAttrList = await _context.PointsTypeAttr.Where(pt => pt.PtId == data.PtId).ToListAsync();

                //data.po
                ptAllElement.PtAttr = ptAttrList;

                ptAll.Add(ptAllElement);
            }
            return ptAll;
        }

        [HttpGet("{id}", Name = "Get Points Type All Detail")]
        public async Task<ActionResult<PointsTypeAll>> GetPointsTypeAllDetail(Guid id)
        {
            PointsType pt = await _context.PointsType.FindAsync(id);
            PointsTypeAll ptAll = new PointsTypeAll();

            ptAll.PtId = pt.PtId;
            ptAll.PointsType = pt;
            ptAll.PtAttr = await _context.PointsTypeAttr.Where(p => p.PtId == pt.PtId).ToListAsync();

            return ptAll;
        }

        // POST: api/PointsTypeAll
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost(Name = "Insert New Points Type All")]
        public async Task<ActionResult<PointsTypeAll>> PostPointsTypeAll([FromBody]PointsTypeAll pointsTypeAll)
        {
            pointsTypeAll.PtId = Guid.NewGuid();
            pointsTypeAll.PointsType.PtId = pointsTypeAll.PtId;

            if (pointsTypeAll.PointsType.PtId != pointsTypeAll.PtId)
            {
                return BadRequest();
            }

            _context.PointsType.Add(pointsTypeAll.PointsType);
            await _context.SaveChangesAsync();
            
           foreach (PointsTypeAttr item in pointsTypeAll.PtAttr)
           {
            item.PtId = pointsTypeAll.PtId;
            _context.PointsTypeAttr.Add(item);
            await _context.SaveChangesAsync();
           }
            return CreatedAtAction("GetPointsTypeAllDetail", new { id = pointsTypeAll.PtId }, pointsTypeAll);
        }
        [HttpPut("{id}", Name ="Edit Pointstype All")]
        public async Task<IActionResult> PutPointsTypeAll(Guid id, PointsTypeAll pointsTypeAll)
        {
            if (id != pointsTypeAll.PtId)
            {
                return NotFound();
            }

            _context.Entry(pointsTypeAll.PointsType).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointsTypeExist(id))
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
        [HttpDelete("{id}", Name ="Delete PointsType All")]
        public async Task<ActionResult<PointsTypeAll>> DeletePointsTypeAll(Guid id)
        {
            PointsType pt = await _context.PointsType.FindAsync(id);
            PointsTypeAll ptAll = new PointsTypeAll();
            ptAll.PtId = pt.PtId;
            ptAll.PointsType = pt;
            ptAll.PtAttr = await _context.PointsTypeAttr.Where(p => p.PtId == pt.PtId).ToListAsync();

            if (ptAll.PtId == null)
            {
                return NotFound();
            }
            return ptAll;
        }
        private bool PointsTypeExist(Guid id)
        {
            return _context.PointsType.Any(e => e.PtId == id);
        }
    }
}