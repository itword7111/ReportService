using Microsoft.EntityFrameworkCore;
using ReportService.Model;

namespace ReportService
{
    public class AppDbContext:DbContext
    {
    
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TestDataBase");
        }
    }
}