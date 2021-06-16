using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Express.Models;
using System.IO;

namespace Express.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillStatusDetailsController : ControllerBase
    {
        private readonly DBExpressContext _context;

        public BillStatusDetailsController(DBExpressContext context)
        {
            _context = context;
        }

        // GET: api/BillStatusDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillStatusDetail>>> GetBillStatusDetails()
        {
            return await _context.BillStatusDetails.ToListAsync();
        }

        // GET: api/BillStatusDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillStatusDetail>> GetBillStatusDetail(string id)
        {
            var billStatusDetail = await _context.BillStatusDetails.FindAsync(id);

            if (billStatusDetail == null)
            {
                return NotFound();
            }

            return billStatusDetail;
        }

        // PUT: api/BillStatusDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillStatusDetail(Guid id, BillStatusDetail billStatusDetail)
        {
            if (id != billStatusDetail.IDStatus)
            {
                return BadRequest();
            }

            _context.Entry(billStatusDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillStatusDetailExists(id))
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

        // POST: api/BillStatusDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BillStatusDetail>> PostBillStatusDetail([FromForm] BillStatusDetail billStatusDetail)
        {
            if (HttpContext.Request.Form.Files.Count > 0)
            {
                var file = HttpContext.Request.Form.Files[0];

                byte[] fileData = null;

                using (var binaryReader = new BinaryReader(file.OpenReadStream()))
                {
                    fileData = binaryReader.ReadBytes((int)file.Length);
                }

            }
            _context.BillStatusDetails.Add(billStatusDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BillStatusDetailExists(billStatusDetail.IDStatus))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBillStatusDetail", new { id = billStatusDetail.IDStatus }, billStatusDetail);
        }

        // DELETE: api/BillStatusDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BillStatusDetail>> DeleteBillStatusDetail(string id)
        {
            var billStatusDetail = await _context.BillStatusDetails.FindAsync(id);
            if (billStatusDetail == null)
            {
                return NotFound();
            }

            _context.BillStatusDetails.Remove(billStatusDetail);
            await _context.SaveChangesAsync();

            return billStatusDetail;
        }

        private bool BillStatusDetailExists(Guid id)
        {
            return _context.BillStatusDetails.Any(e => e.IDStatus == id);
        }
    }
}
