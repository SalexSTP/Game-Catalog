using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public sealed class Repository<T> : IRepository<T> where T : class
{
    private readonly GameCatalogDbContext _context;
    private readonly DbSet<T> _set;

    public Repository(GameCatalogDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _set = _context.Set<T>();
    }

    public IQueryable<T> All()
    {
        return _set;
    }

    public IQueryable<T> AllAsNoTracking()
    {
        return _set.AsNoTracking();
    }

    public async Task<T?> GetByIdAsync(object id)
    {
        return await _set.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _set.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _set.Update(entity);
    }

    public void Delete(T entity)
    {
        _set.Remove(entity);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}