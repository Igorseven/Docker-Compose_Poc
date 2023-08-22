using CustomerBase.API.Business.Insfrastructure.ORM.Context;
using Microsoft.EntityFrameworkCore;

namespace CustomerBase.API.Business.Insfrastructure.Repository.Base;
public abstract class BaseRepository<T> : IDisposable where T : class
{
    protected readonly ApplicationContext _context;
    protected DbSet<T> _dbSet => _context.Set<T>();

    public BaseRepository(ApplicationContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    protected async Task<bool> SaveInDatabaseAsync() => await _context.SaveChangesAsync() > 0;

    protected void DetachedObject(T entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
            _dbSet.Attach(entity);
    }
}
