using habit_tracker_api.Accounts.Entities;

namespace habit_tracker_api.Accounts.Repositories;

public interface IUserRepository
{
    Task<AppUser> GetUserByIdAsync(int id);
}
