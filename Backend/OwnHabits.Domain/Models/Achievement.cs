using System;
using OwnHabits.Domain.Common;

namespace OwnHabits.Domain.Models;

public class Achievement: BaseEntity
{
    public string Title { get; set; }
    public string ConditionToGet { get; set; } 
    public bool IsAchieved { get; set; } = false;
    public DateTime DateAchieved { get; set; }
    public int Experience  { get; set; }
    
    public Guid CharacteristicId { get; set; }
    public virtual Characteristic CharacteristicToUpgrade { get; set; }
}