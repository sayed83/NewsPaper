using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BangladeshToday.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public IActionResult UserHome()
        {
            return View();
        }

        // Sha One Encryption
        private static string CalculateSha1(string text)
        {
            var enc = Encoding.GetEncoding(65001); // utf-8 code page
            byte[] buffer = enc.GetBytes(text);

            var sha1 = System.Security.Cryptography.SHA1.Create();

            var hash = sha1.ComputeHash(buffer);

            return enc.GetString(hash);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("UserLogin", "Login");
        }
    }
}