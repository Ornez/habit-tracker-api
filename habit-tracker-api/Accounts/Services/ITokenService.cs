using habit_tracker_api.Accounts.Entities;

namespace habit_tracker_api.Accounts.Services;

public interface ITokenService
{
    Task<string> CreateToken(AppUser user);
}
