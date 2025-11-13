using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Valora.Models;
using Valora.ViewModels;

namespace Valora.Controllers
{
    public class RoleController(RoleManager<ApplicationRole> roleManager) : Controller
    { 
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(AddRoleViewModel addRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationRole role = new ApplicationRole();
                role.Name = addRoleViewModel.RoleName;
               IdentityResult result=    await roleManager.CreateAsync(role);
                if (result.Succeeded) {
                    TempData["SuccessMessage"] = $"Role ({addRoleViewModel.RoleName}) added successfully!";
                    return RedirectToAction("AddRole");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return View("AddRole", addRoleViewModel);
        }
    }
}
