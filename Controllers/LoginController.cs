using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BangladeshToday.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BangladeshToday.Controllers
{
    public class LoginController : Controller
    {
       

        UserDataAccessLayer objUser = new UserDataAccessLayer();
        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterUser([Bind] UserDetails user)
        {
            if (ModelState.IsValid)
            {
                string RegistrationStatus = objUser.RegisterUser(user);
                if (RegistrationStatus == "Success")
                {
                    ModelState.Clear();
                    TempData["Success"] = "Registration Successful!";
                    return View();
                }
                else
                {
                    TempData["Fail"] = "This User ID already exists. Registration Failed.";
                    return View();
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult UserLogin()
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserLogin([Bind] UserDetails user)
        {
            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");
            if (ModelState.IsValid)
            {
                string LoginStatus = objUser.ValidateLogin(user);
                if (LoginStatus == "Success")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserID)
                    };
                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                    return View();
                }
            }
            else
                return View();
        }


    }
}