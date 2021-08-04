using LibraryTechWebApp.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Components
{
    public class DropdownToggleCategoryViewComponent : ViewComponent
    {
        private readonly ILtSqlRepositoryable _repository;

        public DropdownToggleCategoryViewComponent(ILtSqlRepositoryable repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            var category = _repository.CategoriesForMenu.Select(c => c.Name);

            return View(category);
        }
    }
}
