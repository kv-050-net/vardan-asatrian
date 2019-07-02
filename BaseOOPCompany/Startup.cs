using AutoMapper;
using BaseOOPBLL.Services;
using BaseOOPBLL.Services.DepartmentService;
using BaseOOPBLL.Services.DestignerService;
using BaseOOPBLL.Services.DeveloperService;
using BaseOOPBLL.Services.EmployeeService;
using BaseOOPBLL.Services.ManagerService;
using BaseOOPDAL;
using BaseOOPDAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
namespace BaseOOPCompany
{
    public class Startup
    {
        private IServiceCollection services = new ServiceCollection();

        private ServiceProvider provider;

        public IDeveloperService developerService;
        public IDesignerService designerService;
        public IManagerService managerService;
        public IDepartmentService departmentService;
        public IEmployeeService employeeService;

        public Startup()
        {
            services.AddDbContext<Context>();

            services.AddAutoMapper();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDesignerService, DesignerService>();
            services.AddScoped<IDeveloperService, DeveloperService>();
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            provider = services.BuildServiceProvider();

            developerService = provider.GetService<IDeveloperService>();
            designerService = provider.GetService<IDesignerService>();
            managerService = provider.GetService<IManagerService>();
            departmentService = provider.GetService<IDepartmentService>();
            employeeService = provider.GetService<IEmployeeService>();


            Mapper.Initialize(x =>
            {
                x.AddProfile<DtoMapProfile>();
            });
            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}
