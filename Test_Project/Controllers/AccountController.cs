using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Test_Project.IRepository;
using Test_Project.Models;

namespace Test_Project.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserRepository _repository;
        public AccountController(IUserRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user,string returnurl)
        {
            try
            {
                User userLogged = _repository.IsLogin(user);
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, userLogged.Name),
                    new Claim(ClaimTypes.Role, userLogged.Role)

                }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                if (!string.IsNullOrEmpty(returnurl))
                {
                    return Redirect(returnurl);
                }
                else
                {
                    return RedirectToAction("Index", "Student");
                }
                
            }
            catch
            {
                @TempData["errorMsg"] = "Login failed, try again";
                return View();
            }
            
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
