using BaseOOPDAL.Interfaces;
using System.Collections.Generic;

namespace BaseOOPDAL.Entities
{
    public class Department : IEntity
    {
        public int Id { get; set; }
        public List<Manager> Managers { get; set; }
    }
}
