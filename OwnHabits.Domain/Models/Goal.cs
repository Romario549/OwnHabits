using OwnHabits.Domain.Common;
using OwnHabits.Domain.Models.User;

namespace OwnHabits.Domain.Models;

public class Goal: BaseTextEntity
{
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime Deadline { get; set; }
    public Status Status { get; set; } = Status.InProgress;
    public Priority Priority { get; set; } = Priority.Normal;
    public Difficulty Difficulty { get; set; } = Difficulty.Easy;
    public bool Repeatability {get; set; } = false;
    public int GainedExperience { get; set; }
    public int Penalty  { get; set; }
    
    public virtual ICollection<GoalsToSkills> UpgradableSkills { get; set; } = [];
    public virtual ICollection<UserToGoals> UserGoals { get; set; } = [];


}