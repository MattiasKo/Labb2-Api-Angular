using Labb2_Api_Angular.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Labb2_Api_Angular.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(new Employee{

                 EmployeeId= Guid.NewGuid(),
                 FirstName = "Mattias",
                 LastName = "Jonsson",
                 Email = "Häftigmail.com",
                 PhoneNumber = "0705454560",
                 Gender = "Male",
                 Adress = "Långatan",
                 Salary = 11500m,
                 DepartmentId = new Guid("c98c58f5-4744-4049-8629-079a9935f6c1"),

            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {

                EmployeeId = Guid.NewGuid(),
                FirstName = "Daniel",
                LastName = "osrkarsson",
                Email = "hotmail.com",
                PhoneNumber = "5458522",
                Gender = "Male",
                Adress = "Halland",
                Salary = 13500m,
                DepartmentId = new Guid("c98c58f5-4744-4049-8629-079a9935f6c1"),

            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {

                EmployeeId = Guid.NewGuid(),
                FirstName = "Edwin",
                LastName = "Nocco",
                Email = "gmail.com",
                PhoneNumber = "05485036",
                Gender = "Male",
                Adress = "Göteborg",
                Salary = 35400m,
                DepartmentId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),

            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {

                EmployeeId = Guid.NewGuid(),
                FirstName = "Anna",
                LastName = "Myberg",
                Email = "atelje.com",
                PhoneNumber = "04578521",
                Gender = "Female",
                Adress = "Umeå",
                Salary = 36500m,

                DepartmentId = new Guid("2d4f9bbc-358b-49da-8bc4-43923e9147d6"),
            });
            modelBuilder.Entity<Department>().HasData(new Department
            {
                DepartmentId=new Guid("c98c58f5-4744-4049-8629-079a9935f6c1"),
                DepartmentName="Teknik"
            });
            modelBuilder.Entity<Department>().HasData(new Department
            {
                DepartmentId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                DepartmentName = "Human resources"
            });
            modelBuilder.Entity<Department>().HasData(new Department
            {
                DepartmentId = new Guid("2d4f9bbc-358b-49da-8bc4-43923e9147d6"),
                DepartmentName = "SystemUtveckling"
            });
        }
    }
}
