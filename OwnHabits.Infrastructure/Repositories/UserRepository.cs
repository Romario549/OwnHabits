using Microsoft.EntityFrameworkCore;
using OwnHabits.Domain.Interfaces;
using OwnHabits.Domain.Models;
using OwnHabits.Domain.Models.User;

namespace OwnHabits.Infrastructure.Repositories;

public class UserRepository(AppDbContext dbContext) : Repository<User>(dbContext), IUserRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<User> GetByEmailWithCharacteristicsAndSkills(string email)
    {
        return await _dbContext.Set<User>()
            .Include(c=>c.Characteristics)
            .Include(s => s.Skills)
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email) 
               ?? throw new NullReferenceException("User with this email doesn't exist");
    }
}
