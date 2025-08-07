using Microsoft.EntityFrameworkCore;

namespace TaskManager.Infrastructure.common;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly TaskManagerDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(TaskManagerDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id)
        => await _dbSet.FindAsync(id);

    public async Task<List<T>> GetAllAsync()
        => await _dbSet.AsNoTracking().ToListAsync();

    public async Task AddAsync(T entity)
        => await _dbSet.AddAsync(entity);

    public void Update(T entity)
        => _dbSet.Update(entity);

    public void Remove(T entity)
        => _dbSet.Remove(entity);

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}