using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OwnHabits.Domain.Interfaces;
using OwnHabits.Domain.Models.User;

namespace OwnHabits.Infrastructure.Repositories;

public class UserRepository(UserManager<User> userManager) : IUserRepository
{
    public async Task<User> GetByEmailWithAllAbilities(string email)
    {
        return await userManager.Users
                   .Include(c=>c.Characteristics)
                   .Include(s => s.Skills)
                   .Include(g=>g.Goals)
                   .AsNoTracking()
                   .FirstOrDefaultAsync(u => u.Email == email) 
               ?? throw new NullReferenceException("User with this email doesn't exist");
    }
    
    public async Task<User?> GetByIdAsync(string id) =>
        await userManager.FindByIdAsync(id);

    public async Task<User?> GetByEmailAsync(string email) =>
        await userManager.FindByEmailAsync(email);

    public async Task<IdentityResult> CreateUserAsync(User user, string password) =>
        await userManager.CreateAsync(user, password);
    public async Task<IdentityResult> CreateUserAsync(User user) =>
        await userManager.CreateAsync(user);

    public async Task<bool> CheckPasswordAsync(User user, string password)
        => await userManager.CheckPasswordAsync(user, password);

    public async Task<IdentityResult> UpdateUserAsync(User user)
        => await userManager.UpdateAsync(user);

    public async Task<IdentityResult> DeleteUserAsync(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        return user == null 
            ? IdentityResult.Failed(new IdentityError {	Description = "Пользователь не найден!"})
            : await userManager.DeleteAsync(user);
    }

    public async Task<bool> EmailExistsAsync(string email)
        => await userManager.FindByEmailAsync(email) != null;

    public async Task<List<string>> GetUserRolesAsync(User user)
        => [.. await userManager.GetRolesAsync(user)];

    public async Task<IdentityResult> AddToRoleAsync(User user, string roleName)
        => await userManager.AddToRoleAsync(user, roleName);
    
    public async Task<User> GetByLoginAsync(string loginProvider, string providerKey)
    {
        return await userManager.FindByLoginAsync(loginProvider, providerKey);
    }
    
    public async Task<IdentityResult> AddLoginAsync(User user, UserLoginInfo loginInfo)
    {
        return await userManager.AddLoginAsync(user, loginInfo);
    }

}