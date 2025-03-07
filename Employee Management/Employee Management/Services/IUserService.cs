using Employee_Management.EmployeeDTO;

namespace Employee_Management.Services
{
    public interface IUserService
    {
        void RegisterUser(RegisterUserDTO userDTO);

        string LoginUser(LoginUserDTO userDTO);

    }
}
