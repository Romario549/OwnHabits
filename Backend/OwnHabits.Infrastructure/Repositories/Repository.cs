using Microsoft.EntityFrameworkCore;
using OwnHabits.Domain.Common;
using OwnHabits.Domain.Interfaces;

namespace OwnHabits.Infrastructure.Repositories;

public class Repository<T>(AppDbContext dbContext) : IRepository<T>
    where T : BaseEntity
{
    private readonly DbSet<T> _dbSet = dbContext.Set<T>();

    public async Task CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
        => await _dbSet
               .AsNoTracking()
               .FirstOrDefaultAsync(e=>e.Id == id) 
           ??  throw new KeyNotFoundException();
    

    public async Task<IList<T>> GetAllAsync() 
        => await _dbSet.ToListAsync();

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    public async Task RemoveByIdAsync(Guid id)
    {
        await _dbSet
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync<T>();
    }
    
}