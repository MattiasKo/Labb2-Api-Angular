namespace Labb2_Api_Angular.Models
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, T item);
        Task Insert(T item);
    }
}
