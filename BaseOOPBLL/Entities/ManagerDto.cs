using System.Collections.Generic;

namespace BaseOOPBLL.Entities
{
    public class ManagerDto : EmployeeDto
    {
        public List<DeveloperDto> DevelopersTeam { get; set; }

        public List<DesignerDto> DesignersTeam { get; set; }
    }
}
