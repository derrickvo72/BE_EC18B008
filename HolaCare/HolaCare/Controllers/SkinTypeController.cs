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
    public class SkinTypeController : ControllerBase
    {
        private readonly DBHolaContext _context;

        public SkinTypeController(DBHolaContext context)
        {
            _context = context;
        }
        //12/3
        // GET: api/SkinType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkinType>>> GetSkinTypes()
        {
            return await _context.SkinTypes.ToListAsync();
        }

        // GET: api/SkinType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SkinType>> GetSkinType(string id)
        {
            var skinType = await _context.SkinTypes.FindAsync(id);

            if (skinType == null)
            {
                return NotFound();
            }

            return skinType;
        }

        // PUT: api/SkinType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkinType(string id, SkinType skinType)
        {
            if (id != skinType.IDSkinType)
            {
                return BadRequest();
            }

            _context.Entry(skinType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkinTypeExists(id))
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

        // POST: api/SkinType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SkinType>> PostSkinType(SkinType skinType)
        {
            _context.SkinTypes.Add(skinType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SkinTypeExists(skinType.IDSkinType))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSkinType", new { id = skinType.IDSkinType }, skinType);
        }

        // DELETE: api/SkinType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SkinType>> DeleteSkinType(string id)
        {
            var skinType = await _context.SkinTypes.FindAsync(id);
            if (skinType == null)
            {
                return NotFound();
            }

            _context.SkinTypes.Remove(skinType);
            await _context.SaveChangesAsync();

            return skinType;
        }

        private bool SkinTypeExists(string id)
        {
            return _context.SkinTypes.Any(e => e.IDSkinType == id);
        }
    }
}
