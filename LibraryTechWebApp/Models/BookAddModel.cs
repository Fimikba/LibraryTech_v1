using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.Models
{
    public class BookAddModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public string Authors { get; set; }
        [Required]
        public string Categories { get; set; }
        public string Series { get; set; }
        [Display(Name = "Cover")]
        public IFormFile Cover { get; set; }
        [Required]
        [Display(Name = "Full book")]
        public IFormFile FullBookFile { get; set; }
        [Required]
        [Display(Name = "Demo book")]
        public IFormFile DemoBookFile { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "Age limit")]
        public string AgeLimit { get; set; }
        [Required]
        [Display(Name = "Date of writing")]
        public DateTime DateOfWriting { get; set; }
        [Required]
        [Display(Name = "Book volume")]
        public int BookVolume { get; set; }
        [Required]
        public string ISBN10 { get; set; }
        public string ISBN13 { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        [Display(Name = "Price, $")]
        public decimal Price { get; set; }
        [Display(Name = "Is this book available by subscription?")]
        public bool IsAvailableBySubs { get; set; }
    }
}
