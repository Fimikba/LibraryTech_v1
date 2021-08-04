using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Domains
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public List<BookAuthor> Authors { get; set; } = new List<BookAuthor>();
        public List<BookCategory> Categories { get; set; } = new List<BookCategory>();
        public List<BookSeries> Series { get; set; } = new List<BookSeries>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<AppUserModel> User { get; set; } = new List<AppUserModel>();
        public List<AppUserModel> UserHowRecentlyReadBySubs { get; set; } = new List<AppUserModel>();
        public List<BookUserBySubs> BookUserBySubs { get; set; } = new List<BookUserBySubs>();
        public string ImageUrl { get; set; }
        public string BookUrl { get; set; }
        public string DemoUrl { get; set; }
        public string Genre { get; set; }
        public string Description  { get; set; }
        public string AgeLimit { get; set; }
        public DateTime ReleasedPerLibraryTech { get; set; }
        public DateTime DateOfWriting { get; set; }
        public int BookVolume { get; set; }
        public string ISBN10 { get; set; }
        public string ISBN13 { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailableBySubs { get; set; }
        public long NumberOfRequestst { get; set; }
    }
}
