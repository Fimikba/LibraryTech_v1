using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryTechWebApp.Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using LibraryTechWebApp.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using LibraryTechWebApp.BusinessLogic;
using LibraryTechWebApp.DataAccessLayer;
using System.Security.Claims;

namespace WebAppWithAuth2.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUserModel> _userManager;
        private ILtSqlRepositoryable _repository;
        private SignInManager<AppUserModel> _signInManager;
        private Cart _cart;

        public AccountController(ILtSqlRepositoryable repository, UserManager<AppUserModel> userManager, SignInManager<AppUserModel> signInManager, Cart cartService)
        {
            _repository = repository;
            _userManager = userManager;
            _signInManager = signInManager;
            _cart = cartService;
        }
        
        public IActionResult Login(string ReturnUrl)
        {
            TempData["ReturnUrlFromLogin"] = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                AppUserModel user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        var userFull = _repository.Users.FirstOrDefault(u => u.Id == user.Id);
                        var listToRemove = new List<BookAsCartRecord>();
                        foreach (var record in _cart.Records)
                        {
                            if (userFull.Books.FirstOrDefault(b => b.BookId == record.BookId) != null) listToRemove.Add(record);
                        }
                        foreach (var recordToRemove in listToRemove)
                        {
                            _cart.Remove(recordToRemove);
                        }

                        string returnUrl = (string)TempData["ReturnUrlFromLogin"];
                        if (returnUrl == "/PersonalAccount/BuyBooks")
                            return RedirectToAction("Index", "Cart");
                        if (returnUrl == "/")
                            return RedirectToAction("Index", "PersonalAccount");
                        return Redirect(returnUrl);
                    }
                }
                ModelState.AddModelError("", "Invalid user email or password");
            }
            return View(model);
        }
        
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}