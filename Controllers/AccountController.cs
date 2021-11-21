using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Probeaufgabe.ViewModels;

namespace Probeaufgabe.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
           _signInManager = signInManager;
        }


        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        
        public async Task<ActionResult>  Create(RegisterUserViewModel model )
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result =await _userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent:false);
                    return RedirectToAction("index", "Company");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        // GET: AccountController/Edit/5
        public ActionResult Login(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        
        public async Task<ActionResult>  Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password,isPersistent: true, false);
                if (result.Succeeded)
                {
                  
                    return RedirectToAction("index", "Company");
                }

                    ModelState.AddModelError(string.Empty, "Invalid Login Attemp");
                
            }
            return View(model);
        }


        // POST: AccountController/Delete/5
        [HttpPost]
        
        public async Task<ActionResult>  Logout()
        {
           await _signInManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        }
    }
}
