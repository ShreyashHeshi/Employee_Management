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




        void save();


    }
}
