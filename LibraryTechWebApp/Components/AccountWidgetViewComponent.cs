using LibraryTechWebApp.DataAccessLayer;
using LibraryTechWebApp.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Components
{
    public class AccountWidgetViewComponent : ViewComponent
    {
        private ILtSqlRepositoryable _repository;
        private UserManager<AppUserModel> _userManager;
        private IActionContextAccessor _actionAccessor;

        public AccountWidgetViewComponent(ILtSqlRepositoryable repository, UserManager<AppUserModel> userManager, IActionContextAccessor actionAccessor)
        {
            _repository = repository;
            _userManager = userManager;
            _actionAccessor = actionAccessor;
        }

        public IViewComponentResult Invoke()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = _actionAccessor.ActionContext.HttpContext.User;
            var user = _repository.Users.FirstOrDefault(u => u.Id == _userManager.GetUserId(currentUser));

            return View(user);
        }
    }
}
