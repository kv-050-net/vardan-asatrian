using System.Collections.Generic;

namespace BaseOOPDAL.Entities
{
    public class Department
    {
        public int Id { get; set; }

        public List<Manager> Managers { get; set; }
    }
}
