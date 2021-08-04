using LibraryTechWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Models
{
    public class StatisticModel
    {
        public IQueryable<Book> Books { get; set; }
        public PaginatorInfo Info { get; set; }
    }
}
