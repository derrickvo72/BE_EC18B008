using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HolaCare.Models;

namespace HolaCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngreProductController : ControllerBase
    {
        private readonly DBHolaContext _context;

        public IngreProductController(DBHolaContext context)
        {
            _context = context;
        }

        // GET: api/IngreProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngreProduct>>> GetIngreProducts()
        {
            return await _context.IngreProducts.ToListAsync();
        }

        // GET: api/IngreProduct/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngreProduct>> GetIngreProduct(string id)
        {
            var ingreProduct = await _context.IngreProducts.FindAsync(id);

            if (ingreProduct == null)
            {
                return NotFound();
            }

            return ingreProduct;
        }

        // PUT: api/IngreProduct/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngreProduct(string id, IngreProduct ingreProduct)
        {
            if (id != ingreProduct.IDIngre)
            {
                return BadRequest();
            }

            _context.Entry(ingreProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngreProductExists(id))
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

        // POST: api/IngreProduct
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IngreProduct>> PostIngreProduct(IngreProduct ingreProduct)
        {
            _context.IngreProducts.Add(ingreProduct);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IngreProductExists(ingreProduct.IDIngre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIngreProduct", new { id = ingreProduct.IDIngre }, ingreProduct);
        }

        // DELETE: api/IngreProduct/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IngreProduct>> DeleteIngreProduct(string id)
        {
            var ingreProduct = await _context.IngreProducts.FindAsync(id);
            if (ingreProduct == null)
            {
                return NotFound();
            }

            _context.IngreProducts.Remove(ingreProduct);
            await _context.SaveChangesAsync();

            return ingreProduct;
        }

        private bool IngreProductExists(string id)
        {
            return _context.IngreProducts.Any(e => e.IDIngre == id);
        }
    }
}
