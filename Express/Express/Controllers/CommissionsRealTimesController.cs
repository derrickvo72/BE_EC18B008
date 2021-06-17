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
    public class CommissionsRealTimesController : ControllerBase
    {
        private readonly DBExpressContext _context;

        public CommissionsRealTimesController(DBExpressContext context)
        {
            _context = context;
        }

        // GET: api/CommissionsRealTime
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommissionsRealTime>>> GetCommissionsRealTimes()
        {
            return await _context.CommissionsRealTimes.ToListAsync();
        }
        // GET: api/CommissionsRealTime/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommissionsRealTime>> GetCommissionsRealTime(Guid id)
        {
            var commissionsRealTime = await _context.CommissionsRealTimes.FindAsync(id);

            if (commissionsRealTime == null)
            {
                return NotFound();
            }

            return commissionsRealTime;
        }

            // PUT: api/CommissionsRealTime/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
        public async Task<IActionResult> PutCommissionsRealTime(Guid id, CommissionsRealTime commissionsRealTime)
        {
            if (id != commissionsRealTime.IDComRT)
            {
                return BadRequest();
            }

            _context.Entry(commissionsRealTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommissionsRealTimeExists(id))
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

            // POST: api/CommissionsRealTime
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
        public async Task<ActionResult<CommissionsRealTime>> PostCommissionsRealTime([FromForm] CommissionsRealTime commissionsRealTime)
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
            _context.CommissionsRealTimes.Add(commissionsRealTime);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CommissionsRealTimeExists(commissionsRealTime.IDComRT))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCommissionsRealTime", new { id = commissionsRealTime.IDComRT}, commissionsRealTime);
        }

            // DELETE: api/CommissionsRealTime/5
            [HttpDelete("{id}")]
        public async Task<ActionResult<CommissionsRealTime>> DeleteCommissionsRealTime(Guid id)
        {
            var commissionsRealTime = await _context.CommissionsRealTimes.FindAsync(id);
            if (commissionsRealTime == null)
            {
                return NotFound();
            }

            _context.CommissionsRealTimes.Remove(commissionsRealTime);
            await _context.SaveChangesAsync();

            return commissionsRealTime;
        }

        private bool CommissionsRealTimeExists(Guid id)
        {
            return _context.CommissionsRealTimes.Any(e => e.IDComRT== id);
        }
    }
}
