using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LibraryTechWebApp.Models;
using LibraryTechWebApp.Domains;
using Microsoft.AspNetCore.Authorization;

namespace WebAppWithAuth2.Controllers
{
    [Authorize(Roles = "Admins")]
    public class RolesController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<AppUserModel> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<AppUserModel> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index() => View(_roleManager.Roles.ToList());
        
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(AppRoleCreateModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Roles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(string roleId)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return View("Error");
            }

            var members = new List<AppUserModel>();
            var nonMembers = new List<AppUserModel>();
            foreach (var user in _userManager.Users.ToList())
            {
                bool isInRole = await _userManager.IsInRoleAsync(user, role.Name);
                if (isInRole) members.Add(user);
                else nonMembers.Add(user);
            }

            AppRoleEditModel model = new AppRoleEditModel()
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };

            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(AppRoleModifyModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd)
                {
                    AppUserModel user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        IdentityResult result =  await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                            return await Edit(model.RoleId);
                        }
                    }
                }
                foreach (var userId in model.IdsToDelite)
                {
                    AppUserModel user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        IdentityResult result =  await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                            return await Edit(model.RoleId);
                        }
                    }
                }

                return RedirectToAction("Index", "Roles");
            }
            
            return await Edit(model.RoleId);
        }
    }
}