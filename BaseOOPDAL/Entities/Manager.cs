using System.Collections.Generic;

namespace BaseOOPDAL.Entities
{
    public class Manager : Employee
    {
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Employee> Team { get; set; }
    }
}
