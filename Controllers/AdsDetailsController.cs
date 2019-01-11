using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BangladeshToday.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BangladeshToday.Controllers
{
    public class AdsDetailsController : Controller
    {
        private readonly bangladeshtodayContext _context;


        public ActionResult Index3() {
            return View();
        }

        public AdsDetailsController(bangladeshtodayContext context)
        {
            _context = context;
        }

        // GET: AdsDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdsDetails.ToListAsync());
        }

        // GET: AdsDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adsDetails = await _context.AdsDetails
                .SingleOrDefaultAsync(m => m.Id == id);
            if (adsDetails == null)
            {
                return NotFound();
            }

            return View(adsDetails);
        }

        // GET: AdsDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdsDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,CompanyAddress,Companyurl,Picture,Title,Description,StartDate,EndDate,DailyRate,TotalPrice")] AdsDetails adsDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adsDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adsDetails);
        }

        // GET: AdsDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adsDetails = await _context.AdsDetails.SingleOrDefaultAsync(m => m.Id == id);
            if (adsDetails == null)
            {
                return NotFound();
            }
            return View(adsDetails);
        }

        // POST: AdsDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,CompanyAddress,Companyurl,Picture,Title,Description,StartDate,EndDate,DailyRate,TotalPrice")] AdsDetails adsDetails)
        {
            if (id != adsDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adsDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdsDetailsExists(adsDetails.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(adsDetails);
        }

        // GET: AdsDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adsDetails = await _context.AdsDetails
                .SingleOrDefaultAsync(m => m.Id == id);
            if (adsDetails == null)
            {
                return NotFound();
            }

            return View(adsDetails);
        }

        // POST: AdsDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adsDetails = await _context.AdsDetails.SingleOrDefaultAsync(m => m.Id == id);
            _context.AdsDetails.Remove(adsDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdsDetailsExists(int id)
        {
            return _context.AdsDetails.Any(e => e.Id == id);
        }



        // Uplode Files
        public ActionResult UploadFile(int id)
        {
            return View(_context.AdsDetails.Find(id));
        }

        [HttpPost, ActionName("UploadFile")]
        public ActionResult UploadFile(IFormFile file, int id)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return Content("file not selected");
                if (file.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Ads/" + file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    AdsDetails st = (from s in _context.AdsDetails where s.Id == id select s).First();
                    st.Picture = file.FileName;
                    _context.SaveChanges();
                }
                ViewBag.Message = "File Uploaded Successfully!!" + ":" + id;
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }
    }
}
