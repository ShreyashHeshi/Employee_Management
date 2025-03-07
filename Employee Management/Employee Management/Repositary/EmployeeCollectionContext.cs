using Employee_Management.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management.Repositary
{
    public class EmployeeCollectionContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string conString = @"server=localhost;port=3306;user=root;password=Shrey$heshi1745;database=employee";
            optionsBuilder.UseMySQL(conString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Employee_Id);
                entity.Property(e => e.Employee_Name);
                entity.Property(e => e.Employee_Email);
                entity.Property(e => e.Employee_Department);
                entity.Property(e => e.Employee_Position);
                entity.Property(e => e.Employee_Salary);
                entity.Property(e => e.Employee_Join_Date);
            });
            modelBuilder.Entity<Employee>().ToTable("employee");

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.UserName).IsRequired();
                entity.Property(u => u.Email).IsRequired();
                entity.Property(u => u.PasswordHash).IsRequired();
                entity.Property(u => u.Role).IsRequired();
            });

            modelBuilder.Entity<User>().ToTable("users");
        }








    }
}
