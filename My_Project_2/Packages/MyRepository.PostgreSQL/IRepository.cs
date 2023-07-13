using System.Linq.Expressions;

namespace MyRepository.PostgreSQL{
    public interface IRepository<T> where T : Entity{
        Task <ICollection<T>> GetAllAsync();
        Task <ICollection<T>> GetAllAsync(Func<T, bool> filter);

        Task <T> GetAsync(Guid id);
        Task <T> GetAsync(Func<T, bool> filter); 

        Task UpdateAsync(T entity);
        Task CreateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}