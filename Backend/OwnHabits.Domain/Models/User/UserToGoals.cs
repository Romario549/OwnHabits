using OwnHabits.Domain.Common;

namespace OwnHabits.Domain.Models.User;

public class UserToGoals: BaseEntity
{
    public virtual Guid UserId { get; set; }
    public virtual User User { get; set; }
    
    public virtual Guid GoalId { get; set; }
    public virtual Goal Goal { get; set; }
}