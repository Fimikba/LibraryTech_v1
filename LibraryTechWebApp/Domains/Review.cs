using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Domains
{
    public class Review
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public AppUserModel User { get; set; }
        public int Rating { get; set; }
        public string ShortReview { get; set; }
        public string Advantages { get; set; }
        public string Disadvantages { get; set; }
        public string FullReview { get; set; }
    }
}
