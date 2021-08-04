using LibraryTechWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Models
{
    public class ShowBookModel
    {
        public Book Book { get; set; }
        public bool IsInCart { get; set; }
    }
}
