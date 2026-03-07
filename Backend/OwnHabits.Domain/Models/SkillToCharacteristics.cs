using OwnHabits.Domain.Common;

namespace OwnHabits.Domain.Models;

public class SkillToCharacteristics: BaseEntity
{
    public Guid SkillId { get; set; }
    public virtual Skill Skill { get; set; }
    
    public Guid CharacteristicId { get; set; }
    public virtual Characteristic Characteristic { get; set; }
    
}