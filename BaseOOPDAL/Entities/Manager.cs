using System.Collections.Generic;

namespace BaseOOPDAL.Entities
{
    public class Manager : Employee
    {
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Developer> DevelopersTeam { get; set; }

        public List<Designer> DesignersTeam { get; set; }

        public List<Manager> ManagersTeam { get; set; }
    }
}
