using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb2_Api_Angular.Models
{
    public class DepartmentRepository : IDepartment
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteById(Guid id)
        {
            var empDel = await _context.Departments.FirstOrDefaultAsync(c => c.DepartmentId == id);
            if (empDel != null)
            {
                _context.Departments.Remove(empDel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetById(Guid id)
        {
            var emp = await _context.Departments.FirstOrDefaultAsync(c => c.DepartmentId == id);
            return emp;

        }

        public async Task Insert(Department department)
        {
            department.DepartmentId = Guid.NewGuid();
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();

        }
            public async Task UpdateById(Guid id,Department department)
        {
            var dep = await _context.Departments.FirstOrDefaultAsync(c => c.DepartmentId == id);
            if(dep != null)
            {
                dep.EmployeeID = department.EmployeeID;
                dep.DepartmentName = department.DepartmentName;
               
                await _context.SaveChangesAsync();

            }
         
        }
    }
}
