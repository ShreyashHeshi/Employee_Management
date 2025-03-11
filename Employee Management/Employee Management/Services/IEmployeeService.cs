using Employee_Management.EmployeeDTO;
using Employee_Management.Entities;

namespace Employee_Management.Services
{
    public interface IEmployeeService
    {

        List<Employee> GetEmployee();

        Employee GetById(int id);

        void InsertEmployee(Employee employee);

        void UpdateEmployee(Employee employee, int id);

        Employee DeleteEmployee(Employee employee);

        List<Employee> GetEmployeesWithPagination(int pageNumber, int pageSize);


        List<Employee> GetEmployeesWithSorting(string sortBy, string sortOrder);




        void save();


    }
}
