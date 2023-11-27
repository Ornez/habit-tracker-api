using System.ComponentModel.DataAnnotations;

namespace habit_tracker_api.Accounts.DTOs;

public class RegisterDto
{
    [MinLength(5)]
    public string Username { get; set; }
    [MinLength(8)]
    public string Password { get; set; }
}
