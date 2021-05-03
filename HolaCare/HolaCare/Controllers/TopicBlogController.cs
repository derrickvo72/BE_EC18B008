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
    public class TopicBlogController : ControllerBase
    {
        private readonly DBHolaContext _context;

        public TopicBlogController(DBHolaContext context)
        {
            _context = context;
        }

        // GET: api/TopicBlog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicBlog>>> GetTopicBlogs()
        {
            return await _context.TopicBlogs.ToListAsync();
        }

        // GET: api/TopicBlog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TopicBlog>> GetTopicBlog(string id)
        {
            var topicBlog = await _context.TopicBlogs.FindAsync(id);

            if (topicBlog == null)
            {
                return NotFound();
            }

            return topicBlog;
        }

        // PUT: api/TopicBlog/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopicBlog(string id, TopicBlog topicBlog)
        {
            if (id != topicBlog.IDTopicBlog)
            {
                return BadRequest();
            }

            _context.Entry(topicBlog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicBlogExists(id))
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

        // POST: api/TopicBlog
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TopicBlog>> PostTopicBlog(TopicBlog topicBlog)
        {
            _context.TopicBlogs.Add(topicBlog);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TopicBlogExists(topicBlog.IDTopicBlog))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTopicBlog", new { id = topicBlog.IDTopicBlog }, topicBlog);
        }

        // DELETE: api/TopicBlog/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TopicBlog>> DeleteTopicBlog(string id)
        {
            var topicBlog = await _context.TopicBlogs.FindAsync(id);
            if (topicBlog == null)
            {
                return NotFound();
            }

            _context.TopicBlogs.Remove(topicBlog);
            await _context.SaveChangesAsync();

            return topicBlog;
        }

        private bool TopicBlogExists(string id)
        {
            return _context.TopicBlogs.Any(e => e.IDTopicBlog == id);
        }
    }
}
