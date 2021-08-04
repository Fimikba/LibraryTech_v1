using System.ComponentModel.DataAnnotations;

namespace LibraryTechWebApp.Models
{
    public class AppUserLoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password )]
        public string Password { get; set; }
    }
}