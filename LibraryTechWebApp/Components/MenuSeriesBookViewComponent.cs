using LibraryTechWebApp.DataAccessLayer;
using LibraryTechWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Components
{
    public class MenuSeriesBookViewComponent : ViewComponent
    {
        private readonly ILtSqlRepositoryable _repository;

        public MenuSeriesBookViewComponent(ILtSqlRepositoryable repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke(MenuCategoriesOrSeriesModel model)
        {
            var series = _repository.SeriesForMenu
                .Where(s=>s.Categories.FirstOrDefault(c=>c.Name==model.ActiveCategory)!=null)
                .Select(c => c.Name);
            model.MenuElements = series;

            return View(model);
        }
    }
}
