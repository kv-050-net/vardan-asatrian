using AutoMapper;
using BaseOOPBLL.Entities;
using BaseOOPDAL.Entities;

namespace BaseOOPBLL.Services
{
    public class DtoMapProfile : Profile
    {
        public DtoMapProfile()
        {
            CreateMap<DesignerDto, Designer>();
            CreateMap<Designer, DesignerDto>();
            CreateMap<DeveloperDto, Developer>();
            CreateMap<Developer, DeveloperDto>();
            CreateMap<ManagerDto, Manager>();
            CreateMap<Manager, ManagerDto>();
            CreateMap<DepartmentDto, Department>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
