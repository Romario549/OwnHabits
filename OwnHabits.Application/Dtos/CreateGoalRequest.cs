namespace OwnHabits.Application.Dtos;

public class CreateGoalRequest
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public int GainedExperience { get; set; }
    public int Penalty { get; set; }

}