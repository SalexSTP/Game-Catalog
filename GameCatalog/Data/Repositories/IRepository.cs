namespace Data.Repositories;

public interface IRepository<T> where T : class
{
    IQueryable<T> All();

    IQueryable<T> AllAsNoTracking();

    Task<T?> GetByIdAsync(object id);

    Task AddAsync(T entity);

    void Update(T entity);

    void Delete(T entity);

    Task<int> SaveChangesAsync();
}