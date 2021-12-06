using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReportService.Model;

namespace ReportService.Repository.Impl
{
    public class DepartmentRepository : IDepartment
    {
        private readonly AppDbContext _appDbContext;

        public DepartmentRepository(AppDbContext appDbContext, IEnumerable<Department> allActiveDepartments)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Department> AllDepartments => _appDbContext.Department;

        public IEnumerable<Department> AllActiveDepartments(){
            return _appDbContext.Department.Where(a=>a.Active.Equals(true));
        }
    }
}