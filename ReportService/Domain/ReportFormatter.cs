using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportService.Model;

namespace ReportService.Domain
{
    public class ReportFormatter
    {
        public ReportFormatter(Employee e)
        {
            Employee = e;
        }

        public Action<Employee, Report> NL = (e, s) => s.S = s.S + Environment.NewLine;
        public Action<Employee, Report> WL = (e, s) => s.S = s.S + "--------------------------------------------";
        public Action<Employee, Report> WT = (e, s) => s.S = s.S + "         ";
        public Action<Employee, Report> WE = (e, s) => s.S = s.S + e.Name;
        public Action<Employee, Report> WS = (e, s) => s.S = s.S + e.Salary + "р";
        public Action<Employee, Report> WD = (e, s) => s.S = s.S + e.Department.Name;
        public Action<Employee, Report> SumSalary = (e, s) => s.S = s.S +"Всего по отделу "+ e.Salary;
        public Action<Employee, Report> SumAllSalary = (e, s) => s.S = s.S +"Всего по предприятию "+ e.Salary;
        public Employee Employee { get; }
    }
}
