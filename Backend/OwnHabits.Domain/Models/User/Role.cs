using Microsoft.AspNetCore.Identity;
using OwnHabits.Domain.Common;

namespace OwnHabits.Domain.Models.User;

public class Role: IdentityRole<Guid>
{
    public string Description { get; set; }

    public virtual ICollection<IdentityUserRole<Guid>> UserRoles { get; set; } = [];
    public virtual ICollection<IdentityRoleClaim<Guid>> RoleClaims { get; set; } = [];
}