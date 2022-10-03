using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2_Api_Angular.Models
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Adress { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }
    }
}
