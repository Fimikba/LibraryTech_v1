using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Domains
{
    public class BookUserBySubs
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public string UserId { get; set; }
        public AppUserModel User { get; set; }

        public DateTime DateLastRead { get; set; }
    }
}
