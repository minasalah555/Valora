using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Valora.Models;
using Valora.ViewModels;

namespace Valora.Controllers
{
    public class AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser>signInManager): Controller
    {
        // register
        // login 
        //logout
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel registerUserViewModel)
        {
            // check model is valid
            if (ModelState.IsValid)
            {
                // create User 
                // mapping  
                // in the Future We Will Use AutoMapper
                ApplicationUser appUser = new ApplicationUser()
                {
                    UserName = registerUserViewModel.UserName,
                    Email = registerUserViewModel.Email,
                };
                // save user in Database 
             IdentityResult result
                    =await userManager.CreateAsync(appUser, registerUserViewModel.Password);
                if (result.Succeeded)
                {
                      // Create Cookie 
                    await signInManager.SignInAsync(appUser,isPersistent:false);
                    return RedirectToAction("Privacy", "Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
               
            }

            return View("Register",registerUserViewModel);
        
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel loginUserViewModel)
        {
            if (ModelState.IsValid)
            {
                // check
               ApplicationUser appUser= await userManager.FindByNameAsync(loginUserViewModel.UserName);
                if (appUser != null)
                {
                 bool isExits=
                        await userManager.CheckPasswordAsync(appUser,loginUserViewModel.Password);
                    if (isExits)
                    {
                        //List<Claim> Claims = new List<Claim>();
                        //Claims.Add(new Claim("Email", appUser.Email));
                        //await signInManager.SignInWithClaimsAsync(appUser, isPersistent: loginUserViewModel.RememberMe, Claims);

                        await signInManager.SignInAsync(appUser, isPersistent: loginUserViewModel.RememberMe);
                        return RedirectToAction("Privacy", "Home");
                    }

                }
                ModelState.AddModelError("", "Username Or Password is Wrong");
                //Cookie
            }

            return View("Login", loginUserViewModel);
        }

        public async Task<IActionResult> SignOut()
        {
           await signInManager.SignOutAsync();
            return View("Login");
        }
    }
}
