namespace LibraryTechWebApp.Models
{
    public class AppRoleModifyModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string[] IdsToDelite { get; set; } = new string[0];
        public string[] IdsToAdd { get; set; } = new string[0];
    }
}