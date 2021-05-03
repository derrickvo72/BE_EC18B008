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
    public class IngredientDetailController : ControllerBase
    {
        private readonly DBHolaContext _context;

        public IngredientDetailController(DBHolaContext context)
        {
            _context = context;
        }

        // GET: api/IngredientDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientDetail>>> GetIngredientDetails()
        {
            return await _context.IngredientDetails.ToListAsync();
        }

        // GET: api/IngredientDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientDetail>> GetIngredientDetail(string id)
        {
            var ingredientDetail = await _context.IngredientDetails.FindAsync(id);

            if (ingredientDetail == null)
            {
                return NotFound();
            }

            return ingredientDetail;
        }

        // PUT: api/IngredientDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredientDetail(string id, IngredientDetail ingredientDetail)
        {
            if (id != ingredientDetail.IDIngre)
            {
                return BadRequest();
            }

            _context.Entry(ingredientDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientDetailExists(id))
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

        //POST: api/IngredientDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IngredientDetail>> PostIngredientDetail(IngredientDetail ingredientDetail)
        {
            _context.IngredientDetails.Add(ingredientDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IngredientDetailExists(ingredientDetail.IDIngre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIngredientDetail", new { id = ingredientDetail.IDIngre }, ingredientDetail);
        }

        // DELETE: api/IngredientDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IngredientDetail>> DeleteIngredientDetail(string id)
        {
            var ingredientDetail = await _context.IngredientDetails.FindAsync(id);
            if (ingredientDetail == null)
            {
                return NotFound();
            }

            _context.IngredientDetails.Remove(ingredientDetail);
            await _context.SaveChangesAsync();

            return ingredientDetail;
        }

        private bool IngredientDetailExists(string id)
        {
            return _context.IngredientDetails.Any(e => e.IDIngre == id);
        }
    }
}
