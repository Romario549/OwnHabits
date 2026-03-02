using System.Collections.Generic;
using OwnHabits.Domain.Common;
using OwnHabits.Domain.Models.User;

namespace OwnHabits.Domain.Models;

public class Characteristic : BaseTextEntity
{
    public int Level { get; set; } = 1;
    public int CurrentExperience { get; set; } = 0;
    public int NextLevelExperience { get; set; } = 100;

    public virtual ICollection<SkillToCharacteristics> RequiredSkills { get; set; } = [];
    public virtual ICollection<Achievement> CompletedAchievements { get; set; } = [];
    public virtual ICollection<UserToCharacteristics> UserCharacteristics { get; set; } = [];

}
