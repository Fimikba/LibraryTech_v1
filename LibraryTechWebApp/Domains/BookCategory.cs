using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Domains
{
    public class BookCategory : BookClassification
    {
        public List<BookSeries> Series { get; set; } = new List<BookSeries>();
    }
}
