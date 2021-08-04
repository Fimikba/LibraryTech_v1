using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using LibraryTechWebApp.Models;
using LibraryTechWebApp.Domains;

namespace LibraryTechWebApp.Helpers
{
    [HtmlTargetElement("td", Attributes = "role-users")]
    public class RoleUserTagHelper : TagHelper
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<AppUserModel> _userManager;

        public RoleUserTagHelper(RoleManager<IdentityRole> roleManager, UserManager<AppUserModel> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HtmlAttributeName("role-users")]
        public string Role { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var names = new List<string>();
            IdentityRole role = await _roleManager.FindByIdAsync(Role);
            if (role != null)
            {
                foreach (var user in _userManager.Users.ToList())
                {
                    bool isInRole = await _userManager.IsInRoleAsync(user, role.Name);
                    if (isInRole)
                    {
                        names.Add(user.UserName);
                    }
                }
            }

            output.Content.SetContent(names.Count == 0 ? "There is no users" : string.Join(", ", names));
        }
    }
}