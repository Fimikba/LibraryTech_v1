using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Domains
{
    public class BookSeries : BookClassification
    {
        public List<BookCategory> Categories { get; set; } = new List<BookCategory>();
    }
}
