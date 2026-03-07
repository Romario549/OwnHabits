using OwnHabits.Application.Dtos;
using OwnHabits.Application.Interfaces;
using OwnHabits.Domain.Common;
using OwnHabits.Domain.Interfaces;
using OwnHabits.Domain.Models;

namespace OwnHabits.Application.Services;

public class GoalService(IRepository<Goal>  goalRepository): IGoalService
{
    private readonly IRepository<Goal> _goalRepository = goalRepository;
    
    public async Task ChangeStatus(Guid goalId, Status status)
    {
        var goal = await _goalRepository.GetByIdAsync(goalId);
        goal.Status = status;
        await _goalRepository.SaveChangesAsync();
    }
    
    public async Task<List<Goal>> GetGoalsFilteredByStatus(Status status)
    {
        var goals = await _goalRepository.GetAllAsync();
        return goals.Where(goal => goal.Status == status).ToList();
    }

    
    public async Task ChangeDifficulty(Guid goalId, Difficulty difficulty)
    {
        var goal = await _goalRepository.GetByIdAsync(goalId);
        goal.Difficulty = difficulty;
        await _goalRepository.SaveChangesAsync();
    }
    
    public async Task<List<Goal>> GetGoalsFilteredByDifficulty(Difficulty difficulty)
    {
        var goals = await _goalRepository.GetAllAsync();
        return goals.Where(goal => goal.Difficulty == difficulty).ToList();
    }
    
    public async Task ChangePriority(Guid goalId, Priority priority)
    {
        var goal = await _goalRepository.GetByIdAsync(goalId);
        goal.Priority = priority;
        await _goalRepository.SaveChangesAsync();
    }
    
    public async Task<List<Goal>> GetGoalsFilteredByPriority(Priority priority)
    {
        var goals = await _goalRepository.GetAllAsync();
        return goals.Where(goal => goal.Priority == priority).ToList();
    }
    
    public async Task<Goal> GetGoalByIdAsync(Guid id) 
        => await _goalRepository.GetByIdAsync(id);

    public async Task AddGoalAsync(CreateGoalRequest goalRequest)
    {
        var goal = new Goal
        {
            Title = goalRequest.Title,
            Description = goalRequest.Description,
            UserId = goalRequest.UserId,
            Deadline = goalRequest.Deadline,
            GainedExperience =  goalRequest.GainedExperience,
            Penalty = goalRequest.Penalty,
        };
        await _goalRepository.CreateAsync(goal);
    }
        
    
    public async Task RemoveGoalAsync(Guid id) 
        => await _goalRepository.RemoveByIdAsync(id);
    
}