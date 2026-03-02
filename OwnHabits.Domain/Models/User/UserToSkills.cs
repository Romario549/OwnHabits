using OwnHabits.Domain.Common;

namespace OwnHabits.Domain.Models.User;

public class UserToSkills: BaseEntity
{
    public virtual Guid UserId { get; set; }
    public virtual User User { get; set; }
    
    public virtual Guid SkillId { get; set; }
    public virtual Skill Skill { get; set; }
}