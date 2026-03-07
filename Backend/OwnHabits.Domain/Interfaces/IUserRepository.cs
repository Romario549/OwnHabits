using Microsoft.AspNetCore.Identity;
using OwnHabits.Domain.Models.User;

namespace OwnHabits.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> GetByEmailWithAllAbilities(string email);
    
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(string id);
    Task<IdentityResult> CreateUserAsync(User user, string password);
    Task<IdentityResult> CreateUserAsync(User user);
    Task<IdentityResult> UpdateUserAsync(User user);
    Task<IdentityResult> DeleteUserAsync(string userId);

    Task<bool> CheckPasswordAsync(User user, string password);
    Task<bool> EmailExistsAsync(string email);
    Task<List<string>> GetUserRolesAsync(User user);
    Task<IdentityResult> AddToRoleAsync(User user, string roleName);
    
    Task<User> GetByLoginAsync(string loginProvider, string providerKey);
    Task<IdentityResult> AddLoginAsync(User user, UserLoginInfo loginInfo);


}
