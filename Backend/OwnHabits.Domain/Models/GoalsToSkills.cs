using OwnHabits.Domain.Common;

namespace OwnHabits.Domain.Models;

public class GoalsToSkills: BaseEntity
{
    public Guid SkillId { get; set; }
    public virtual Skill Skill { get; set; }
    
    public Guid GoalId { get; set; }
    public virtual Goal Goal { get; set; }
}