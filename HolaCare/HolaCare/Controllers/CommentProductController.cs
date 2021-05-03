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
    public class CommentProductController : ControllerBase
    {
        private readonly DBHolaContext _context;

        public CommentProductController(DBHolaContext context)
        {
            _context = context;
        }

        // GET: api/CommentProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentProduct>>> GetCommentProducts()
        {
            return await _context.CommentProducts.ToListAsync();
        }

        // GET: api/CommentProduct/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentProduct>> GetCommentProduct(string id)
        {
            var commentProduct = await _context.CommentProducts.FindAsync(id);

            if (commentProduct == null)
            {
                return NotFound();
            }

            return commentProduct;
        }

        // PUT: api/CommentProduct/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentProduct(string id, CommentProduct commentProduct)
        {
            if (id != commentProduct.IDCmtProduct)
            {
                return BadRequest();
            }

            _context.Entry(commentProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentProductExists(id))
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

        // POST: api/CommentProduct
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CommentProduct>> PostCommentProduct(CommentProduct commentProduct)
        {
            _context.CommentProducts.Add(commentProduct);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CommentProductExists(commentProduct.IDCmtProduct))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCommentProduct", new { id = commentProduct.IDCmtProduct }, commentProduct);
        }

        // DELETE: api/CommentProduct/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommentProduct>> DeleteCommentProduct(string id)
        {
            var commentProduct = await _context.CommentProducts.FindAsync(id);
            if (commentProduct == null)
            {
                return NotFound();
            }

            _context.CommentProducts.Remove(commentProduct);
            await _context.SaveChangesAsync();

            return commentProduct;
        }

        private bool CommentProductExists(string id)
        {
            return _context.CommentProducts.Any(e => e.IDCmtProduct == id);
        }
    }
}
