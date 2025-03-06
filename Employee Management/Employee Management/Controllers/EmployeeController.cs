using Employee_Management.Entities;
using Employee_Management.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.Controllers
{
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

        [HttpPost]
        public ActionResult<Employee> Add(Employee employee)
        {
            _employeeService.InsertEmployee(employee);
            _employeeService.save();
            return Ok();
        }

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

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        { 

          var empId = _employeeService.GetById(id);
            _employeeService.DeleteEmployee(empId);
            _employeeService.save();

            return Ok();



        }
        


    }
}
