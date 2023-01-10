namespace Interviews.ApplicationCore.Contracts.Repositories;

public interface IAsyncRepository<T> where T: class
{
    Task<T> Create(T entity);
    Task<T> Update(T entity);
    Task Delete(int id);
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
}