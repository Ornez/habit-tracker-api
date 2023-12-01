using System.ComponentModel.DataAnnotations;

namespace habit_tracker_api.Accounts.DTOs;

public record RegisterDto
{
    [MinLength(5)]
    public required string Username { get; set; }
    [MinLength(8)]
    public required string Password { get; set; }
}
