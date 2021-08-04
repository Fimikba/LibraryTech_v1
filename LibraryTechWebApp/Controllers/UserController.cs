using System.Linq;
using System.Threading.Tasks;
using LibraryTechWebApp.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LibraryTechWebApp.Models;
using LibraryTechWebApp.BusinessLogic;
using Microsoft.AspNetCore.Authorization;

namespace LibraryTechWebApp.Controllers
{
    public class UserController : Controller
    {
        private UserManager<AppUserModel> _userManager;

        public UserController(UserManager<AppUserModel> userManager)
        {
            _userManager = userManager;
        }

        [Authorize(Roles = "Admins")]
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            
            return View(users);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(AppUserModelCreate model)
        {
            if (ModelState.IsValid)
            {
                AppUserModel user = new AppUserModel()
                {
                    UserName = model.Name,
                    Email = model.Email
                };

                IdentityResult resultCreate = await _userManager.CreateAsync(user, model.Password);
                if (resultCreate.Succeeded)
                {
                    IdentityResult resultAddRole = await _userManager.AddToRoleAsync(user, "Users");
                    if (!resultAddRole.Succeeded) return RedirectToAction("Error", "Home");
                    return RedirectToAction("Login", "Account", new { ReturnUrl = "/PersonalAccount/Index" });
                }
                else
                {
                    foreach (var error in resultCreate.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }

        [Authorize(Roles = "Admins")]
        public IActionResult CreateForAdmin()
        {
            return View("CreateForAdmin");
        }
        [Authorize(Roles = "Admins")]
        [HttpPost]
        public async Task<IActionResult> CreateForAdmin(AppUserModelCreate model)
        {
            if (ModelState.IsValid)
            {
                AppUserModel user = new AppUserModel()
                {
                    UserName = model.Name,
                    Email = model.Email
                };

                IdentityResult resultCreate = await _userManager.CreateAsync(user, model.Password);
                if (resultCreate.Succeeded)
                {
                    IdentityResult resultAddRole = await _userManager.AddToRoleAsync(user, "Users");
                    if (!resultAddRole.Succeeded) return RedirectToAction("Error", "Home");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    foreach (var error in resultCreate.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }
    }
}