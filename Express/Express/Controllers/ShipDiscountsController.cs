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
    public class ShipDiscountsController : ControllerBase
    {
        private readonly DBExpressContext _context;

        public ShipDiscountsController(DBExpressContext context)
        {
            _context = context;
        }

        // GET: api/ShipDiscount
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipDiscount>>> GetShipDiscounts()
        {
            return await _context.ShipDiscounts.ToListAsync();
        }

        // GET: api/ShipDiscount/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShipDiscount>> GetShipDiscount(Guid id)
        {
            var shipDiscount = await _context.ShipDiscounts.FindAsync(id);

            if (shipDiscount == null)
            {
                return NotFound();
            }

            return shipDiscount;
        }

        // PUT: api/ShipDiscount/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipDiscount(Guid id, ShipDiscount shipDiscount)
        {
            if (id != shipDiscount.IDDis)
            {
                return BadRequest();
            }

            _context.Entry(shipDiscount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipDiscountExists(id))
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

        // POST: api/ShipDiscount
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShipDiscount>> PostShipDiscount([FromForm] ShipDiscount shipDiscount)
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
            _context.ShipDiscounts.Add(shipDiscount);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ShipDiscountExists(shipDiscount.IDDis))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetShipDiscount", new { id = shipDiscount.IDDis }, shipDiscount);
        }

        // DELETE: api/ShipDiscount/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShipDiscount>> DeleteShipDiscount(Guid id)
        {
            var shipDiscount = await _context.ShipDiscounts.FindAsync(id);
            if (shipDiscount == null)
            {
                return NotFound();
            }

            _context.ShipDiscounts.Remove(shipDiscount);
            await _context.SaveChangesAsync();

            return shipDiscount;
        }

        private bool ShipDiscountExists(Guid id)
        {
            return _context.ShipDiscounts.Any(e => e.IDDis == id);
        }
    }
}
