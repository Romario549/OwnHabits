namespace OwnHabits.Application.Dtos.User;

public record AuthResult(
    DateTime Expiration,
    string Email,
    Guid UserId,
    IEnumerable<string> Roles
);