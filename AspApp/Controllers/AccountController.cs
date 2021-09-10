using AspApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
       // private readonly UserManager<IdentityUser> _usermanager;
        //private readonly SignInManager<IdentityUser> _signInManager;
       
        private readonly UserManager<AppUser> _usermanager;
        private readonly SignInManager<AppUser> _signInManager;
       //bytt
        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, AppDbContext context)
        {
            _context = context;
            _usermanager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return RedirectToAction("index", "start");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    FirstName=model.FirstName,
                    LastName=model.LastName,
                    UserName = model.Email,
                    
                    Email = model.Email,
                   
                    
                };
                //passwordet ska hashas
                var result = await _usermanager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("start", "start");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                var result = await _signInManager.PasswordSignInAsync(model.Email,model.Password,false,false);
                if (result.Succeeded)
                {
                    
                    return RedirectToAction("start", "start");
                }
                ModelState.AddModelError(string.Empty, "Ivalid loginattempt");
                
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "start");
        }
    }
}
