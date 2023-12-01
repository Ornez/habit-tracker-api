using habit_tracker_api.Accounts.Entities;
using habit_tracker_api.Shared.Data;

namespace habit_tracker_api.Accounts.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<AppUser> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}
