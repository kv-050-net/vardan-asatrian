using System.ComponentModel.DataAnnotations.Schema;

namespace BaseOOPDAL.Entities
{
    //[Table("NewName")]
    [NotMapped]
    public class Employee
    {
        //[Column(TypeName = "varchar(200)")]
        //[MaxLength(50)]
        //[Required]
        //[Key]
        //[Column("NewName")]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public int Experience { get; set; }

        public decimal Salary { get; set; }

        public int? ManagerId { get; set; }
        public Manager Manager { get; set; }
    }
}
