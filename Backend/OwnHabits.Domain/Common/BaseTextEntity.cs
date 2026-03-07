namespace OwnHabits.Domain.Common;

public abstract class BaseTextEntity: BaseEntity
{
    public Guid UserId { get; set; }
    public string Title { get; init; }
    public string? Description { get; set; }
}