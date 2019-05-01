using BaseOOPDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BaseOOPDAL
{
    public class Context : DbContext
    {
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Designer> Designers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localDb)\mssqllocaldb;Database=BaseOOPDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>()
                .HasOne(_ => _.Manager)
                .WithMany(_ => _.Team)
                .HasForeignKey(_ => _.ManagerId);
            builder.Entity<Manager>()
                .HasOne(_ => _.Department)
                .WithMany(_ => _.Managers)
                .HasForeignKey(_ => _.DepartmentId);
        }
    }
}
