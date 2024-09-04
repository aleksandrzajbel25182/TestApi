namespace TestMSU.repository
{
    public interface IRepositoryBase<T>
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<IEnumerable<T>> GetAll();
    }
}