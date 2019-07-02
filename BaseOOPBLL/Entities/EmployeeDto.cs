
namespace BaseOOPBLL.Entities
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Experience { get; set; }
        public decimal Salary { get; set; }
        public int? ManagerId { get; set; }
        public ManagerDto Manager { get; set; }
    }
}
