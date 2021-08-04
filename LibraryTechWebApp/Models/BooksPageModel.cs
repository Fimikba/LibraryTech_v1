using LibraryTechWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Models
{
    public class BooksPageModel
    {
        public List<BookModel> Books { get; set; }
        public PaginatorInfo Info { get; set; }
        public string Category { get; set; }
        public string Series { get; set; }
        public string Author { get; set; }
    }
}
