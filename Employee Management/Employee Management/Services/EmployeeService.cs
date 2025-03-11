using Employee_Management.EmployeeDTO;
using Employee_Management.Entities;
using Employee_Management.Repositary;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Security;

namespace Employee_Management.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly EmployeeCollectionContext _context;

        public EmployeeService(EmployeeCollectionContext context)
        {
            _context = context;
        }

       

        public Employee GetById(int id)
        {
            var emp = _context.Employees.Find(id);
            return emp;
        }

        public List<Employee> GetEmployee()
        {
           return _context.Employees.ToList();
            
        }

        public void InsertEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public void save()
        {
            _context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee, int id)
        {
            Employee emp = _context.Employees.Find(id);
            emp.Employee_Name= employee.Employee_Name;
            emp.Employee_Email= employee.Employee_Email;
            emp.Employee_Department= employee.Employee_Department;
            emp.Employee_Position= employee.Employee_Position;
            emp.Employee_Salary= employee.Employee_Salary;
        }

        public Employee DeleteEmployee(Employee employee)
        {
            Employee employee2 = _context.Employees.Find(employee.Employee_Id);
           
            _context.Employees.Remove(employee2);
            return employee2;
        }

        public List<Employee> GetEmployeesWithPagination(int pageNumber, int pageSize)
        {
            return _context.Employees
                   .Skip((pageNumber - 1) * pageSize) // Skip previous pages
                   .Take(pageSize) // Take only required records
                   .ToList();
        }

        public List<Employee> GetEmployeesWithSorting(string sortBy, string sortOrder)
        {
            var query = _context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortOrder.ToLower() == "desc")
                {
                    query = query.OrderByDescending(e => EF.Property<object>(e, sortBy));
                }
                else
                {
                    query = query.OrderBy(e => EF.Property<object>(e, sortBy));
                }
            }

            return query.ToList();
        }
    }
}
