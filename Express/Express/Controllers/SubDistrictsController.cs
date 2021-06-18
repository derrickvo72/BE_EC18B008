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
    public class SubDistrictsController : ControllerBase
    {
        private readonly DBExpressContext _context;

        public SubDistrictsController(DBExpressContext context)
        {
            _context = context;
        }

        // GET: api/SubDistrict
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubDistricts>>> GetSubDistricts()
        {
            return await _context.SubDistricts.ToListAsync();
        }

        // GET: api/SubDistrict/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubDistricts>> GetSubDistrict(Guid id)
        {
            var subDistrict = await _context.SubDistricts.FindAsync(id);

            if (subDistrict == null)
            {
                return NotFound();
            }

            return subDistrict;
        }
        // GET: api/SubDistrict/search
        [HttpGet("search")]
        public IActionResult SearchByName([FromForm] string subDistrictName)
        {
            var subDistrict = _context.SubDistricts.Where(x => x.SubDistrictName.Contains(subDistrictName)).ToList();

            return Ok(subDistrict);
        }
        // PUT: api/SubDistrict/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubDistrict(string id, SubDistricts subDistrict)
        {
            if (id != subDistrict.IDSubDistrict)
            {
                return BadRequest();
            }

            _context.Entry(subDistrict).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubDistrictExists(id))
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

        // POST: api/SubDistrict
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SubDistricts>> PostSubDistrict([FromForm] SubDistricts subDistrict)
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
            _context.SubDistricts.Add(subDistrict);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubDistrictExists(subDistrict.IDSubDistrict))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSubDistrict", new { id = subDistrict.IDSubDistrict }, subDistrict);
        }

        // DELETE: api/SubDistrict/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubDistricts>> DeleteSubDistrict(string id)
        {
            var subDistrict = await _context.SubDistricts.FindAsync(id);
            if (subDistrict == null)
            {
                return NotFound();
            }

            _context.SubDistricts.Remove(subDistrict);
            await _context.SaveChangesAsync();

            return subDistrict;
        }

        private bool SubDistrictExists(string id)
        {
            return _context.SubDistricts.Any(e => e.IDSubDistrict == id);
        }
    }
}
