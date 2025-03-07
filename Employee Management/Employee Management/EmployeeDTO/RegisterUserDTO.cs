namespace Employee_Management.EmployeeDTO
{
    public class RegisterUserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Plain text password (hashed before saving)
        public string Role { get; set; } = "Employee";
    }
}
