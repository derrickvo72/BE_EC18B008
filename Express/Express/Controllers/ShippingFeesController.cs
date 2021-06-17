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
    public class ShippingFeesController : ControllerBase
    {
        private readonly DBExpressContext _context;

        public ShippingFeesController(DBExpressContext context)
        {
            _context = context;
        }

        // GET: api/ShippingFee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShippingFee>>> GetShippingFees()
        {
            return await _context.ShippingFees.ToListAsync();
        }

        // GET: api/ShippingFee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShippingFee>> GetShippingFee(Guid id)
        {
            var shippingFee = await _context.ShippingFees.FindAsync(id);

            if (shippingFee == null)
            {
                return NotFound();
            }

            return shippingFee;
        }

        // PUT: api/ShippingFee/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShippingFee(Guid id, ShippingFee shippingFee)
        {
            if (id != shippingFee.IDFee)
            {
                return BadRequest();
            }

            _context.Entry(shippingFee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippingFeeExists(id))
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

        // POST: api/ShippingFee
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShippingFee>> PostShippingFee([FromForm] ShippingFee shippingFee)
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
            _context.ShippingFees.Add(shippingFee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ShippingFeeExists(shippingFee.IDFee))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetShippingFee", new { id = shippingFee.IDFee }, shippingFee);
        }

        // DELETE: api/ShippingFee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShippingFee>> DeleteShippingFee(Guid id)
        {
            var shippingFee = await _context.ShippingFees.FindAsync(id);
            if (shippingFee == null)
            {
                return NotFound();
            }

            _context.ShippingFees.Remove(shippingFee);
            await _context.SaveChangesAsync();

            return shippingFee;
        }

        private bool ShippingFeeExists(Guid id)
        {
            return _context.ShippingFees.Any(e => e.IDFee == id);
        }
    }
}
