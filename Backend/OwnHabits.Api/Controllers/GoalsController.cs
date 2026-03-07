using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OwnHabits.Application.Dtos;
using OwnHabits.Application.Interfaces;
using OwnHabits.Domain.Common;

namespace OwnHabits.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GoalsController(IGoalService goalService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetGoalByIdAsync([FromQuery] Guid id)
    {
        var goal = await goalService.GetGoalByIdAsync(id);
        return Ok(goal);
    }
    
    [HttpGet("{status}")]
    public async Task<IActionResult> GetGoalsFilteredByStatus([FromQuery] Status status)
    {
        var goals = await goalService.GetGoalsFilteredByStatus(status);
        return Ok(goals);
    }
    
    [HttpGet("{difficulty}")]
    public async Task<IActionResult> GetGoalsFilteredByDifficulty([FromQuery] Difficulty difficulty)
    {
        var goals = await goalService.GetGoalsFilteredByDifficulty(difficulty);
        return Ok(goals);
    }
    
    [HttpGet("{priority}")]
    public async Task<IActionResult> GetGoalsFilteredByPriority([FromQuery] Priority priority)
    {
        var goals = await goalService.GetGoalsFilteredByPriority(priority);
        return Ok(goals);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddGoalAsync([FromBody] CreateGoalRequest goalRequest)
    { 
        await goalService.AddGoalAsync(goalRequest);
        return Created();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveGoalAsync(Guid id)
    {
        await goalService.RemoveGoalAsync(id);
        return NoContent();
    }
}