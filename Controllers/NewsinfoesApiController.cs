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
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("api/NewsinfoesApi")]
    public class NewsinfoesApiController : Controller
    {
        private readonly bangladeshtodayContext _context;

        public NewsinfoesApiController(bangladeshtodayContext context)
        {
            _context = context;
        }

        //Distinct Categories
        [HttpGet("GetCategories")]
        public List<CategoryColor> GetCategories()
        {
            List<CategoryColor> b1 = new List<CategoryColor>();
            //var b=(from a in _context.Newsinfo orderby a.Category ascending select new { a.Category, a.Color }).Distinct().ToList();
            var b=(from a in _context.Newsinfo orderby a.Category select new { a.Category, a.Color }).ToList().Distinct();
            
            foreach(var c in b)
            {
                CategoryColor b2 = new CategoryColor();
                b2.Category = c.Category;
                b2.Color = c.Color;
                b1.Add(b2);
            }
            return b1;
        }

        // Sub Feature News
        [HttpGet("GetSubFeatureNews")]
        public IEnumerable<Newsinfo> GetSubFeatureNews()
        {
            return (from a in _context.Newsinfo orderby a.Datetime descending where a.SubFeatureNews == "Yes" select a).Distinct().ToList();
        }


        // Color
        //[HttpGet("GetColor")]
        //public List<string> GetColor()
        //{
        //    return (from a in _context.Newsinfo select a.Color).ToList();
        //}


        // GetFeatureNewsByHours
        //[HttpGet("GetFeatureNewsByHours")]
        //public IEnumerable<Newsinfo> GetFeatureNewsByHours()
        //{

        //    return (from a in _context.Newsinfo orderby a.Datetime descending where a.FeatureNews == "Yes" && DateTime.Now.Hour < 6 select a).Distinct().Take(2).ToList();
        //}


        // MoreNews
        [HttpGet("MoreNews")]
        public List<Newsinfo> MoreNews()
        {
            return (from a in _context.Newsinfo orderby a.Datetime where DateTime.Now.Hour < 6 select a).Distinct().Take(4).ToList();
        }



        // Latest Categorywise news
        [HttpGet("CategorywiseNews")]
        public List<Newsinfo> CategorywiseNews()
        {
            List<Newsinfo> a1 = new List<Newsinfo>();
            Newsinfo b = new Newsinfo();
            var Sports = (from a in _context.Newsinfo orderby a.Datetime descending where a.Category == "Sports" select a).LastOrDefault();
            b.Newsserial = Sports.Newsserial;
            b.Title = Sports.Title;
            b.CaptionPicture = Sports.CaptionPicture;
            b.Datetime = Sports.Datetime;
            b.Category = Sports.Category;

            a1.Add(b);
            Newsinfo b1 = new Newsinfo();
            Sports = (from a in _context.Newsinfo orderby a.Datetime descending where a.Category == "Entertainment" select a).LastOrDefault();
            b1.Newsserial = Sports.Newsserial;
            b1.Title = Sports.Title;
            b1.CaptionPicture = Sports.CaptionPicture;
            b1.Datetime = Sports.Datetime;
            b1.Category = Sports.Category;

            a1.Add(b1);
            b = new Newsinfo();
            Sports = (from a in _context.Newsinfo orderby a.Datetime descending where a.Category == "Politics" select a).LastOrDefault();
            b.Newsserial = Sports.Newsserial;
            b.Title = Sports.Title;
            b.CaptionPicture = Sports.CaptionPicture;
            b.Datetime = Sports.Datetime;
            b.Category = Sports.Category;

            a1.Add(b);
            b = new Newsinfo();
            Sports = (from a in _context.Newsinfo orderby a.Datetime descending where a.Category == "National" select a).LastOrDefault();
            b.Newsserial = Sports.Newsserial;
            b.Title = Sports.Title;
            b.CaptionPicture = Sports.CaptionPicture;
            b.Datetime = Sports.Datetime;
            b.Category = Sports.Category;

            a1.Add(b);

            //var Entertainment = (from a in _context.Newsinfo orderby a.Datetime descending where a.Category == "Entertainment" select a).ToList().LastOrDefault();
            //var Politics = (from a in _context.Newsinfo orderby a.Datetime descending where a.Category == "Politics" select a).ToList().LastOrDefault();
            //var National = (from a in _context.Newsinfo orderby a.Datetime descending where a.Category == "National" select a).ToList().LastOrDefault();

            //return (from a in _context.Newsinfo orderby a.Datetime descending where a.Category == "Sports" where a.Category == "Entertainment" where a.Category == "Politics" where a.Category == "National" select a).Distinct().LastOrDefault();
            return a1;
            
        }




        // HotNews Of Business Category
        [HttpGet("GetNewByCategory")]
        public List<Newsinfo> GetNewByCategory(string cat)
        {
            return (from a in _context.Newsinfo where  a.Category == cat select a).Distinct().ToList();
        }



        // HotNews Of Business Category
        [HttpGet("GetBusinessCategory")]
        public List<Newsinfo> GetBusinessCategory()
        {
            return (from a in _context.Newsinfo where a.HotNews == "Yes" && a.Category=="Business" select a).Distinct().ToList();
        }

        // HotNews of National
        [HttpGet("GetNationalCategory")]
        public List<Newsinfo> GetNationalCategory()
        {
            return (from a in _context.Newsinfo where a.HotNews == "Yes" && a.Category == "National" select a).Distinct().ToList();
        }



        // HotNews of InterNational
        [HttpGet("GetInternationalCategory")]
        public List<Newsinfo> GetInternationalCategory()
        {
            return (from a in _context.Newsinfo where a.HotNews == "Yes" && a.Category == "International" select a).Distinct().ToList();
        }


        // HotNews of Entertainment
        [HttpGet("GetEntertainmentCategory")]
        public List<Newsinfo> GetEntertainmentCategory()
        {
            return (from a in _context.Newsinfo where a.HotNews == "Yes" && a.Category == "Entertainment" select a).Distinct().ToList();
        }


        // Hot News
        [HttpGet("GetHotNews")]
        public List<Newsinfo> GetHotNews()
        {
            return (from a in _context.Newsinfo where a.HotNews == "Yes" select a).Distinct().ToList();
        }


        // Lastest News By Date
        [HttpGet("GetLatestNews")]
        public List<Newsinfo> GetLatestNews()
        {
            return (from a in _context.Newsinfo orderby a.Datetime descending select a).ToList();
        }


        // Lastest News By Date
        [HttpGet("EditorPicks")]
        public List<Newsinfo> EditorPicks()
        {
            return (from a in _context.Newsinfo where a.Editor == "Yes" select a).ToList();
        }


        // Politics News
        [HttpGet("GetPoliticsCategory")]
        public List<Newsinfo> GetPoliticsCategory()
        {
            return (from a in _context.Newsinfo orderby a.Datetime descending where a.Category == "Politics" select a).Distinct().ToList();
        }


        // Sports News
        [HttpGet("GetSportsCategory")]
        public List<Newsinfo> GetSportsCategory()
        {
            return (from a in _context.Newsinfo where a.Category == "Sports" select a).Distinct().ToList();
        }

        // Science and Tech Category
        [HttpGet("GetScienceTechCategory")]
        public List<Newsinfo> GetScienceTechCategory()
        {
            return (from a in _context.Newsinfo where a.Category == "Science & Tech" select a).Distinct().ToList();
        }

        // Science and Tech Category
        [HttpGet("GetArtandCultureCategory")]
        public List<Newsinfo> GetArtandCultureCategory()
        {
            return (from a in _context.Newsinfo where a.Category == "Art & Culture" select a).Distinct().ToList();
        }

        // Science and Tech Category
        //[HttpGet("GetKeyword")]
        //public List<Newsinfo> GetKeyword()
        //{
        //    Newsinfo soemthing = new Newsinfo();
        //    var kw = soemthing.Keyword;
        //    return (from a in _context.Newsinfo orderby a.Keyword where a.Keyword== kw select a).Distinct().Take(10).ToList();
        //}


        // GET: api/NewsinfoesApi
        [HttpGet]
        public IEnumerable<Newsinfo> GetNewsinfo()
        {
            return _context.Newsinfo;
        }

        // GET: api/NewsinfoesApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNewsinfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newsinfo = await _context.Newsinfo.SingleOrDefaultAsync(m => m.Newsserial == id);

            if (newsinfo == null)
            {
                return NotFound();
            }

            return Ok(newsinfo);
        }

        // PUT: api/NewsinfoesApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewsinfo([FromRoute] int id, [FromBody] Newsinfo newsinfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newsinfo.Newsserial)
            {
                return BadRequest();
            }

            _context.Entry(newsinfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsinfoExists(id))
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

        // POST: api/NewsinfoesApi
        [HttpPost]
        public async Task<IActionResult> PostNewsinfo(Newsinfo newsinfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Newsinfo.Add(newsinfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNewsinfo", new { id = newsinfo.Newsserial }, newsinfo);
        }

        // DELETE: api/NewsinfoesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewsinfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newsinfo = await _context.Newsinfo.SingleOrDefaultAsync(m => m.Newsserial == id);
            if (newsinfo == null)
            {
                return NotFound();
            }

            _context.Newsinfo.Remove(newsinfo);
            await _context.SaveChangesAsync();

            return Ok(newsinfo);
        }

        private bool NewsinfoExists(int id)
        {
            return _context.Newsinfo.Any(e => e.Newsserial == id);
        }
    }
}