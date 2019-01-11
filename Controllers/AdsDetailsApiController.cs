using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BangladeshToday.Models;
using Microsoft.AspNetCore.Cors;

namespace BangladeshToday.Controllers
{
 
    [Produces("application/json")]
    [Route("api/AdsDetailsApi")]
        public class AdsDetailsApiController : Controller
    {
        private readonly bangladeshtodayContext _context;

        public AdsDetailsApiController(bangladeshtodayContext context)
        {
            _context = context;
        }

        // GET: api/AdsDetailsApi
        [HttpGet]
        public IEnumerable<AdsDetails> GetAdsDetails()
        {
            return _context.AdsDetails;
        }

        // GET: api/AdsDetailsApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdsDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adsDetails = await _context.AdsDetails.SingleOrDefaultAsync(m => m.Id == id);

            if (adsDetails == null)
            {
                return NotFound();
            }

            return Ok(adsDetails);
        }

        // PUT: api/AdsDetailsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdsDetails([FromRoute] int id, [FromBody] AdsDetails adsDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adsDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(adsDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdsDetailsExists(id))
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

        // POST: api/AdsDetailsApi
        [HttpPost]
        public async Task<IActionResult> PostAdsDetails([FromBody] AdsDetails adsDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AdsDetails.Add(adsDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdsDetails", new { id = adsDetails.Id }, adsDetails);
        }

        // DELETE: api/AdsDetailsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdsDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adsDetails = await _context.AdsDetails.SingleOrDefaultAsync(m => m.Id == id);
            if (adsDetails == null)
            {
                return NotFound();
            }

            _context.AdsDetails.Remove(adsDetails);
            await _context.SaveChangesAsync();

            return Ok(adsDetails);
        }

        private bool AdsDetailsExists(int id)
        {
            return _context.AdsDetails.Any(e => e.Id == id);
        }
    }
}