using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReportService.Model;

namespace ReportService.Repository.Impl
{
    public class EmployeeRepository : IEmployee
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Employee> AllEmployees => _appDbContext.Employee;
        IEnumerable<Employee> IEmployee.EmployeesOfDepartment(Department department)
        {
            return _appDbContext.Employee.Where(a=>a.Department.Equals(department));
        }
        
    }
}