namespace Devices.Web.API.Repositories.Interface
{
    public interface IRepositoryBase<T>
    {
        Task<T> FindAsync(params object[] key);

        Task<IEnumerable<T>> FindAllAsync();

        Task<T> CreateAsync(T entity);

        Task<List<T>> CreateAsync(List<T> list_entity);

        Task SaveAsync();
    }
}