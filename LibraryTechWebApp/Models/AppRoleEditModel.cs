using System.Collections.Generic;
using LibraryTechWebApp.Domains;
using Microsoft.AspNetCore.Identity;

namespace LibraryTechWebApp.Models
{
    public class AppRoleEditModel
    {
        public IdentityRole Role { get; set; }
        public List<AppUserModel> Members { get; set; }
        public List<AppUserModel> NonMembers { get; set; }
    }
}