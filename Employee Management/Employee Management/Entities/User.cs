namespace Employee_Management.Entities
{
    public class User
    {

        public int UserId { get; set; }
        public string UserName { get; set; } // Can be email or unique username
        public string Email { get; set; }
        public string PasswordHash { get; set; } // Hashed password using BCrypt
        public string Role { get; set; } // e.g., "Admin", "Employee"
    }
}
