using OwnHabits.Domain.Common;

namespace OwnHabits.Domain.Models.User;

public class UserToCharacteristics: BaseEntity
{
    public virtual Guid UserId { get; set; }
    public virtual User User { get; set; }
    
    public virtual Guid CharacteristicId { get; set; }
    public virtual Characteristic Characteristic { get; set; }
    
}