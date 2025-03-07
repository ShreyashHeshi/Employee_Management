using Employee_Management.EmployeeDTO;
using Employee_Management.Entities;
using Employee_Management.Repositary;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
//using Org.BouncyCastle.Crypto.Generators;

namespace Employee_Management.Services
{
    public class UserService : IUserService
    {
        private readonly EmployeeCollectionContext _context;
        private readonly IConfiguration _configuration;

        public UserService(EmployeeCollectionContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public void RegisterUser(RegisterUserDTO userDTO)
        {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);

                var user = new User
                {
                    UserName = userDTO.UserName,
                    Email = userDTO.Email,
                    PasswordHash = hashedPassword,
                    Role = userDTO.Role
                };

                _context.Users.Add(user);
                _context.SaveChanges();
            
        }

        public string LoginUser(LoginUserDTO userDTO)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userDTO.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(userDTO.Password, user.PasswordHash))
                return null;

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        
         }
}
}
