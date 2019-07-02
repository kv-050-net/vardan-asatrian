using BaseOOPBLL.Entities;
using System;
using System.Collections.Generic;

namespace BaseOOPCompany
{
    public class Program
    {
        static void Main(string[] args)
        {
            Startup startup = new Startup();

            var manager1 = new ManagerDto { FirstName = "Man1", SecondName = "Manager1", Salary = 4000, Experience = 6 };
            var manager2 = new ManagerDto { FirstName = "Man2", SecondName = "Manager2", Salary = 1500, Experience = 1 };
            var manager3 = new ManagerDto { FirstName = "Man3", SecondName = "Manager3", Salary = 2500, Experience = 3 };

            var developer1 = new DeveloperDto { FirstName = "Dev1", SecondName = "Developer1", Salary = 500, Experience = 1, Manager = manager1 };
            var developer2 = new DeveloperDto { FirstName = "Dev2", SecondName = "Developer2", Salary = 700, Experience = 1, Manager = manager1 };
            var developer3 = new DeveloperDto { FirstName = "Dev3", SecondName = "Developer3", Salary = 1000, Experience = 2, Manager = manager1 };
            var developer4 = new DeveloperDto { FirstName = "Dev4", SecondName = "Developer4", Salary = 1700, Experience = 3, Manager = manager1 };
            var developer5 = new DeveloperDto { FirstName = "Dev5", SecondName = "Developer5", Salary = 3000, Experience = 7, Manager = manager1 };
            var developer6 = new DeveloperDto { FirstName = "Dev6", SecondName = "Developer6", Salary = 500, Experience = 1, Manager = manager1 };
            var developer7 = new DeveloperDto { FirstName = "Dev7", SecondName = "Developer7", Salary = 700, Experience = 1, Manager = manager1 };
            var developer8 = new DeveloperDto { FirstName = "Dev8", SecondName = "Developer8", Salary = 1000, Experience = 2, Manager = manager2 };
            var developer9 = new DeveloperDto { FirstName = "Dev9", SecondName = "Developer9", Salary = 1700, Experience = 3, Manager = manager2 };
            var developer10 = new DeveloperDto { FirstName = "Dev10", SecondName = "Developer10", Salary = 3000, Experience = 7, Manager = manager2 };
            var developer11 = new DeveloperDto { FirstName = "Dev11", SecondName = "Developer11", Salary = 500, Experience = 1, Manager = manager3 };
            var developer12 = new DeveloperDto { FirstName = "Dev12", SecondName = "Developer12", Salary = 700, Experience = 1, Manager = manager3 };
            var developer13 = new DeveloperDto { FirstName = "Dev13", SecondName = "Developer13", Salary = 1000, Experience = 2, Manager = manager3 };
            var developer14 = new DeveloperDto { FirstName = "Dev14", SecondName = "Developer14", Salary = 1700, Experience = 3, Manager = manager3 };
            var developer15 = new DeveloperDto { FirstName = "Dev15", SecondName = "Developer15", Salary = 3000, Experience = 7, Manager = manager3 };

            var designer1 = new DesignerDto { FirstName = "Des1", SecondName = "Designer1", Salary = 600, Experience = 1, EffectivenessCoefficient = 0.5m, Manager = manager1 };
            var designer2 = new DesignerDto { FirstName = "Des2", SecondName = "Designer2", Salary = 900, Experience = 2, EffectivenessCoefficient = 0.8m, Manager = manager1 };
            var designer3 = new DesignerDto { FirstName = "Des3", SecondName = "Designer3", Salary = 1200, Experience = 2, EffectivenessCoefficient = 0.7m, Manager = manager1 };
            var designer4 = new DesignerDto { FirstName = "Des4", SecondName = "Designer4", Salary = 1700, Experience = 3, EffectivenessCoefficient = 0.6m, Manager = manager1 };
            var designer5 = new DesignerDto { FirstName = "Des5", SecondName = "Designer5", Salary = 2000, Experience = 3, EffectivenessCoefficient = 0.9m, Manager = manager2 };
            var designer6 = new DesignerDto { FirstName = "Des6", SecondName = "Designer6", Salary = 600, Experience = 1, EffectivenessCoefficient = 0.4m, Manager = manager2 };
            var designer7 = new DesignerDto { FirstName = "Des7", SecondName = "Designer7", Salary = 1300, Experience = 2, EffectivenessCoefficient = 0.65m, Manager = manager3 };
            var designer8 = new DesignerDto { FirstName = "Des8", SecondName = "Designer8", Salary = 700, Experience = 1, EffectivenessCoefficient = 0.8m, Manager = manager3 };
            var designer9 = new DesignerDto { FirstName = "Des9", SecondName = "Designer9", Salary = 1200, Experience = 2, EffectivenessCoefficient = 0.95m, Manager = manager3 };

            manager1.Team = new List<EmployeeDto>()
                {
                    developer1, developer2, developer3, developer4, developer5, developer6, developer7,
                    designer1, designer2, designer3, designer4
                };

            manager2.Team = new List<EmployeeDto>()
                {
                    developer8, developer9, developer10,
                    designer5, designer6
                };

            manager3.Team = new List<EmployeeDto>()
                {
                    developer11, developer12, developer13, developer14, developer15,
                    designer7, designer8, designer9
                };

            var department1 = new DepartmentDto { Managers = new List<ManagerDto> { manager1, manager2, manager3 } };

            //startup.developerService.CreateOrUpdateAsync(developer1);
            //startup.developerService.CreateOrUpdateAsync(developer2);
            //startup.developerService.CreateOrUpdateAsync(developer3);
            //startup.developerService.CreateOrUpdateAsync(developer4);
            //startup.developerService.CreateOrUpdateAsync(developer5);
            //startup.developerService.CreateOrUpdateAsync(developer6);
            //startup.developerService.CreateOrUpdateAsync(developer7);
            //startup.developerService.CreateOrUpdateAsync(developer8);
            //startup.developerService.CreateOrUpdateAsync(developer9);
            //startup.developerService.CreateOrUpdateAsync(developer10);
            //startup.developerService.CreateOrUpdateAsync(developer11);
            //startup.developerService.CreateOrUpdateAsync(developer12);
            //startup.developerService.CreateOrUpdateAsync(developer13);
            //startup.developerService.CreateOrUpdateAsync(developer14);
            //startup.developerService.CreateOrUpdateAsync(developer15);
            //startup.designerService.CreateOrUpdateAsync(designer1);
            //startup.designerService.CreateOrUpdateAsync(designer2);
            //startup.designerService.CreateOrUpdateAsync(designer3);
            //startup.designerService.CreateOrUpdateAsync(designer4);
            //startup.designerService.CreateOrUpdateAsync(designer5);
            //startup.designerService.CreateOrUpdateAsync(designer6);
            //startup.designerService.CreateOrUpdateAsync(designer7);
            //startup.designerService.CreateOrUpdateAsync(designer8);
            //startup.designerService.CreateOrUpdateAsync(designer9);
            //startup.managerService.CreateOrUpdateAsync(manager1);
            //startup.managerService.CreateOrUpdateAsync(manager2);
            //startup.managerService.CreateOrUpdateAsync(manager3);
            //startup.departmentService.CreateOrUpdateAsync(department1);

            //startup.departmentService.PaySalary(department1);
            startup.departmentService.PaySalaryParallel(department1);

            Console.ReadKey();
        }
    }
}
