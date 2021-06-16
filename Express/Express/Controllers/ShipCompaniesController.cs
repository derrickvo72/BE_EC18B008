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
    public class ShipCompaniesController : ControllerBase
    {
        private readonly DBExpressContext _context;

        public ShipCompaniesController(DBExpressContext context)
        {
            _context = context;
        }

        // GET: api/ShipCompany
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipCompany>>> GetShipCompanies()
        {
            return await _context.ShipCompanies.ToListAsync();
        }

        // GET: api/ShipCompany/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShipCompany>> GetShipCompany(string id)
        {
            var shipCompany = await _context.ShipCompanies.FindAsync(id);

            if (shipCompany == null)
            {
                return NotFound();
            }

            return shipCompany;
        }

        // PUT: api/ShipCompany/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipCompany(Guid id, ShipCompany shipCompany)
        {
            if (id != shipCompany.IDCompany)
            {
                return BadRequest();
            }

            _context.Entry(shipCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipCompanyExists(id))
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

        // POST: api/ShipCompany
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShipCompany>> PostShipCompany([FromForm] ShipCompany shipCompany)
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
            _context.ShipCompanies.Add(shipCompany);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ShipCompanyExists(shipCompany.IDCompany))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetShipCompany", new { id = shipCompany.IDCompany }, shipCompany);
        }

        // DELETE: api/ShipCompany/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShipCompany>> DeleteShipCompany(string id)
        {
            var shipCompany = await _context.ShipCompanies.FindAsync(id);
            if (shipCompany == null)
            {
                return NotFound();
            }

            _context.ShipCompanies.Remove(shipCompany);
            await _context.SaveChangesAsync();

            return shipCompany;
        }

        private bool ShipCompanyExists(Guid id)
        {
            return _context.ShipCompanies.Any(e => e.IDCompany == id);
        }
    }
}
