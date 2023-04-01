namespace PollMd.Models.ViewModels
{
    public class UserWithRoles
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}
