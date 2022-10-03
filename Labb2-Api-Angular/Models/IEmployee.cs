namespace Labb2_Api_Angular.Models
{
    public interface IEmployee
    {
        
        Task<IEnumerable<Employee>> GetAll();
        Task <Employee> GetById(Guid id);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, Employee employee);
        Task Insert(Employee employee);

        
    }
}
