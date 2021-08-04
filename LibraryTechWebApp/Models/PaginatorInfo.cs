using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Models
{
    public class PaginatorInfo
    {
        public int CurentPage { get; set; }
        public int TotalItem { get; set; }
        public int PageSize { get; set; }
        public int PagesCount =>
            (int)Math.Ceiling(TotalItem / (float)PageSize);
    }
}
