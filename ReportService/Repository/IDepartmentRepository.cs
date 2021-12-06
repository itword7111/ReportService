using System.Collections.Generic;
using ReportService.Model;

namespace ReportService.Repository
{
    public interface IDepartment
    {
        IEnumerable<Department> AllDepartments { get; }
        IEnumerable<Department> AllActiveDepartments();

    }
}