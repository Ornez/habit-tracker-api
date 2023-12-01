namespace habit_tracker_api.Accounts.DTOs;

public record UserDto
{
    public required string Username { get; set; }
    public required string Token { get; set; }
}
