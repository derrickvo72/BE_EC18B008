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
    public class CommissionsRulesController : ControllerBase
    {
        private readonly DBExpressContext _context;

        public CommissionsRulesController(DBExpressContext context)
        {
            _context = context;
        }

        // GET: api/CommissionsRule
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommissionsRule>>> GetCommissionsRules()
        {
            return await _context.CommissionsRules.ToListAsync();
        }

        // GET: api/CommissionsRule/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommissionsRule>> GetCommissionsRule(Guid id)
        {
            var commissionsRule = await _context.CommissionsRules.FindAsync(id);

            if (commissionsRule == null)
            {
                return NotFound();
            }

            return commissionsRule;
        }

        // PUT: api/CommissionsRule/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommissionsRule(Guid id, CommissionsRule commissionsRule)
        {
            if (id != commissionsRule.IDComR)
            {
                return BadRequest();
            }

            _context.Entry(commissionsRule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommissionsRuleExists(id))
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

        // POST: api/CommissionsRule
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CommissionsRule>> PostCommissionsRule([FromForm] CommissionsRule commissionsRule)
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
            _context.CommissionsRules.Add(commissionsRule);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CommissionsRuleExists(commissionsRule.IDComR))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCommissionsRule", new { id = commissionsRule.IDComR }, commissionsRule);
        }

        // DELETE: api/CommissionsRule/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommissionsRule>> DeleteCommissionsRule(Guid id)
        {
            var commissionsRule = await _context.CommissionsRules.FindAsync(id);
            if (commissionsRule == null)
            {
                return NotFound();
            }

            _context.CommissionsRules.Remove(commissionsRule);
            await _context.SaveChangesAsync();

            return commissionsRule;
        }

        private bool CommissionsRuleExists(Guid id)
        {
            return _context.CommissionsRules.Any(e => e.IDComR == id);
        }
    }
}
