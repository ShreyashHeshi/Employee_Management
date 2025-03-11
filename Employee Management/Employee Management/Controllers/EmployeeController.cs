using Employee_Management.Entities;
using Employee_Management.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Employee_Management.Controllers
{
    //[Authorize] // Secure all endpoints with JWT
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController: ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            return _employeeService.GetEmployee();

        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var emp = _employeeService.GetById(id);
            if(emp == null)
            {
                return NotFound();
            }
            return emp;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<Employee> Add(Employee employee)
        {
            _employeeService.InsertEmployee(employee);
            _employeeService.save();
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public ActionResult Update(EmployeeDTO.EmployeeDTO employeeDTO,int id)
        {
            Employee employee = new Employee();
            employee.Employee_Name = employeeDTO.Employee_Name;
            employee.Employee_Email=employeeDTO.Employee_Email;
            employee.Employee_Department = employeeDTO.Employee_Department;
            employee.Employee_Position = employeeDTO.Employee_Position;
            employee.Employee_Salary= employeeDTO.Employee_Salary;
            _employeeService.UpdateEmployee(employee, id);
            _employeeService.save();

            return Ok();

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        { 

          var empId = _employeeService.GetById(id);
            if(empId == null)
            {
                return NotFound();
            }
            _employeeService.DeleteEmployee(empId);
            _employeeService.save();

            return Ok();

        }

        [HttpGet("pagination")]
        public ActionResult<IEnumerable<Employee>> GetEmployeesWithPagination(
        int pageNumber = 1,
        int pageSize = 5)
        {
            var employees = _employeeService.GetEmployeesWithPagination(pageNumber, pageSize);
            return Ok(employees);
        }

        [HttpGet("sorting")]
        public ActionResult<IEnumerable<Employee>> GetEmployeesWithSorting(
        string sortBy = "Employee_Name",
        string sortOrder = "asc")
        {
            var employees = _employeeService.GetEmployeesWithSorting(sortBy, sortOrder);
            return Ok(employees);
        }



    }
}
