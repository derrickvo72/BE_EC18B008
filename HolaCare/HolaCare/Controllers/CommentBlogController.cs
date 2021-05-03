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
    public class CommentBlogController : ControllerBase
    {
        private readonly DBHolaContext _context;

        public CommentBlogController(DBHolaContext context)
        {
            _context = context;
        }

        // GET: api/CommentBlog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentBlog>>> GetCommentBlogs()
        {
            return await _context.CommentBlogs.ToListAsync();
        }

        // GET: api/CommentBlog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentBlog>> GetCommentBlog(string id)
        {
            var commentBlog = await _context.CommentBlogs.FindAsync(id);

            if (commentBlog == null)
            {
                return NotFound();
            }

            return commentBlog;
        }

        // PUT: api/CommentBlog/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentBlog(string id, CommentBlog commentBlog)
        {
            if (id != commentBlog.IDCmtBlog)
            {
                return BadRequest();
            }

            _context.Entry(commentBlog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentBlogExists(id))
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

        // POST: api/CommentBlog
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CommentBlog>> PostCommentBlog(CommentBlog commentBlog)
        {
            _context.CommentBlogs.Add(commentBlog);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CommentBlogExists(commentBlog.IDCmtBlog))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCommentBlog", new { id = commentBlog.IDCmtBlog }, commentBlog);
        }

        // DELETE: api/CommentBlog/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommentBlog>> DeleteCommentBlog(string id)
        {
            var commentBlog = await _context.CommentBlogs.FindAsync(id);
            if (commentBlog == null)
            {
                return NotFound();
            }

            _context.CommentBlogs.Remove(commentBlog);
            await _context.SaveChangesAsync();

            return commentBlog;
        }

        private bool CommentBlogExists(string id)
        {
            return _context.CommentBlogs.Any(e => e.IDCmtBlog == id);
        }
    }
}
