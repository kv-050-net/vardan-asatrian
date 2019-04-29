using BaseOOPDAL.Entities;
using System.Collections.Generic;

namespace BaseOOPBLL.Entities
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        public List<Manager> Managers { get; set; }
    }
}
