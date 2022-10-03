using Labb2_Api_Angular.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Labb2_Api_Angular.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


    }
}
