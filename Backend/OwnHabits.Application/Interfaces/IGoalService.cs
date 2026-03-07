using OwnHabits.Application.Dtos;
using OwnHabits.Domain.Common;
using OwnHabits.Domain.Models;

namespace OwnHabits.Application.Interfaces;

public interface IGoalService
{
    Task ChangeStatus(Guid goalId, Status status);
    Task ChangeDifficulty(Guid goalId, Difficulty difficulty);
    Task ChangePriority(Guid goalId, Priority priority);
    Task<List<Goal>> GetGoalsFilteredByStatus(Status status);
    Task<List<Goal>> GetGoalsFilteredByDifficulty(Difficulty difficulty);
    Task<List<Goal>> GetGoalsFilteredByPriority(Priority priority);
    Task<Goal> GetGoalByIdAsync(Guid id);
    Task AddGoalAsync(CreateGoalRequest goalRequest);
    Task RemoveGoalAsync(Guid id);
}