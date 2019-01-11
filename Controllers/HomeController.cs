using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BangladeshToday.Models;

namespace BangladeshToday.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}


        private readonly bangladeshtodayContext _context;

        public HomeController(bangladeshtodayContext context)
        {
            _context = context;
        }



        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        // Index Uses for Showing Slide Images
        public IActionResult Index()
        {
            ViewBag.FeatureNews=(from a in _context.Newsinfo where a.FeatureNews == "Yes" orderby a.Datetime descending select a).Distinct().ToList().Take(4);
            ViewBag.allCategories = (from a in _context.Newsinfo orderby a.Category select a).Distinct().ToList();
            ViewBag.FeatureNewsByHours=(from a in _context.Newsinfo orderby a.Datetime descending select a).Distinct().ToList().Take(10);
            ViewBag.SubFeatureNews= (from a in _context.Newsinfo where a.SubFeatureNews == "Yes" orderby a.Datetime descending select a).Distinct().ToList().Take(2);
            ViewBag.VideoNews= (from a in _context.Videonews orderby a.Category, a.Datetime descending select a).ToList().Take(5);
            return View();
        }

        public IActionResult anotherIndex()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
