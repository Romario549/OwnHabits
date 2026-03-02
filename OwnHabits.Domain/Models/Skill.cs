using OwnHabits.Domain.Common;
using OwnHabits.Domain.Models.User;

namespace OwnHabits.Domain.Models;

public class Skill: BaseTextEntity
{
    public int Level { get; set; } = 1;
    public int CurrentExperience { get; set; } = 0;
    public int NextLevelExperience { get; set; } = 100;
    
    public virtual ICollection<SkillToCharacteristics> UpgradableCharacteristics { get; set; } = [];
    public virtual ICollection<GoalsToSkills> ExperiencedGoals { get; set; } = [];
    public virtual ICollection<UserToSkills> UserSkills { get; set; } = [];


    
}