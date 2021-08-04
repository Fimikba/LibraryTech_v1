using System.ComponentModel.DataAnnotations;

namespace LibraryTechWebApp.Models
{
    public class AppUserModelCreate
    {
        [Required]
        [Display(Name = "User name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm the password")]
        public string ConfirmPassword { get; set; }
    }
}