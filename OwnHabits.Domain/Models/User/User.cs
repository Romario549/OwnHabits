using OwnHabits.Domain.Common;

namespace OwnHabits.Domain.Models.User;

public class User: BaseEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public int CompletedGoals { get; set; } = 0;
    public PersonGrade Grade { get; set; } = PersonGrade.Newbie;
    
    public virtual ICollection<UserToRoles> UserToRoles { get; set; } = [];
    public virtual ICollection<UserToGoals> Goals { get; set; } = [];
    public virtual ICollection<UserToSkills> Skills { get; set; } = [];
    public virtual ICollection<UserToCharacteristics> Characteristics { get; set; } = [];


    



}