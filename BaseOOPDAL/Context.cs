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
            optionsBuilder.UseSqlServer(@"Server=(localDb)\mssqllocaldb;Database=BaseOOPDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Developer>()
                .HasOne(_ => _.Manager)
                .WithMany(_ => _.DevelopersTeam)
                .HasForeignKey(_ => _.ManagerId);
            builder.Entity<Designer>()
                .HasOne(_ => _.Manager)
                .WithMany(_ => _.DesignersTeam)
                .HasForeignKey(_ => _.ManagerId);
            builder.Entity<Manager>()
                .HasOne(_ => _.Manager)
                .WithMany(_ => _.ManagersTeam)
                .HasForeignKey(_ => _.ManagerId);
            builder.Entity<Manager>()
                .HasOne(_ => _.Department)
                .WithMany(_ => _.Managers)
                .HasForeignKey(_ => _.DepartmentId);
        }
    }
}
