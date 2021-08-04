using LibraryTechWebApp.DataAccessLayer;
using LibraryTechWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Components
{
    public class MenuBookCategoriesViewComponent : ViewComponent
    {
        private readonly ILtSqlRepositoryable _repository;

        public MenuBookCategoriesViewComponent(ILtSqlRepositoryable repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke(MenuCategoriesOrSeriesModel model)
        {
            var categories = _repository.CategoriesForMenu.Select(c => c.Name);
            model.MenuElements = categories;

            return View(model);
        }
    }
}
