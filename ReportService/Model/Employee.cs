using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ReportService.Domain;

namespace ReportService.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string  Inn { get; set; }
        public int Salary { get; set; }
        public string BuhCode { get; set; }
    }
}
