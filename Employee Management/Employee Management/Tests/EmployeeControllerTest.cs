using Employee_Management.Controllers;
using Employee_Management.Entities;
using Employee_Management.Services;
using Moq;
using Xunit;

namespace Employee_Management.Tests
{
    public class EmployeeControllerTest
    {
        private readonly Mock<IEmployeeService> _employeeServiceMock;
        private readonly EmployeeController _employeeController;

        public EmployeeControllerTest()
        {
            _employeeServiceMock=new Mock<IEmployeeService>();
            _employeeController=new EmployeeController( _employeeServiceMock.Object );
        }

        [Fact]
        public void TestGetAllEmployee()
        {
            var employee = new List<Employee>();
        }
    }
}
