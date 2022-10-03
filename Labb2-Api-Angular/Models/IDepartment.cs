namespace Labb2_Api_Angular.Models
{
    public interface IDepartment
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetById(Guid id);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, Department department);
        Task Insert(Department department);
    }
}
