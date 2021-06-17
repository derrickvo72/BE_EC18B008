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
    public class ProvincesController : ControllerBase
    {
        private readonly DBExpressContext _context;

        public ProvincesController(DBExpressContext context)
        {
            _context = context;
        }

        // GET: api/Province
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Provinces>>> GetProvinces()
        {
            return await _context.Provinces.ToListAsync();
        }

        // GET: api/Province/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Provinces>> GetProvince(Guid id)
        {
            var province = await _context.Provinces.FindAsync(id);

            if (province == null)
            {
                return NotFound();
            }

            return province;
        }

        // PUT: api/Province/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvince(Guid id, Provinces province)
        {
            if (id != province.IDProvince)
            {
                return BadRequest();
            }

            _context.Entry(province).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinceExists(id))
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

        // POST: api/Province
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Provinces>> PostProvince([FromForm] Provinces province)
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
            _context.Provinces.Add(province);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProvinceExists(province.IDProvince))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProvince", new { id = province.IDProvince }, province);
        }

        // DELETE: api/Province/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Provinces>> DeleteProvince(Guid id)
        {
            var province = await _context.Provinces.FindAsync(id);
            if (province == null)
            {
                return NotFound();
            }

            _context.Provinces.Remove(province);
            await _context.SaveChangesAsync();

            return province;
        }

        private bool ProvinceExists(Guid id)
        {
            return _context.Provinces.Any(e => e.IDProvince == id);
        }
    }
}
