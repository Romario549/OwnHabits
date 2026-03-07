using Microsoft.AspNetCore.Identity;
using OwnHabits.Domain.Common;

namespace OwnHabits.Domain.Models.User;

public class User: IdentityUser<Guid>
{
    public int CompletedGoals { get; set; } = 0;
    public PersonGrade Grade { get; set; } = PersonGrade.Newbie;
    
    public virtual ICollection<UserToGoals> Goals { get; set; } = [];
    public virtual ICollection<UserToSkills> Skills { get; set; } = [];
    public virtual ICollection<UserToCharacteristics> Characteristics { get; set; } = [];


    public virtual ICollection<IdentityUserRole<Guid>> UserRoles { get; set; } = [];
    public virtual ICollection<IdentityUserLogin<Guid>> Logins { get; set; } = [];
    public virtual ICollection<IdentityUserClaim<Guid>> Claims { get; set; } = [];
    public virtual ICollection<IdentityUserToken<Guid>> Tokens { get; set; } = [];
}