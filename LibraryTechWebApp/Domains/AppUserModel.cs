using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Domains
{
    public class AppUserModel : IdentityUser
    {
        public string Nickname { get; set; }
        public string PostAddress { get; set; }
        public decimal Balance { get; set; }
        public bool IsSubscription { get; set; }
        public int SubsTariff { get; set; }
        public string PhotoUrl { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Book> ReadRecentlyBySubs { get; set; } = new List<Book>();
        public List<BookUserBySubs> BookUserBySubs { get; set; } = new List<BookUserBySubs>();
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
