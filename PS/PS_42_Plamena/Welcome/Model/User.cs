using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Password { get; set; } = null!;

        public UserRolesEnum Role { get; set; }

        public string FacultyNumber { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
