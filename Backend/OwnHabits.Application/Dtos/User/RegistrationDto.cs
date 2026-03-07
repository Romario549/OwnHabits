namespace OwnHabits.Application.Dtos.User;

public record RegistrationDto(
    string UserName, 
    string Email,
    string Password,
    string ConfirmPassword);