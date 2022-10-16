using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb2_Api_Angular.Models
{
    public class EmployeeRepository : IEmployee
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteById(Guid id)
        {
            var empDel = await _context.Employees.FirstOrDefaultAsync(c => c.EmployeeId == id);
            if (empDel != null)
            {
                _context.Employees.Remove(empDel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.Include(e=>e.department).ToListAsync();
        }

        public async Task<Employee> GetById(Guid id)
        {
            var emp = await _context.Employees.Include(e=>e.department).FirstOrDefaultAsync(c => c.EmployeeId == id);
            return emp;

        }

        public async Task Insert(Employee employee)
        {
            employee.EmployeeId = Guid.NewGuid();
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

        }
            public async Task UpdateById(Guid id,Employee employee)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(c => c.EmployeeId == id);
            if(emp != null)
            {
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.Email = employee.Email;
                emp.PhoneNumber = employee.PhoneNumber;
                emp.Gender = employee.Gender;
                emp.Adress = employee.Adress;
                emp.Salary = employee.Salary;
                emp.DepartmentId = employee.DepartmentId;
                await _context.SaveChangesAsync();

            }
         
        }
    }
}
