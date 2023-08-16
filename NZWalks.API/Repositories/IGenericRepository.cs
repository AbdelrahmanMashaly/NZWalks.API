namespace NZWalks.API.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int? id);

        Task<T> Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
