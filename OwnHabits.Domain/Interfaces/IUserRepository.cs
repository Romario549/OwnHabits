using System.Threading.Tasks;
using OwnHabits.Domain.Models;
using OwnHabits.Domain.Models.User;

namespace OwnHabits.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmailWithCharacteristicsAndSkills(string email);
}