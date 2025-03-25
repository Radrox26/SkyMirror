namespace SkyMirror.Entities
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public string RoleName { get; set; }

        // Navigation Property
        public ICollection<User> Users { get; set; }
    }
}
