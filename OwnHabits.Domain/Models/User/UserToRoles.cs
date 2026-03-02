using OwnHabits.Domain.Common;

namespace OwnHabits.Domain.Models.User;

public class UserToRoles: BaseEntity
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }   
    
    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; }   
}