using System;
using System.Collections.Generic;
using System.Linq;
using ReportService.Domain;
using ReportService.Model;
using ReportService.Repository;

namespace ReportService.Services.Impl
{
    public class AccountingReportForMonthService:IAccountingReportForMonthService
    {
        private readonly IEmployee _employeeRepo;
        private readonly IDepartment _department;

        public AccountingReportForMonthService(IEmployee employeeRepo, IDepartment department)
        {
            _employeeRepo = employeeRepo;
            _department = department;
        }

        public string GetReportForMonth(int year, int month)
        {
            IEnumerable<Department> listOfDepartments = _department.AllActiveDepartments();
            IEnumerable<Employee> listOfEmployees;
            var actions = new List<(Action<Employee, Report>, Employee)>();
            var report = new Report() { S = MonthNameResolver.MonthName.GetName(year, month) };
            int allSalary = 0;

            foreach (var department in listOfDepartments)
            {
                actions.Add((new ReportFormatter(null).NL, new Employee()));
                actions.Add((new ReportFormatter(null).WL, new Employee()));
                actions.Add((new ReportFormatter(null).NL, new Employee()));
                actions.Add((new ReportFormatter(null).WD, new Employee() { Department = department } ));
                listOfEmployees = _employeeRepo.EmployeesOfDepartment(department);
                int salary = listOfEmployees.Sum(a => a.Salary);
                allSalary += salary;
                foreach (var employee in listOfEmployees)
                {
                    //employee.BuhCode = EmpCodeResolver.GetCode(employee.Inn).Result;
                    //employee.Salary = employee.Salary();
                    actions.Add((new ReportFormatter(employee).NL, employee));
                    actions.Add((new ReportFormatter(employee).WE, employee));
                    actions.Add((new ReportFormatter(employee).WT, employee));
                    actions.Add((new ReportFormatter(employee).WS, employee));        
                }
                actions.Add((new ReportFormatter(null).NL, new Employee()));
                actions.Add((new ReportFormatter(null).SumSalary, new Employee() { Salary = salary } ));
                actions.Add((new ReportFormatter(null).NL, new Employee()));
            }
            actions.Add((new ReportFormatter(null).NL, null));
            actions.Add((new ReportFormatter(null).SumAllSalary, new Employee() { Salary = allSalary } ));
            actions.Add((new ReportFormatter(null).NL, null));
            actions.Add((new ReportFormatter(null).WL, null));
            foreach (var act in actions)
            {
                act.Item1(act.Item2, report);
            }
            report.Save();
            return report.S;

        }
    }
}