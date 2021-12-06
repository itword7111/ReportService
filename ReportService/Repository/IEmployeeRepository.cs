using System.Collections.Generic;
using ReportService.Model;

namespace ReportService.Repository
{
    public interface IEmployee
    {
        IEnumerable<Employee> AllEmployees { get; }
        IEnumerable<Employee> EmployeesOfDepartment(Department department);

    }
    
}