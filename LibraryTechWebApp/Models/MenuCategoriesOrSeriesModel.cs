using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Models
{
    public class MenuCategoriesOrSeriesModel
    {
        public IEnumerable<string> MenuElements { get; set; }
        public string ActiveCategory { get; set; }
        public string ActiveSeries { get; set; }
    }
}
