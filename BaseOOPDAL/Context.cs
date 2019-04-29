using BaseOOPDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseOOPDAL
{
    public class Context : DbContext
    {
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Designer> Designers { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\v11.0;Database=BaseOOPDB;Trusted_Connection=True;");
        }
    }
}
