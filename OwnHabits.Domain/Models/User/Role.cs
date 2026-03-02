using OwnHabits.Domain.Common;

namespace OwnHabits.Domain.Models.User;

public class Role: BaseEntity
{
    public string Description { get; set; }
    
    public virtual ICollection<UserToRoles> UserToRoles { get; set; } = [];
}