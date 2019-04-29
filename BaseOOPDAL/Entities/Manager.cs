using System.Collections.Generic;

namespace BaseOOPDAL.Entities
{
    public class Manager : Employee
    {
        public List<Developer> DevelopersTeam { get; set; }
        public List<Designer> DesignersTeam { get; set; }
    }
}
