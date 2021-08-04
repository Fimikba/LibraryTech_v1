using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Domains
{
    public abstract class BookClassification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long NumberOfRequestst { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
