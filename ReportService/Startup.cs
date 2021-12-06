using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReportService.Repository;
using ReportService.Repository.Impl;
using ReportService.Services;
using ReportService.Services.Impl;

namespace ReportService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<AppDbContext>();
            services.AddTransient<IEmployee, EmployeeRepository>();
            services.AddTransient<IDepartment, DepartmentRepository>();
            services.AddTransient<IAccountingReportForMonthService, AccountingReportForMonthService>();
            services.AddMvc();
            //services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();
        }
    }
}
