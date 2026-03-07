using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OwnHabits.Domain.Common;

namespace OwnHabits.Domain.Interfaces;

public interface IRepository<T>  where T : BaseEntity
{
    Task CreateAsync(T entity);
    Task<T> GetByIdAsync(Guid id);
    Task<IList<T>> GetAllAsync();
    Task SaveChangesAsync();
    Task RemoveByIdAsync(Guid id);
}