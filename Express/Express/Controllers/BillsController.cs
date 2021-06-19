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
    public class BillsController : ControllerBase
    {
        private readonly DBExpressContext _context;

        public BillsController(DBExpressContext context)
        {
            _context = context;
        }

        // GET: api/Bill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bill>>> GetBills()
        {
            string companyId = HttpContext.Request.Query["companyId"].ToString();
            return await _context.Bills.Where(bill => string.IsNullOrEmpty(companyId) ? true : bill.Compid == companyId).ToListAsync();
        }

        // GET: api/Bill/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> GetBill(String id)
        {
            var bill = await _context.Bills.FindAsync(id);

            if (bill == null)
            {
                return NotFound();
            }

            return bill;
        }
        // GET: api/Bills/searchsendphone
        [HttpGet("searchsendphone")]
        public IActionResult SearchBySendPhone([FromForm] string sendPhone)
        {
            var bill = _context.Bills.Where(x => x.SendPhone.Contains(sendPhone)).ToList();

            return Ok(bill);
        }
        // GET: api/Bills/searchreceivephone
        [HttpGet("searchreceivephone")]
        public IActionResult SearchByReceivePhone([FromForm] string seceivePhone)
        {
            var bill = _context.Bills.Where(x => x.ReceivePhone.Contains(seceivePhone)).ToList();

            return Ok(bill);
        }
        // PUT: api/Bill/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBill(string id, Bill bill)
        {
            if (id != bill.IDBill)
            {
                return BadRequest();
            }

            _context.Entry(bill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillExists(id))
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

        // POST: api/Bill
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bill>> PostBill([FromForm] Bill bill)
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
            _context.Bills.Add(bill);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BillExists(bill.IDBill))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBill", new { id = bill.IDBill }, bill);
        }

        // DELETE: api/Bill/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bill>> DeleteBill(string id)
        {
            var bill = await _context.Bills.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }

            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();

            return bill;
        }

        private bool BillExists(string id)
        {
            return _context.Bills.Any(e => e.IDBill == id);
        }
    }
}
