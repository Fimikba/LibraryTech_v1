using System.ComponentModel.DataAnnotations;

namespace LibraryTechWebApp.Models
{
    public class AppRoleCreateModel
    {
        [Required]
        [Display(Name = "Role name")]
        public string Name { get; set; }
    }
}