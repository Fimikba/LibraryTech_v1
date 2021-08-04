using LibraryTechWebApp.BusinessLogic;
using LibraryTechWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Models
{
    public class ShowCartModel
    {
        public Cart Cart { get; set; }
        public decimal TotalCoastWithDiscount { get; set; }
    }
}
